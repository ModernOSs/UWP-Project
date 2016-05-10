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
using Windows.UI.Popups;
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
        string source= "";
        Button isclick;
        Models.kind kind;
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
            OfficialDate = DateTimeOffset.Now;
            //Initialize selector
            selector.Items.Add("支出");
            selector.Items.Add("收入");
            selector.SelectedValue = "支出";

            //Initialize dic
            dic = new Dictionary<string, Models.kind>();
            dic.Add("餐饮", Models.kind.food);
            dic.Add("交通", Models.kind.traffic);
            dic.Add("购物", Models.kind.shopping);
            dic.Add("医疗", Models.kind.medical);
            dic.Add("旅行", Models.kind.travel);
            dic.Add("娱乐", Models.kind.entertainment);
            dic.Add("社交", Models.kind.contact);
            dic.Add("投资", Models.kind.investment);
            dic.Add("教育", Models.kind.education);
            dic.Add("其他", Models.kind.other);
            dic.Add("奖金", Models.kind.bonus);
            dic.Add("工资", Models.kind.salary);
            dic.Add("理财", Models.kind.financial);
            dic.Add("福利", Models.kind.welfare);
            dic.Add("其他收入", Models.kind.otherincome);
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
            string inOrOut= selector.SelectedValue.ToString();
            string checkmessage = "";
            if (number.Text == "0.00")
                checkmessage += "请填写金额！\n";
            if (source == "")
                checkmessage += "请选择标签！\n";
            if (details.Text == "")
                checkmessage += "请添加描述信息！\n";
            if (checkmessage != "")
            {
                var i = new MessageDialog(checkmessage).ShowAsync();
                return;
            }
            incomesList.addIncome(kind, details.Text, amount, OfficialDate, inOrOut);
            Frame.Navigate(typeof(Details));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Border border;
            if (isclick!= null)
            {
                border = isclick.Parent as Border;
                border.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }
            Button button = sender as Button;
            isclick = button;
            border = button.Parent as Border;
            border.BorderBrush = new SolidColorBrush(Colors.Gray);
            source = button.Name;
            kind = dic[button.Name];
        }

        private void date_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            OfficialDate = args.NewDate.Value.LocalDateTime;
        }

        private void selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Selector = selector.SelectedValue.ToString();
            if (Selector== "支出")
            {
                outcome.Visibility = Visibility.Visible;
                income.Visibility = Visibility.Collapsed;
            }
            else
            {
                income.Visibility = Visibility.Visible;
                outcome.Visibility = Visibility.Collapsed;
            }
        }
    }
}
