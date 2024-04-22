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

namespace WpfApp10
{
    public partial class BrandsPage : Page
    {
        private CarShowroom3Entities context = new CarShowroom3Entities();
        public BrandsPage()
        {
            InitializeComponent();
            brandsDgr.ItemsSource = context.Brands.ToList();
            Cbx.ItemsSource = context.Brands.ToList();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            brandsDgr.ItemsSource = context.Brands.ToList().Where(item => item.BrandName.Contains(text_search.Text));
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            brandsDgr.ItemsSource = context.Brands.ToList();
        }

        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cbx.SelectedItem != null)
            {
                var selected = Cbx.SelectedItem as Brands;
                brandsDgr.ItemsSource = context.Brands.ToList().Where(item => item.BrandName == selected.BrandName);
            }
        }
    }
}