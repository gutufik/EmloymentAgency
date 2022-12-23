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
    /// Interaction logic for ApplicantsPage.xaml
    /// </summary>
    public partial class ApplicantsPage : Page
    {
        public List<Applicant> Applicants { get; set; }
        public List<Applicant> ApplicantsForFilters { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public ApplicantsPage()
        {
            InitializeComponent();
            Applicants = DataAccess.GetApplicants();
            ApplicantsForFilters = Applicants.ToList();
            Qualifications = DataAccess.GetQualifications();
            Qualifications.Insert(0, new Qualification { Name = "Все" });

            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Applicants = DataAccess.GetApplicants();
            lvApplicants.ItemsSource = Applicants;
            lvApplicants.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicantPage(new Applicant()));
        }

        private void lvApplicants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var applicant = (Applicant)lvApplicants.SelectedItem;
            if (applicant != null)
                NavigationService.Navigate(new ApplicantPage(applicant));
        }

        private void ApplyFilters()
        {
            if (cbQualification.SelectedItem != null)
            {
                var qualification = cbQualification.SelectedItem as Qualification;
                var searchText = tbSearch.Text.ToLower();

                ApplicantsForFilters = Applicants.FindAll(x => x.FirstName.ToLower().Contains(searchText) ||
                    x.LastName.ToLower().Contains(searchText) ||
                    x.Patronymic.ToLower().Contains(searchText));

                if (qualification.Name != "Все")
                    ApplicantsForFilters = ApplicantsForFilters.FindAll(x => x.Qualification == qualification);

                lvApplicants.ItemsSource = ApplicantsForFilters;
                lvApplicants.Items.Refresh();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cbQualification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}
