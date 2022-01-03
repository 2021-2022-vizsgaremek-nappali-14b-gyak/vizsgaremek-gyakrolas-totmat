using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Stores
{
    public class TeacherStore
    {
        // https://www.youtube.com/watch?v=o62iFhXkWS4
        // https://github.com/SingletonSean/wpf-tutorials/tree/master/CommunicationMVVM

        public event Action<string> TeacherDeleteEvent;

        public void DeleteTeacher(string id)
        {
            if (TeacherDeleteEvent!=null)
                TeacherDeleteEvent.Invoke(id);
        }
    }
}
