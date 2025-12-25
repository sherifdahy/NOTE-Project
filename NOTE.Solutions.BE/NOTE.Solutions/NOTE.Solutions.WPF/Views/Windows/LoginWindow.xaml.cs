using Mapster;
using Microsoft.Extensions.DependencyInjection;
using NOTE.Solutions.WPF.DTOs.Auth.Requests;
using NOTE.Solutions.WPF.Interfaces;
using NOTE.Solutions.WPF.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace NOTE.Solutions.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow(LoginViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = passwordBox.Password;

            await _viewModel.LoginCommand.ExecuteAsync(null);
        }
    }


}
