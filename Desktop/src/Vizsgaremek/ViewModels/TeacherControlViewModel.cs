using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;
using Vizsgaremek.Models;
using Vizsgaremek.ViewModels.BaseClass;
using Vizsgaremek.Repositories;
using Vizsgaremek.Stores;

using System.Windows.Input;
using Vizsgaremek.Commands;

namespace Vizsgaremek.ViewModels
{
    public class TeacherControlViewModel : ViewModelBase
    {
        private TeacherStore teacherStore;

        private Teacher orginalSelectedTeacher;
        private Teacher editedTeacher;
        ObservableCollection<EmploymentDisplayName> employments;
        private string selectedEmpolymentsName;

        //public RelayCommand DeleteCommand { get; set; }
        //public RelayCommand UpdateCommand { get; set; }
        //public RelayCommand InsertCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public ICommand DeleteTeacherCommand { get; }

        public TeacherControlViewModel(TeacherStore teacherStore)
        {
            this.teacherStore = teacherStore;

            editedTeacher = new Teacher();
            orginalSelectedTeacher = new Teacher();
            
            DisplayedEmployments displayedEmployments = new DisplayedEmployments();
            selectedEmpolymentsName = editedTeacher.EmploeymentName;

            employments = new ObservableCollection<EmploymentDisplayName>(displayedEmployments.Empoylements);

            //DeleteCommand = new RelayCommand(e => DeleteTeacher());
            //UpdateCommand = new RelayCommand(e => UpdateTeacher());
            //InsertCommand = new RelayCommand(e => InsertTeacher());
            CancelCommand = new RelayCommand(e => Cancel());

            DeleteTeacherCommand = new DeleteTeacherCommand(this, teacherStore);
            
        }



        public Teacher EditedTeacher
        {
            get
            {
                return editedTeacher;
            }
            set
            {
                editedTeacher = value;
                OnPropertyChanged("EditedTeacher");
                OnPropertyChanged("SelectedEmpolymentsName");
            }
        }

        public Teacher OrdiganlSelectedTeacher 
        { 
            get => orginalSelectedTeacher; 
            set => orginalSelectedTeacher.SetTo(value); 
        }

        public ObservableCollection<EmploymentDisplayName> Employments
        {
            get
            {
                return employments;
            }

            set
            {
                employments = value;
                OnPropertyChanged("Employments");
            }
        }               

        private void Cancel()
        {
            EditedTeacher.SetTo(orginalSelectedTeacher);
            OnPropertyChanged("EditedTeacher");
        }
    }
}
