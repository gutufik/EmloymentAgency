using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (Vacancy.Id == 0)
            {
                Title = "Новая вакансия";
                btnClose.Visibility = Visibility.Collapsed;
            }
            else
                Title = $"Вакансия №{Vacancy.Id}";

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                if (Vacancy.MaxPayment < Vacancy.MinPayment)
                    stringBuilder.AppendLine("Максисальная оплата не может быть меньше минимальной");
                if (Vacancy.MaxPayment < 0 || Vacancy.MinPayment <0)
                    stringBuilder.AppendLine("Оплата не может быть отрицательной");

                if (stringBuilder.Length > 0)
                    throw new Exception();

                DataAccess.SaveVacancy(Vacancy);
                NavigationService.GoBack();

            }
            catch
            {
                MessageBox.Show(stringBuilder.ToString(), "Ошибка");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.CloseVacancy(Vacancy);
            NavigationService.GoBack();
        }
    }
}
