using NOTE.Solutions.WPF.ViewModels;
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

namespace NOTE.Solutions.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        public ProductsControl(ProductsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            this.Loaded += ProductsControl_Loaded;
        }

        private async void ProductsControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ProductsViewModel vm)
            {
                await vm.LoadProductsCommand.ExecuteAsync(null);
            }
        }
    }

}
