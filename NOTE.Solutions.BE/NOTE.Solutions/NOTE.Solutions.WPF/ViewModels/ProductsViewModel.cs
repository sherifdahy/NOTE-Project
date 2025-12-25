using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NOTE.Solutions.WPF.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class ProductsViewModel : ObservableObject
    {
        // =============================
        // Data
        // =============================
        public ObservableCollection<ProductViewModel> Products { get; } = new();

        private ProductViewModel _selectedProduct;
        public ProductViewModel SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        // =============================
        // State
        // =============================
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        // =============================
        // Commands
        // =============================
        public IAsyncRelayCommand LoadProductsCommand { get; }
        public IAsyncRelayCommand<ProductViewModel> DeleteCommand { get; }

        // =============================
        // Services
        // =============================
        private readonly IProductService _productService;

        // =============================
        // Constructor
        // =============================
        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;

            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);
            DeleteCommand = new AsyncRelayCommand<ProductViewModel>(DeleteAsync);
        }

        // =============================
        // Logic
        // =============================
        private async Task LoadProductsAsync()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = null;

                Products.Clear();

                var products = await _productService.GetAllAsync(branchId: 1);

                MessageBox.Show(products.Count.ToString());

            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task DeleteAsync(ProductViewModel product)
        {
            //if (product == null)
            //    return;

            //await _productService.(product.Id);

            //Products.Remove(product);
        }
    }
}
