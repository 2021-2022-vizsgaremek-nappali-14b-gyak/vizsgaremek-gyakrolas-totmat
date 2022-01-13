using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;

namespace Vizsgaremek.ViewModels
{
    // ViewModell réteg
    // A megjeleítendő adatokat kell megadni itt
    class ProgramInfoViewModel
    {
        private ProgramInfo programInfo;
        public string Version 
        { 
            get
            {
                return programInfo.Version.ToString();
            }
            set
            {
                Version = value;
            }
        }

        public string Title { get => programInfo.Title; set => Title = value; }
        public string Description { get => programInfo.Description; set => Description = value; }
        public string Company { get => programInfo.Company; set => Company = value; }

        public string Authors
        {
            get
            {
                return programInfo.Authors;
            }
            set
            {
                Authors = value;
            }
        }

        public ProgramInfoViewModel()
        {
            programInfo = new ProgramInfo();
        }
    }
}
