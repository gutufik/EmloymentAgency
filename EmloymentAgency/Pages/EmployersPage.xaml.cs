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
using Core;

namespace EmloymentAgency.Pages
{
    /// <summary>
    /// Interaction logic for EmployersPage.xaml
    /// </summary>
    public partial class EmployersPage : Page
    {
        public List<Employer> Employers { get; set; }
        public List<Employer> EmployersForSearch { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }
        public EmployersPage()
        {
            InitializeComponent();
            Employers = DataAccess.GetEmployers();
            EmployersForSearch = Employers.ToList();
            ActivityTypes = DataAccess.GetActivityTypes();
            ActivityTypes.Insert(0, new ActivityType() { Name = "Все" });

            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Employers = DataAccess.GetEmployers();
            lvEmployers.ItemsSource = Employers;
            lvEmployers.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployerPage(new Employer()));
        }

        private void lvEmployers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var employer = lvEmployers.SelectedItem as Employer;
            if (employer != null)
                NavigationService.Navigate(new EmployerPage(employer));
        }

        private void ApllyFilters()
        {
            if (cbActivityType.SelectedItem != null)
            {
                var activityType = cbActivityType.SelectedItem as ActivityType;
                var searchText = tbSearch.Text.ToLower();

                EmployersForSearch = Employers.FindAll(x => x.Name.ToLower().Contains(searchText));

                if (activityType.Name != "Все")
                    EmployersForSearch = EmployersForSearch.FindAll(x => x.ActivityType == activityType);

                lvEmployers.ItemsSource = EmployersForSearch;
                lvEmployers.Items.Refresh();
            }
        }

        private void cbActivityType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApllyFilters();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApllyFilters();
        }
    }
}
