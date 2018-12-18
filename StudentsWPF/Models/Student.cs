using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Catel.Data;

namespace StudentsWPF.Models
{
    [XmlRoot("Student")]
    public class Student : ModelBase
    {

        [XmlAttribute("Id")]
        public int Id
        {
            get { return GetValue<int>(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly PropertyData IdProperty = RegisterProperty("Id", typeof(int));

        [XmlElement("FirstName")]
        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set
            {
                SetValue(FirstNameProperty, value);
                Name = value;
            }
        }

        public static readonly PropertyData FirstNameProperty = RegisterProperty("FirstName", typeof(string));

        [XmlElement("Last")]
        public string Last
        {
            get { return GetValue<string>(LastProperty); }
            set
            {   
                SetValue(LastProperty, value);
                Name = value;
            }
        }

        public static readonly PropertyData LastProperty = RegisterProperty("Last", typeof(string));

        [XmlIgnore]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set
            {
                value = FirstName + " " + Last;
                SetValue(NameProperty, value);
            }
        }

        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));

        [XmlElement("Age")]
        public int Age
        {
            get { return GetValue<int>(AgeProperty); }
            set
            {
                SetValue(AgeProperty, value);
                StringAge = value.ToString();
            }
        }

        public static readonly PropertyData AgeProperty = RegisterProperty("Age", typeof(int), 16);

        [XmlIgnore]
        public string StringAge
        {
            get { return GetValue<string>(StringAgeProperty); }
            set
            {
                if (Age % 10 < 5 && Age % 10 > 1)
                {
                    value = Age + " года";
                }
                else if (Age % 10 == 1)
                {
                    value = Age + " год";
                }
                else
                {
                    value = Age + " лет";
                }

                SetValue(StringAgeProperty, value);
            }
        }

        public static readonly PropertyData StringAgeProperty = RegisterProperty("StringAge", typeof(string), "лет");

        [XmlElement("Gender")]
        public string Gender
        {
            get { return GetValue<string>(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        public static readonly PropertyData GenderProperty = RegisterProperty("Gender", typeof(string));

        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(FirstNameProperty, "Необходимо указать имя"));
            }
            else
            {
                if (Regex.IsMatch(FirstName, @"^[^A-ZА-ЯЁ]|\d|[!@#$%^&*()_^/\|.,?<>]"))
                {
                    validationResults.Add(FieldValidationResult.CreateError(FirstNameProperty, "Необходимо указать корректное имя. Например: Сергей, Sergey"));
                }
            }
                        
            if (string.IsNullOrEmpty(Last))
            {
                validationResults.Add(FieldValidationResult.CreateError(LastProperty, "Необходимо указать фамилию"));
            }
            else
            {
                if (Regex.IsMatch(Last, @"^[^A-ZА-ЯЁ]|\d|[!@#$%^&*()_^/\|.,?<>]"))
                {
                    validationResults.Add(FieldValidationResult.CreateError(LastProperty, "Необходимо указать корректную фамилию. Например: Клименко, Klimenko"));
                }
            }

            if (16 > Age || Age > 100)
            {
                validationResults.Add(FieldValidationResult.CreateError(AgeProperty, "Необходимо указать возраст от 16 до 100 лет"));
            }

            if (string.IsNullOrEmpty(Gender))
            {
                validationResults.Add(FieldValidationResult.CreateError(GenderProperty, "Необходимо указать пол"));
            }
        }
    }
}