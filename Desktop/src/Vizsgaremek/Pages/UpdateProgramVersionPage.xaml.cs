using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

using Octokit;
using Microsoft.Win32;
using Vizsgaremek.ProgramNavigation;
using System.Threading.Tasks;
using System.Net;

namespace Vizsgaremek.Pages
{
    /// <summary>
    /// Interaction logic for UpdateProgramVersionPage.xaml
    /// </summary>
    /// https://www.youtube.com/watch?v=nwsEi0JZM3k&list=WL&index=8
    public partial class UpdateProgramVersionPage : UserControl
    {

        //Get all releases from GitHub
        //Source: https://octokitnet.readthedocs.io/en/latest/getting-started/
        private readonly int repoId = 424281854;
        private readonly string reponame = "2020-2021-vizsgaremek-nappali-14b-gyuris-csaba";

        Version githubVerzio;
        Version helyiVezrio;
        string letoltesiURL;
        char desktopVerzioPrefix = 'd';

        public UpdateProgramVersionPage()
        {
            githubVerzio = null;
            helyiVezrio = null;
            letoltesiURL = string.Empty;
            InitializeComponent();
            Loaded += UpdateProgramVersionPage_Loaded;

        }

        private void UpdatePageBackImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WelcomePage welcomePage = new WelcomePage();
            Navigation.Navigate(welcomePage);
        }
        private async void UpdateProgramVersionPage_Loaded(object sender, RoutedEventArgs e)
        {           
            FejlesztokAdatainakMegjelenitese();
            HelyiVerzioSzamMegjelenitese();
        }

        private async void HelyiVerzioSzamMegjelenitese()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyVerzio = assembly.GetName().Version;
            helyiVezrio = assemblyVerzio;
            txtHelyiVerzio.Text = desktopVerzioPrefix + helyiVezrio.ToString();
        }

        private async void FejlesztokAdatainakMegjelenitese()
        {
            var kliens = new GitHubClient(new ProductHeaderValue(reponame));

            // fejlesztők meghatározása
            var fejlesztok = await kliens.Repository.GetAllContributors(repoId);
            string fejlesztokNevei = string.Empty;
            foreach (var fejleszto in fejlesztok)
            {
                string fejlesztoLoginAzonosito = fejleszto.Login;
                var user = await kliens.User.Get(fejlesztoLoginAzonosito);
                fejlesztokNevei += user.Name + " (" + user.Login + ") ";
            }
            txtCollaborators.Text = fejlesztokNevei;

            // Még fejlesztésre vár
            //Uri repoURL = await kliens.Repository.
            tbGithubRepoURL.Text = "https://github.com/2021-2022-vizsgaremek-nappali-14b/2020-2021-vizsgaremek-nappali-14b-gyuris-csaba";
        }

        private void btAktualisVerzioEllenorzes_Click(object sender, RoutedEventArgs e)
        {
            GithubVerzioMegjelenitese();
        }

        private async void GithubVerzioMegjelenitese()
        {
            var kliens = new GitHubClient(new ProductHeaderValue(reponame));
            // utolsó release meghatározása
            var desktopProagramKiadasok = await kliens.Repository.Release.GetAll(repoId);
            var utolsoDesktopProgramKiadas = desktopProagramKiadasok[0];

            // utolsó release letöltési URLjének meghatározása
            letoltesiURL = utolsoDesktopProgramKiadas.Assets[0].BrowserDownloadUrl;
            
            // GitHub verzió meghatározása
            tbGithubVerzio.Text = utolsoDesktopProgramKiadas.Name;
            string utolsoVerzioPrefixNelkul = utolsoDesktopProgramKiadas.Name.Remove(0, 1);
            githubVerzio = new Version(utolsoVerzioPrefixNelkul);
            // Helyi és GitHub verió összehasonlítása
            await HelyiEsGithubVerzioOsszehasonlitasa();
        }
            
        private async System.Threading.Tasks.Task HelyiEsGithubVerzioOsszehasonlitasa()
        {

            //Compare the Versions
            //Source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
            int helyiVerzioNagyobbGithubVerzio = helyiVezrio.CompareTo(githubVerzio);
            if (helyiVerzioNagyobbGithubVerzio < 0)
            {
                btUjVerzioLetoltes.IsEnabled = true;
            }
            else if (helyiVerzioNagyobbGithubVerzio < 0)
            {
               
            }
            else
            {
                
            }
        }

        private async void btUjVerzioLetoltes_Click(object sender, RoutedEventArgs e)
        {
            // https://csharp.hotexamples.com/examples/Octokit/Release/-/php-release-class-examples.html
            SaveFileDialog mentesDialogus = new SaveFileDialog();
            string fajlNev = MeghatarozFajlNevetLetoltesiURLbol(letoltesiURL);
            mentesDialogus.FileName = fajlNev;
            if (mentesDialogus.ShowDialog()==true)
            {
                
                
                //https://stackoverflow.com/questions/67486790/download-asset-from-private-github-repository-release-with-octokit-net
                // https://smarterco.de/download-latest-version-from-github-with-curl/
                // https://stackoverflow.com/questions/69771638/c-sharp-webclient-cannot-download-api-github-com-pages
                //https://stackoverflow.com/questions/67486790/download-asset-from-private-github-repository-release-with-octokit-net
                var webclient = new WebClient();
                webclient.Headers.Add("user-agent", "request");                
               
                Uri kiadasURI = new Uri(letoltesiURL);
                webclient.DownloadFileAsync(kiadasURI,  mentesDialogus.FileName);
                

            }    
        }

        private string MeghatarozFajlNevetLetoltesiURLbol(string letoltesiURL)
        {
            string fajlNev = letoltesiURL.Substring(letoltesiURL.LastIndexOf("/")+1, letoltesiURL.Length - letoltesiURL.LastIndexOf("/")-1);
            return fajlNev;
        }

        private void repourl_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

        }

    }
}
