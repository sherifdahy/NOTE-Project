using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class ReceiptsViewModel : ObservableObject
    {
        // List of receipts
        public ObservableCollection<ReceiptViewModel> Receipts { get; set; } = new();

        private ReceiptViewModel _selectedReceipt;
        public ReceiptViewModel SelectedReceipt
        {
            get => _selectedReceipt;
            set => SetProperty(ref _selectedReceipt, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                // ممكن هنا تعمل filter على Receipts حسب SearchText
            }
        }

        // Pagination
        private int _pageIndex = 0;
        public int PageIndex
        {
            get => _pageIndex;
            set => SetProperty(ref _pageIndex, value);
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => SetProperty(ref _pageSize, value);
        }

        private int _totalCount = 0;
        public int TotalCount
        {
            get => _totalCount;
            set => SetProperty(ref _totalCount, value);
        }

        // Commands
        public IRelayCommand LoadPageCommand { get; }
        public IRelayCommand DeleteAllCommand { get; }
        public IRelayCommand AddNewCommand { get; }
        public IRelayCommand<ReceiptViewModel> DeleteCommand { get; }

        public ReceiptsViewModel()
        {
            LoadPageCommand = new RelayCommand(LoadPage);
            DeleteAllCommand = new RelayCommand(DeleteAll);
            AddNewCommand = new RelayCommand(AddNew);
            DeleteCommand = new RelayCommand<ReceiptViewModel>(Delete);

            // Test data
            for (int i = 1; i <= 25; i++)
            {
                Receipts.Add(new ReceiptViewModel
                {
                    Id = i,
                    Number = $"R-{i:000}",
                    CustomerName = $"عميل {i}",
                    Amount = 100 + i * 10
                });
            }

            TotalCount = Receipts.Count;
        }

        private void LoadPage()
        {
            // هنا هتجيب البيانات من API مع Pagination
        }

        private void DeleteAll()
        {
            Receipts.Clear();
            TotalCount = 0;
        }

        private void AddNew()
        {
            // ممكن تنقل لصفحة NewReceiptControl
        }

        private void Delete(ReceiptViewModel receipt)
        {
            if (receipt != null)
            {
                Receipts.Remove(receipt);
                TotalCount = Receipts.Count;
            }
        }
    }
}
