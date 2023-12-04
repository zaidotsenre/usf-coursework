

using System;
using System.ComponentModel;

namespace AHPA_15___Student_Data
{
    internal class Student :INotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName;
        private string lastName;
        private string id;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName { 
            get { return firstName; } 
            set { 
                firstName = value;
                NotifyPropertyChanged("FirstName");
            } 
        }
        public string LastName { 
            get { return lastName; } 
            set { 
                lastName = value;
                NotifyPropertyChanged("LastName");
            } 
        }
        public string ID { get { return id; } }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string retvalue = null;
                if(columnName == "FirstName")
                {
                    if(String.IsNullOrEmpty(this.firstName) || this.firstName.Length < 3)
                    {
                        retvalue = "First name must be at least 3 characters long.";
                    }
                }
                if (columnName == "LastName")
                {
                    if (String.IsNullOrEmpty(this.lastName) || this.lastName.Length < 3)
                    {
                        retvalue = "Last name must be at least 3 characters long.";
                    }
                }
                return retvalue;
            }
        }

        public Student() { 
            Random random = new Random();
            this.id = "U" + random.Next(10000000, 99999999).ToString();
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
