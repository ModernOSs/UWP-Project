using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                if (ApplicationData.Current.RoamingSettings.Values.ContainsKey("username") &&
                    ApplicationData.Current.RoamingSettings.Values.ContainsKey("password"))
                    tryLogin((string)ApplicationData.Current.RoamingSettings.Values["username"],
                             (string)ApplicationData.Current.RoamingSettings.Values["password"]);
            }
        }

        private void clear()
        {
            username.Text = "";
            username_.Text = "";
            password.Password = "";
            password_.Password = "";
            loginErr.Text = "";
            registerErr.Text = "";
        }

        private async void tryLogin(string username, string password)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("username", username);
                httpClient.DefaultRequestHeaders.Add("password", password);
                progressBar.Opacity = 1;
                // 发送POST请求
                HttpResponseMessage response = await httpClient.PostAsync("http://119.29.232.29:3000", new StringContent(""));
                // 确保返回值为成功状态
                response.EnsureSuccessStatusCode();
                Byte[] getByte = await response.Content.ReadAsByteArrayAsync();
                string returnContent = await response.Content.ReadAsStringAsync();
                if (returnContent == "success")
                {
                    App.user = new Models.User(username, password);
                    if (auto.IsChecked == true)
                    {
                        ApplicationData.Current.RoamingSettings.Values["username"] = username;
                        ApplicationData.Current.RoamingSettings.Values["password"] = password;
                    }
                    else
                    {
                        ApplicationData.Current.RoamingSettings.Values.Clear();
                    }
                    Frame.Navigate(typeof(MainPage));
                }
                else if (returnContent == "no user")
                {
                    progressBar.Opacity = 0;
                    loginErr.Text = "用户不存在";
                }  
                else
                {
                    progressBar.Opacity = 0;
                    loginErr.Text = "用户名密码错误";
                }  
            }
            catch (HttpRequestException ex1)
            {
                Debug.WriteLine(ex1.ToString());
            }
            catch (Exception ex2)
            {
                Debug.WriteLine(ex2.ToString());
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            tryLogin(username.Text, password.Password);
        }

        private void toRegister_Click(object sender, RoutedEventArgs e)
        {
            loginView.Visibility = Visibility.Collapsed;
            registerView.Visibility = Visibility.Visible;
            clear();
        }

        private void toLogin_Click(object sender, RoutedEventArgs e)
        {
            loginView.Visibility = Visibility.Visible;
            registerView.Visibility = Visibility.Collapsed;
            clear();
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("username", username_.Text);
                httpClient.DefaultRequestHeaders.Add("password", password_.Password);
                // 发送POST请求
                HttpResponseMessage response = await httpClient.PostAsync("http://119.29.232.29:3000/register", new StringContent(""));
                // 确保返回值为成功状态
                response.EnsureSuccessStatusCode();
                Byte[] getByte = await response.Content.ReadAsByteArrayAsync();
                string returnContent = await response.Content.ReadAsStringAsync();
                if (returnContent == "success")
                {
                    loginView.Visibility = Visibility.Visible;
                    registerView.Visibility = Visibility.Collapsed;
                    clear();
                    loginErr.Text = "注册成功";
                }
                else if (returnContent == "already exists")
                    registerErr.Text = "该用户已存在";
            }
            catch (HttpRequestException ex1)
            {
                Debug.WriteLine(ex1.ToString());
            }
            catch (Exception ex2)
            {
                Debug.WriteLine(ex2.ToString());
            }
        }
    }
}
