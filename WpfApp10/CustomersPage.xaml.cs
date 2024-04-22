using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp10
{
    public partial class CustomersPage : Page
    {
        private CarShowroom3Entities context = new CarShowroom3Entities();

        public CustomersPage()
        {
            InitializeComponent();
            Loaded += Page_Loaded;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            customersDgr.Columns[6].Visibility = Visibility.Collapsed;
            customersDgr.ItemsSource = context.Customers.ToList();
            Cbx.ItemsSource = context.Customers.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            customersDgr.ItemsSource = context.Customers.ToList().Where(item => item.Email.Contains(text_search.Text));
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            customersDgr.ItemsSource = context.Customers.ToList();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var selected = (Customers)Cbx.SelectedItem;
                customersDgr.ItemsSource = context.Customers.ToList().Where(item => item.CustomerSurname == selected.CustomerSurname);
            }
        }
    }
}
