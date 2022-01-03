using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Vizsgaremek.ProgramNavigation;
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class TeacherPage : UserControl
    {

        private TeacherPageViewModel teacherPageViewModel;
        

        public TeacherPage(TeacherPageViewModel teacherPageViewModel)
        {

            this.teacherPageViewModel = teacherPageViewModel;
            InitializeComponent();
            DataContext = teacherPageViewModel;
            //teacherPageViewModel.DisplayedTeachers.Clear();
            //dgTeachers.ItemsSource = teacherPageViewModel.DisplayedTeachers;

        }

        private void UpdatePageBackImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            Navigation.Navigate(welcomePage);           
        }

        private void DgTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTeachers.SelectedIndex < 0)
            {
                // insert/update/delete stack panel visibility
                // teacherViewModel.IsRowSelectedInDataGrid = true;
                //ctTeacher.Visibility = Visibility.Hidden;              
            }
            else
            {
                //teacherViewModel.IsRowSelectedInDataGrid = false;
                //ctTeacher.Visibility = Visibility.Visible;
                ctTeacher.ModifyTeacherInTeacherControlViewModel(teacherPageViewModel.TeacherControlViewModels,teacherPageViewModel.SelectedTeacher);
            }
        }


    }
}
