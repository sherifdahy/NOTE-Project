using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class ReceiptViewModel : ObservableObject
    {
        // خصائص الايصال
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _number;
        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        // Commands
        public IRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }

        public ReceiptViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            // هنا ممكن تضيف منطق حفظ الايصال (API call)
            // مثلا: ارسال بيانات ReceiptViewModel الى API
        }

        private void Cancel()
        {
            // ممكن ترجع للصفحة السابقة أو تمسح القيم
            Number = string.Empty;
            CustomerName = string.Empty;
            Amount = 0;
        }
    }
}
