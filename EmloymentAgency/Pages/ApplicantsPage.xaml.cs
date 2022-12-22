﻿using System;
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
        public ApplicantsPage()
        {
            InitializeComponent();
            Applicants = DataAccess.GetApplicants();
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
    }
}
