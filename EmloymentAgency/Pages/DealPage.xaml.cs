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
    /// Interaction logic for DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        public Deal Deal { get; set; }
        public List<Applicant> Applicants { get; set; }
        public List<Vacancy> Vacancies { get; set; }
        public List<Agent> Agents { get; set; }
        public List<Employer> Employers { get; set; }

        public DealPage(Deal deal)
        {
            InitializeComponent();
            Deal = deal;
            Applicants = DataAccess.GetApplicants();
            Vacancies = DataAccess.GetVacancies();
            Agents = DataAccess.GetAgents();
            Employers = DataAccess.GetEmployers();
            if (Deal.Id == 0)
                Title = "Новая сделка";
            else
                Title = $"Вакансия №{Deal.Id}";


            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveDeal(Deal);
            NavigationService.GoBack();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
