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
    /// Interaction logic for DealsPage.xaml
    /// </summary>
    public partial class DealsPage : Page
    {
        public List<Deal> Deals { get; set; }
        public DealsPage()
        {
            InitializeComponent();
            Deals = DataAccess.GetDeals();
            DataAccess.RefreshListsEvent += DataAccess_RefreshListsEvent;
            DataContext = this;
        }

        private void DataAccess_RefreshListsEvent()
        {
            Deals = DataAccess.GetDeals();
            lvDeals.ItemsSource = Deals;
            lvDeals.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DealPage(new Deal()));
        }

        private void lvDeals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var deal = (Deal)lvDeals.SelectedItem;
            if (deal != null) 
                NavigationService.Navigate(new DealPage(deal));
        }

        private void dpCompilationDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dpCompilationDate.SelectedDate != null)
            {
                lvDeals.ItemsSource = Deals.FindAll(x => x.CompilationDate== dpCompilationDate.SelectedDate);
            }
            else
            {
                lvDeals.ItemsSource = Deals;
            }
            lvDeals.Items.Refresh();
        }
    }
}
