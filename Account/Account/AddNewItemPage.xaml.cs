using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI;
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
        Dictionary<string, Models.kind> dic;
        string source;
        Models.kind k;
        Models.IncomesList incomesList { set; get; }
        DateTimeOffset OfficialDate;
        public AddNewItemPage()
        {
            this.InitializeComponent();
            this.incomesList = App.user.incomesList;
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;
            NavigationCacheMode = NavigationCacheMode.Enabled;

            //Initialize dic
            dic = new Dictionary<string, Models.kind>();
            dic.Add("餐饮", Models.kind.food);
            dic.Add("交通", Models.kind.traffic);
            dic.Add("购物", Models.kind.shopping);
            dic.Add("医疗", Models.kind.medical);
            dic.Add("旅行", Models.kind.travel);
            dic.Add("娱乐", Models.kind.fun);
            dic.Add("社交", Models.kind.contact);
            dic.Add("投资", Models.kind.money);
            dic.Add("教育", Models.kind.education);
            dic.Add("其他", Models.kind.other);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 改回顶栏的颜色
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Color.FromArgb(0, 136, 214, 255);
            viewTitleBar.ButtonBackgroundColor = Color.FromArgb(0, 136, 214, 255);
        }


        private void create_Click(object sender, RoutedEventArgs e)
        {
            double amount = Double.Parse(number.Text);
            
            // DateTime time = new DateTime(date.Date);
            incomesList.addIncome(k, source, amount, OfficialDate, source);

            Frame.Navigate(typeof(Details));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            source = button.Name;
            k = dic[button.Name];
            details.Text = source+":";
        }

        private void date_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            OfficialDate = args.NewDate.Value.LocalDateTime;
        }
    }
}
