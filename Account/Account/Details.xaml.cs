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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Details : Page
    {
        Models.IncomesList incomesList { set; get; }

        public class FinancialStuff
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartContents();
        }

        public Details()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            this.incomesList = App.user.incomesList;
            NavigationCacheMode = NavigationCacheMode.Enabled;
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 改回顶栏的颜色
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;
        }

        private void LoadChartContents()
        {
            Random rand = new Random();
            List<FinancialStuff> financialStuffList = new List<FinancialStuff>();
            financialStuffList.Add(new FinancialStuff() { Name = "JAN", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "FEB", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "MAR", Amount = rand.Next(0, 200) });
            financialStuffList.Add(new FinancialStuff() { Name = "APR", Amount = rand.Next(0, 200) });
            (PieChart.Series[0] as PieSeries).ItemsSource = financialStuffList;
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = financialStuffList;
        }

        private void addNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewItemPage));
        }
    }
}
