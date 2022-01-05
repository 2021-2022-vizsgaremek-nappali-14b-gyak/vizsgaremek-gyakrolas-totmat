using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Vizsgaremek.Models;
using Vizsgaremek.Repositories;
using Vizsgaremek.ViewModels.BaseClass;
using Vizsgaremek.Stores;

using System.Windows.Data;

namespace Vizsgaremek.ViewModels
{
    public class TeacherPageViewModel : ViewModelBase
    {
        
        private Teachers teachersRepo;
        private TeacherStore teacherStore;
        private TeacherControlViewModel teacherControlViewModels;

        public TeacherControlViewModel TeacherControlViewModels 
        { 
            get => teacherControlViewModels; 
            set => teacherControlViewModels = value; 
        }


        ObservableCollection<Teacher> displayedTeachers;
        private Teacher selectedTeacher;
        private bool isRowSelectedInDataGird;

        public bool HasTeacher
        {
            get
            {
                if (displayedTeachers.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool HasNoTeacher
        {
            get
            {
                return !HasTeacher;
            }
        }

        public TeacherPageViewModel(TeacherStore teacherStore, TeacherControlViewModel teacherControlViewModels)
        {
            this.teacherControlViewModels = teacherControlViewModels;
            this.teacherStore = teacherStore;

            teachersRepo = new Teachers();
            selectedTeacher = new Teacher();
            //displayedTeachers = new ObservableCollection<Teacher>();
            displayedTeachers = new ObservableCollection<Teacher>(teachersRepo.GetAllTeachers());

            teacherStore.TeacherDeleteEvent += OnTeacherDelete;

        }

        public void SetDisplaydTeachers()
        {
            displayedTeachers.Clear();
            displayedTeachers   = new ObservableCollection<Teacher>(teachersRepo.GetAllTeachers());
            teachersRepo.GetAllTeachers().ForEach(displayedTeachers.Add);
            OnPropertyChanged("DisplayedTeachers");
        }

        private void OnTeacherDelete(string id)
        {
            Teacher deletedTeacher = teachersRepo.GetById(id);
            if (deletedTeacher != null)
            {
                DisplayedTeachers.Remove(deletedTeacher);
                teachersRepo.Delete(id);
                OnPropertyChanged("DisplayedTeachers");
            }                        
        }

        public bool IsRowSelectedInDataGrid
        {
            get
            {
                return isRowSelectedInDataGird;
            }

            set
            {
                isRowSelectedInDataGird = value;
                OnPropertyChanged("IsRowSelectedInDataGird");
            }
        }
    
        public ObservableCollection<Teacher> DisplayedTeachers
        {
            get
            {
                return displayedTeachers;
            }
            set
            {
                displayedTeachers = value;
                OnPropertyChanged("DisplayedTeachers");
            }
        }

        public Teacher SelectedTeacher
        {
            get
            {
                return selectedTeacher;
            }

            set
            {
                Teacher selectedTeacherInDataGrid = value as Teacher;
                if (selectedTeacherInDataGrid != null)
                {
                    selectedTeacher.SetTo(selectedTeacherInDataGrid);
                    OnPropertyChanged("SelectedTeacher");
                }
            }
        }  
    }
}
