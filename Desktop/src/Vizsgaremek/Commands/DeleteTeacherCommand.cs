using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.ViewModels;
using Vizsgaremek.Stores;

namespace Vizsgaremek.Commands
{
    class DeleteTeacherCommand : CommandBase
    {
        private readonly TeacherControlViewModel teacherControlViewModel;
        private readonly TeacherStore teacherStore;

        public DeleteTeacherCommand(TeacherControlViewModel teacherControlViewModel, TeacherStore teacherStore)
        {
            this.teacherControlViewModel = teacherControlViewModel;
            this.teacherStore = teacherStore;
        }

        public override void Execute(object parameter)
        {
            // Insert
            /*
                *Teacher teacher = new Teacher()
            {
                Id = teacherControlViewModel.EditedTeacher.Id,
                FirstName = teacherControlViewModel.EditedTeacher.FirstName,
                LastName = teacherControlViewModel.EditedTeacher.LastName,
                Meal = teacherControlViewModel.EditedTeacher.Meal,
                Emploeyment = teacherControlViewModel.EditedTeacher.Emploeyment,
                Password = teacherControlViewModel.EditedTeacher.Password

            };*/
            teacherStore.DeleteTeacher(teacherControlViewModel.EditedTeacher.Id);
        }

    }
}
