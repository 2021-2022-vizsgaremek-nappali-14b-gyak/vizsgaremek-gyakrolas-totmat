using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models
{
    public class EmploymentDisplayName
    {
        string employmentName;

        public string EmploymentName
        {
            get => employmentName;
            set => employmentName = value;
        }

        public EmploymentDisplayName(string employmentName)
        {
            this.employmentName = employmentName;
        }       
    }
}
