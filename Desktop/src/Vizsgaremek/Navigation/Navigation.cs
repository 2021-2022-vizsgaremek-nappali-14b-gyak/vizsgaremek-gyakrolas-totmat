using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Vizsgaremek.Views;

namespace Vizsgaremek.ProgramNavigation
{
    public static class Navigation
    {
        public static MainWindow mainWindow;

        public static void Navigate(UserControl userControl)
        {
            mainWindow.PageContent.Children.Clear();
            mainWindow.PageContent.Children.Add(userControl);
        }

        public static void NavigateToFullPage(Page userPage)
        {
            mainWindow.Content = userPage;
        }
    }
}
