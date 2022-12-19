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
using EmloymentAgency.Pages;

namespace EmloymentAgency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new VacanciesPage());
            mainFrame.Navigated += MainFrame_Navigated;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            tbPageTitle.Text = (mainFrame.Content as Page).Title;
        }

        private void btnVacancies_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new VacanciesPage());
        }

        private void btnEmployers_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new EmployersPage());
        }

        private void btnApplicants_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new ApplicantsPage());
        }

        private void btnDeals_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new DealsPage());
        }
    }
}
