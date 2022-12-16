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
    /// Interaction logic for VacanciesPage.xaml
    /// </summary>
    public partial class VacanciesPage : Page
    {
        public List<Vacancy> Vacancies { get; set; }
        public List<Vacancy> VacanciesForFilters { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }
        public List<Employer> Employers { get; set; }

        public VacanciesPage()
        {
            InitializeComponent();
            Vacancies = DataAccess.GetVacancies();
            VacanciesForFilters = Vacancies.ToList();

            ActivityTypes = DataAccess.GetActivityTypes();
            ActivityTypes.Insert(0, new ActivityType() { Name = "Все" });

            Employers = DataAccess.GetEmployers();
            Employers.Insert(0, new Employer() { Name = "Все" });


            DataContext = this;
        }

        private void ApplyFilters()
        {
            if(cbActivityType.SelectedItem != null && cbEmployer.SelectedItem != null)
            {
                var activityType = cbActivityType.SelectedItem as ActivityType;
                var employer = cbEmployer.SelectedItem as Employer;
                var searchText = tbSearch.Text.ToLower();

                VacanciesForFilters = Vacancies.FindAll(x => x.Name.ToLower().Contains(searchText));

                if (activityType.Name != "Все")
                    VacanciesForFilters = VacanciesForFilters.FindAll(x => x.Employer.ActivityType == activityType);

                if (employer.Name != "Все")
                    VacanciesForFilters = VacanciesForFilters.FindAll(x => x.Employer == employer);

                lvVacancies.ItemsSource = VacanciesForFilters;
                lvVacancies.Items.Refresh();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbActivityType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbEmployer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VacancyPage(new Vacancy()));
        }

        private void lvVacancies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vacancy = lvVacancies.SelectedItem as Vacancy;
            if (vacancy != null)
                NavigationService.Navigate(new VacancyPage(vacancy));
        }
    }
}
