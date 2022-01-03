using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.Repositories
{
    public class DisplayedEmployments
    {
        private List<EmploymentDisplayName> empoylements;

        public List<EmploymentDisplayName> Empoylements
        {
            get => empoylements;
            set => empoylements = value;
        }

        public DisplayedEmployments()
        {
            empoylements = new List<EmploymentDisplayName>();
            MakeEmploymentList();
        }

        public void MakeEmploymentList()
        {
            empoylements.Add(new EmploymentDisplayName("óraadó"));
            empoylements.Add(new EmploymentDisplayName("állandó megbízásos rendelkező"));
            empoylements.Add(new EmploymentDisplayName("szerződéses alkalmazott"));

        }
        public List<EmploymentDisplayName> GetEmployments()
        {
            return empoylements;
        }
    }
}
