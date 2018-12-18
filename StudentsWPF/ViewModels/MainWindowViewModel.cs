using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using Catel.Data;
using StudentsWPF.Models;
using Catel.MVVM;
using System.Xml.Serialization;
using Catel.Services;

namespace StudentsWPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService; // отображение сообщений MessageBox

        List<Student> _listStudents = new List<Student>();

        public override string Title
        {
            get { return "StudentsWPF"; }
        }

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService,
            IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;

            Deserialization();
        }

        public void Deserialization()
        {
            XmlSerializer xmlSerializers = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
            try
            {
                StreamReader sr = new StreamReader("Students.xml");
                try
                {
                    List<Student> student = (List<Student>)xmlSerializers.Deserialize(sr);
                    foreach (Student students in student)
                    {
                        string _gender = students.Gender == "0" || students.Gender == "Мужской" ? "Мужской" : "Женский";

                        _listStudents.Add(new Student
                        {
                            Id = students.Id,
                            FirstName = students.FirstName,
                            Last = students.Last,
                            Age = students.Age,
                            Gender = _gender
                        });
                    }
                    sr.Close();
                }
                catch (InvalidOperationException e)
                {
                    _messageService.ShowAsync(e.Message);
                }
                catch (Exception e)
                {
                    _messageService.ShowAsync(e.Message);
                }
            }
            catch (FileNotFoundException e)
            {
                _messageService.ShowAsync(e.Message);
            }
            StudentsesCollection = new ObservableCollection<Student>(_listStudents);
            ValidationCollection();
        }

        public ObservableCollection<Student> StudentsesCollection //fill ListBox
        {
            get { return GetValue<ObservableCollection<Student>>(StudentsesCollectionProperty); }
            set { SetValue(StudentsesCollectionProperty, value); }
        }

        public static readonly PropertyData StudentsesCollectionProperty = RegisterProperty("StudentsesCollection",
            typeof(ObservableCollection<Student>));

        public Student SelectedStudents
        {
            get { return GetValue<Student>(SelectedStudentsProperty); }
            set { SetValue(SelectedStudentsProperty, value); }
        }

        public static readonly PropertyData SelectedStudentsProperty = RegisterProperty("SelectedStudents",
            typeof(Student), 0);

        #region Insert, Update, Remove, Save

        private Command _removeCommand;

        public Command RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new Command(async () =>
                           {
                               if (await _messageService.ShowAsync("Вы действительно хотите удалить объект?",
                                       "Внимание!",
                                       MessageButton.YesNo, MessageImage.Warning) != MessageResult.Yes)
                               {
                                   return;
                               }
                               StudentsesCollection.Remove(SelectedStudents);
                               ValidationCollection();
                           },
                           () => SelectedStudents != null));
            }
        }

        private Command _addCommand;

        public Command AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(() =>
                {
                    var viewModel = new StudentsWindowViewModel();

                    _uiVisualizerService.ShowDialog(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            StudentsesCollection.Add(viewModel.StudentObject);
                        }
                    });
                }));
            }
        }

        private Command _editCommand;

        public Command EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(() =>
                           {
                               var viewModel = new StudentsWindowViewModel(SelectedStudents);
                               _uiVisualizerService.ShowDialog(viewModel);
                               _save = SaveCommand;
                           },
                           () => SelectedStudents != null));
            }
        }

        private Command _save;

        public Command SaveCommand
        {
            get
            {
                return _save ?? (_save = new Command(() =>
                {
                   Serialization();

                    _pleaseWaitService.Show("Сохранение объекта...");

                    Thread.Sleep(200);

                    _pleaseWaitService.Hide();
                }));
            }
        }

        #endregion

        public void Serialization()
        {
            _listStudents = new List<Student>();
            int i = 0;
            string _gender;
            foreach (Student students in StudentsesCollection)
            {
                _gender = students.Gender == "Мужской" ? "0" : "1";

                _listStudents.Add(new Student
                {
                    Id = i,
                    FirstName = students.FirstName,
                    Last = students.Last,
                    Age = students.Age,
                    Gender = _gender
                });
                i++;
            }
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
            StreamWriter sw = new StreamWriter("Students.xml");
            xmlSerializer.Serialize(sw, _listStudents, namespaces);
            sw.Close();
        }

        private void ValidationCollection()
        {
            if (StudentsesCollection.Count == 0)
            {
                _messageService.ShowAsync("В списке нет элементов. Создайте запись.");
            }
        }

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (StudentsesCollection.Count == 0)
            {
                validationResults.Add(FieldValidationResult.CreateWarning(StudentsesCollectionProperty, "В списке нет элементов. Создайте запись."));
            }
        }
        
    }
}
