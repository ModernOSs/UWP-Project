using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("username", username.Text);
                httpClient.DefaultRequestHeaders.Add("password", password.Text);
                //发送POST请求
                HttpResponseMessage response = await httpClient.PostAsync("http://119.29.232.29:3000", new StringContent(""));
                // 确保返回值为成功状态
                response.EnsureSuccessStatusCode();
                Byte[] getByte = await response.Content.ReadAsByteArrayAsync();
                string returnContent = await response.Content.ReadAsStringAsync();
                if (returnContent == "success")
                {
                    Frame.Navigate(typeof(MainPage));
                }
                App.user = new Models.User(username.Text, password.Text);
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
