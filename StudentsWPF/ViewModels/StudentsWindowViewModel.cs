using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using StudentsWPF.Models;

namespace StudentsWPF.ViewModels
{
    public class StudentsWindowViewModel : ViewModelBase
    {
        public StudentsWindowViewModel(Student student = null)
        {
            StudentObject = student ?? new Student();
            ComboBoxCollection = new ObservableCollection<string>() { "Мужской", "Женский" };
        }

        [Model]
        public Student StudentObject
        {
            get { return GetValue<Student>(StudentObjectProperty); }
            set { SetValue(StudentObjectProperty, value); }
        }
        public static readonly PropertyData StudentObjectProperty = RegisterProperty("StudentObject", typeof(Student));

        #region fill textBox and ComboBox

        [ViewModelToModel("StudentObject", "FirstName")]
        public string FirstNameStudents
        {
            get { return GetValue<string>(FirstNameStudentsProperty); }
            set { SetValue(FirstNameStudentsProperty, value); }
        }

        public static readonly PropertyData FirstNameStudentsProperty = RegisterProperty("FirstNameStudents", typeof(string));

        [ViewModelToModel("StudentObject", "Last")]
        public string LastStudents
        {
            get { return GetValue<string>(LastStudentsProperty); }
            set { SetValue(LastStudentsProperty, value); }
        }

        public static readonly PropertyData LastStudentsProperty = RegisterProperty("LastStudents", typeof(string));

        [ViewModelToModel("StudentObject", "Age")]
        public int AgeStudents
        {
            get { return GetValue<int>(AgeStudentsProperty); }
            set { SetValue(AgeStudentsProperty, value); }
        }

        public static readonly PropertyData AgeStudentsProperty = RegisterProperty("AgeStudents", typeof(int), 16);

        #region comboBox

        [ViewModelToModel("StudentObject", "Gender")]
        public string GenderStudentsSelect //select comboBox 
        {
            get { return GetValue<string>(GenderStudentsProperty); }
            set{SetValue(GenderStudentsProperty, value);}
        }

        public static readonly PropertyData GenderStudentsProperty = RegisterProperty("GenderStudentsSelect", typeof(string));

        public ObservableCollection<string> ComboBoxCollection //fill comboBox
        {
            get { return GetValue<ObservableCollection<string>>(ComboBoxCollectionProperty); }
            set { SetValue(ComboBoxCollectionProperty, value); }
        }

        public static readonly PropertyData ComboBoxCollectionProperty = RegisterProperty("ComboBoxCollection", typeof(ObservableCollection<string>));

        #endregion

        #endregion

    }
}
