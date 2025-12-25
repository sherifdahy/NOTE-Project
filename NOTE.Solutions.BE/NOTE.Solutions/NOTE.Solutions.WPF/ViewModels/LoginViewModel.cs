using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using NOTE.Solutions.WPF.DTOs.Auth.Requests;
using NOTE.Solutions.WPF.Interfaces;
using NOTE.Solutions.WPF.Views;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace NOTE.Solutions.WPF.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private readonly IAuthService _authService;

        private readonly IServiceProvider _serviceProvider;

        public LoginViewModel(IAuthService authService,IServiceProvider serviceProvider)
        {
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        // Command for Login
        public IAsyncRelayCommand LoginCommand => new AsyncRelayCommand(LoginAsync);

        private async Task LoginAsync()
        {
            var request = new LoginRequest
            {
                Email = Email,
                Password = Password
            };

            var result = await _authService.GetTokenAsync(request);

            if (result.IsSuccess)
            {
                var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();

                Application.Current.MainWindow?.Close();
            }
            else
            {
                MessageBox.Show(
                    result.Error?.Description ?? "Login failed",
                    $"Error {result.Error?.Code}",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

    }
}
