using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vizsgaremek.Pages;
using Vizsgaremek.ProgramNavigation;
using Vizsgaremek.Stores;
using Vizsgaremek.ViewModels;

namespace Vizsgaremek.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeacherStore teacherStore;
        TeacherPageViewModel teacherPageViewModel;
        
        
        ResourceDictionary dict;

        public MainWindow()
        {
            dict = new ResourceDictionary();
            SetLanguageDictionary();

            InitializeComponent();
            DataContext = this;
            Navigation.mainWindow = this;

            teacherStore = new TeacherStore();



            WelcomePage welcomePage = new WelcomePage();
            Navigation.Navigate(welcomePage);
        }

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView menuListView = sender as ListView;
            ListViewItem item = (ListViewItem)menuListView.SelectedItem;
            if (item != null)
            {
                switch (item.Name)
                {
                    case "lviExit":
                        this.Close();
                        break;
                    case "lviProgramUpdate":
                        UpdateProgramVersionPage updateProgramVersionPage = new UpdateProgramVersionPage();


                        Navigation.Navigate(updateProgramVersionPage);
                        break;
                    case "lviTeacher":
                        TeacherControlViewModel teacherControlViewModel = new TeacherControlViewModel(teacherStore);                        
                        teacherPageViewModel = new TeacherPageViewModel(teacherStore, teacherControlViewModel);
                        TeacherPage teacherPage = new TeacherPage(teacherPageViewModel);

                        Navigation.Navigate(teacherPage);
                        break;
                }
            }
        }

        private void SetLanguageDictionary()
        {

            switch (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;

                case "fr":
                    dict.Source = new Uri("..\\Resources\\FR\\StringResources.xaml", UriKind.Relative);
                    break;
                case "hu":
                    dict.Source = new Uri("..\\Resources\\HU\\StringResources.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}
