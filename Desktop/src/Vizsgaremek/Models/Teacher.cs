using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Vizsgaremek.Models
{
    public enum EmploymentValue { LECTURER,INDENTUREDLABOURER, DONEONCOMMISSION }

    public class Teacher : INotifyPropertyChanged
    {
        private string id;
        private string lastName;
        private string firstName;
        private string password;
        private bool meal;
        private EmploymentValue emploeyment;
        private string emploeymentName;

        public Teacher()
        {
            {
                this.Id = string.Empty;
                this.LastName = string.Empty;
                this.FirstName = string.Empty;
                this.Password = string.Empty;
                this.Meal = false;
                this.Emploeyment = EmploymentValue.DONEONCOMMISSION;
            }
        }
        public Teacher(string id, string lastname, string firstname, string password, bool meal, EmploymentValue emploeyment)
        {
            this.id = id;
            this.lastName = lastname;
            this.FirstName = firstname;
            this.Password = password;
            this.Meal = meal;
            this.Emploeyment = emploeyment;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                
            }
        }
        public string FirstName 
        {
            get 
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }



        public string Password 
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }  
        }
        public bool Meal 
        {
            get
            { 
                return meal; 
            }
            set
            {
                meal = value;
                OnPropertyChanged("Meal");
            }
        }

        public void SetTo(Teacher teacher)
        {
            this.id = teacher.id;
            this.firstName = teacher.firstName;
            this.lastName = teacher.lastName;
            this.meal = teacher.meal;
            this.password = teacher.password;
            this.emploeyment = teacher.emploeyment;
        }

        public EmploymentValue Emploeyment 
        {
            get
            {
                return emploeyment;
            }
            set
            {
                emploeyment = value;
                OnPropertyChanged("EmploeymentName");
            }
        }
        
        public string EmploeymentName
        {
            get
            {
                switch(emploeyment)
                {
                    case EmploymentValue.LECTURER:
                        return "óraadó";
                    case EmploymentValue.INDENTUREDLABOURER:
                        return "szerződéses alkalmazott";
                    case EmploymentValue.DONEONCOMMISSION:
                        return "állandó megbízásos rendelkező";
                }
                return string.Empty;
            }

            set
            {
                emploeymentName = value;
                if (emploeymentName == "óraadó")
                    emploeyment = EmploymentValue.LECTURER;
                else if (emploeymentName == "szerződéses alkalmazott")
                    emploeyment = EmploymentValue.INDENTUREDLABOURER;
                else 
                    emploeyment = EmploymentValue.DONEONCOMMISSION;
                OnPropertyChanged("EmploeymentName");
            }

        }

        protected void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
