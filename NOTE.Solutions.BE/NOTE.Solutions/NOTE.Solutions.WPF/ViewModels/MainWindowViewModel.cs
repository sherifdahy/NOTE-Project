using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using NOTE.Solutions.WPF.Views;
using NOTE.Solutions.WPF.Views.UserControls;
using NOTE.Solutions.WPF.Views.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        // الصفحة الحالية
        private UserControl _currentPage;
        public UserControl CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        // عنوان الصفحة
        private string _currentTitle;
        public string CurrentTitle
        {
            get => _currentTitle;
            set => SetProperty(ref _currentTitle, value);
        }

        // Visibility لكل StackPanel
        private Visibility _productsStackVisibility = Visibility.Collapsed;
        public Visibility ProductsStackVisibility
        {
            get => _productsStackVisibility;
            set => SetProperty(ref _productsStackVisibility, value);
        }

        private Visibility _customersStackVisibility = Visibility.Collapsed;
        public Visibility CustomersStackVisibility
        {
            get => _customersStackVisibility;
            set => SetProperty(ref _customersStackVisibility, value);
        }

        private Visibility _receiptsStackVisibility = Visibility.Collapsed;
        public Visibility ReceiptsStackVisibility
        {
            get => _receiptsStackVisibility;
            set => SetProperty(ref _receiptsStackVisibility, value);
        }

        // Commands
        public IRelayCommand<string> NavigateCommand { get; }
        public IRelayCommand<string> ToggleStackCommand { get; }

        // Dropdown test properties
        private string _loggedUserEmail = "test@example.com";
        public string LoggedUserEmail
        {
            get => _loggedUserEmail;
            set => SetProperty(ref _loggedUserEmail, value);
        }

        public IRelayCommand OpenAccountCommand { get; }
        public IRelayCommand LogoutCommand { get; }

        private readonly IServiceProvider _serviceProvider;
        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            NavigateCommand = new RelayCommand<string>(Navigate);
            ToggleStackCommand = new RelayCommand<string>(ToggleStack);

            LogoutCommand = new RelayCommand(() =>
            {
                MessageBox.Show(" تسجيل الخروج (تجريبي)");
            });

            Navigate("Home");
        }

        private void Navigate(string pageName)
        {
            switch (pageName)
            {
                case "Home":
                    CurrentPage = _serviceProvider.GetRequiredService<HomeControl>();
                    CurrentTitle = "الرئيسية";
                    break;

                case "AccountControl":
                    CurrentPage = _serviceProvider.GetRequiredService<AccountControl>();
                    CurrentTitle = "الحساب";
                    break;

                case "CustomersControl":
                    CurrentPage = _serviceProvider.GetRequiredService<CustomersControl>();
                    CurrentTitle = "العملاء";
                    break;

                case "ItemsControl":
                    CurrentPage = _serviceProvider.GetRequiredService<ProductsControl>();
                    CurrentTitle = "السلع";
                    break;

                case "NewProductControl":
                    CurrentPage = _serviceProvider.GetRequiredService<NewProductControl>();
                    CurrentTitle = "اضافة منتج جديد";
                    break;

                case "ReceiptsControl":
                    CurrentPage = _serviceProvider.GetRequiredService<ReceiptsControl>();
                    CurrentTitle = "حافظة الايصالات";
                    break;
            }
        }

        private void ToggleStack(string stackName)
        {
            switch (stackName)
            {
                case "Products":
                    ProductsStackVisibility =
                        ProductsStackVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    CustomersStackVisibility = Visibility.Collapsed;
                    ReceiptsStackVisibility = Visibility.Collapsed;
                    break;

                case "Customers":
                    CustomersStackVisibility =
                        CustomersStackVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    ProductsStackVisibility = Visibility.Collapsed;
                    ReceiptsStackVisibility = Visibility.Collapsed;
                    break;

                case "Receipts":
                    ReceiptsStackVisibility =
                        ReceiptsStackVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    ProductsStackVisibility = Visibility.Collapsed;
                    CustomersStackVisibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
