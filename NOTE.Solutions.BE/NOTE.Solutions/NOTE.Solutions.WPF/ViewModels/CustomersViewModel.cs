using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class CustomersViewModel : ObservableObject
    {
        // قائمة العملاء
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = new();

        // العنصر المحدد في الجدول
        private CustomerViewModel _selectedCustomer;
        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        // البحث
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        // Pagination
        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                if (SetProperty(ref _pageIndex, value))
                {
                    // هنا ممكن تحمل بيانات الصفحة الجديدة
                }
            }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => SetProperty(ref _pageSize, value);
        }

        private int _totalCount;
        public int TotalCount
        {
            get => _totalCount;
            set => SetProperty(ref _totalCount, value);
        }

        // Commands
        public IRelayCommand<CustomerViewModel> DeleteCommand { get; }
        public IRelayCommand DeleteAllCommand { get; }
        public IRelayCommand ImportExcelCommand { get; }

        public CustomersViewModel()
        {
            DeleteCommand = new RelayCommand<CustomerViewModel>(OnDelete);
            DeleteAllCommand = new RelayCommand(OnDeleteAll);
            ImportExcelCommand = new RelayCommand(OnImportExcel);

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            // TODO: تحميل العملاء من API خارجي
        }

        private void OnDelete(CustomerViewModel customer)
        {
            // TODO: حذف عميل
        }

        private void OnDeleteAll()
        {
            // TODO: حذف كل العملاء
        }

        private void OnImportExcel()
        {
            // TODO: استيراد من Excel
        }
    }
}
