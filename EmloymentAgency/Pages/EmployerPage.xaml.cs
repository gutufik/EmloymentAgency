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
    /// Interaction logic for EmployerPage.xaml
    /// </summary>
    public partial class EmployerPage : Page
    {
        public List<ActivityType> ActivityTypes { get; set; }
        public Employer Employer { get; set; }
        public EmployerPage(Employer employer)
        {
            InitializeComponent();
            ActivityTypes = DataAccess.GetActivityTypes();
            Employer = employer;
            if (Employer.Id == 0)
                Title = "НовЫй раболтодатель";
            else
                Title = $"Работодатель №{Employer.Name}";

            DataContext = this;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveEmployer(Employer);
            NavigationService.GoBack();
        }
    }
}
