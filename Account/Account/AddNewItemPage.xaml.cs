using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AddNewItemPage : Page
    {
        public AddNewItemPage()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void others_Click(object sender, RoutedEventArgs e)
        {

        }

        private void phone_Click(object sender, RoutedEventArgs e)
        {

        }

        private void utilities_Click(object sender, RoutedEventArgs e)
        {

        }

        private void social_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void traffic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shopping_Click(object sender, RoutedEventArgs e)
        {

        }

        private void medical_Click(object sender, RoutedEventArgs e)
        {

        }

        private void education_Click(object sender, RoutedEventArgs e)
        {

        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Details));
        }
    }
}
