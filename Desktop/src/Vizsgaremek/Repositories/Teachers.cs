using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.Repositories.Interfaces;
using Vizsgaremek.Pages;

using System.Collections.ObjectModel;

namespace Vizsgaremek.Repositories
{

    public partial class Teachers : IRepositoryAPIStringId<Teacher>
    {
        private List<Teacher> teachers;


        private EmploymentDisplayName selectedEmplymentItem;



        
        public EmploymentDisplayName SelectedEmplymentItem 
        { 
            get => selectedEmplymentItem; 
            set => selectedEmplymentItem = value; 
        }


        public Teachers()
        {
            teachers = new List<Teacher>();
            MakeTestData();
        }



        public void MakeTestData()
        {
            teachers.Add(new Teacher("10101111111", "Számoló", "Szonja", "123456", true, EmploymentValue.LECTURER));
            teachers.Add(new Teacher("10101111112", "Buktató", "Béla", "123456", false, EmploymentValue.INDENTUREDLABOURER));
            teachers.Add(new Teacher("10101111113", "Aritmetika", "Antal", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111114", "Arany", "András", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111115", "Sportoló", "Jenő", "123456", false, EmploymentValue.DONEONCOMMISSION));
            teachers.Add(new Teacher("10101111116", "Visszanéző", "Viola", "123456", false, EmploymentValue.DONEONCOMMISSION));                        
        }


        public List<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        public List<Teacher> AllTeachers
        {
            get
            {
                return teachers;
            }
        }

        public Teacher GetById(string id)
        {
            if (!teachers.Exists(teacher => teacher.Id == id))
                return null;
            else
                return teachers.Find(teacher => teacher.Id == id);
        }


        public void Delete(string id)
        {
            Teacher techerToDelete = teachers.Find(t => t.Id == id);
            if (techerToDelete!=null)
            {
                teachers.Remove(techerToDelete);
            }
        }

        public void Insert()
        {
            Teacher newTeacher = new Teacher();
            newTeacher.FirstName = "valami";
            newTeacher.LastName = " más";
            teachers.Add(newTeacher);
        }

    }
}
