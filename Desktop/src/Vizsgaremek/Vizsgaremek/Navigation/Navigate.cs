using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vizsgaremek.Navigation
{
    class Navigate
    {
        private static MainWindow mainWindow;

        public static void Navigation(UserControl userControl)
        {
            mainWindow.PageContent.Children.Add(userControl);
        }
    }
}
