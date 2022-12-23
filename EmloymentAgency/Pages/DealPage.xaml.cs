using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Word = Microsoft.Office.Interop.Word;

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
            {
                Deal.CompilationDate = DateTime.Now;
                Deal.Comission = 3000;
                Title = "Новая сделка";
                btnPrint.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else
            {
                Title = $"Сделка №{Deal.Id}";
                IsEnabled = false;
            }


            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                if (Deal.PaymentDate < Deal.CompilationDate)
                    stringBuilder.AppendLine("Да оплаты не может быть меньше даты формирования");

                if (stringBuilder.Length > 0)
                    throw new Exception();

                DataAccess.SaveDeal(Deal);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка");
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            ReportService.ExportToWord(Deal);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выбранная сделка будет удален. Продолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                DataAccess.DeleteDeal(Deal);
                NavigationService.GoBack();
            }
        }

        private void cbVacancy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbEmployer.SelectedItem = (cbVacancy.SelectedItem as Vacancy).Employer;
        }
    }
}
