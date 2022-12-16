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
    /// Interaction logic for VacancyPage.xaml
    /// </summary>
    public partial class VacancyPage : Page
    {
        public List<Employer> Employers { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public Vacancy Vacancy { get; set; }

        public VacancyPage(Vacancy vacancy)
        {
            InitializeComponent();
            Vacancy = vacancy;
            Employers = DataAccess.GetEmployers();
            Qualifications = DataAccess.GetQualifications();

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveVacancy(Vacancy);
            NavigationService.GoBack();
        }
    }
}
