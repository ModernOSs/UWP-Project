using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Models.IncomesList incomesList { set; get; }
        Models.GoalsList goalsList { set; get; }

        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Color.FromArgb(0, 136, 214, 255);
            viewTitleBar.ButtonBackgroundColor = Color.FromArgb(0, 136, 214, 255);

            this.incomesList = App.user.incomesList;
            this.goalsList = App.user.goalsList;
            initializeData();
        }

        private void initializeData()
        {
            double incomes = 0, outcomes = 0, todayOutcomes = 0, todayIncomes = 0;
            for (int i = 0; i < incomesList.AllIncomes.Count; i++)
            {
                if (incomesList.AllIncomes.ToArray()[i].date.Month == DateTimeOffset.Now.Month)
                {
                    if (incomesList.AllIncomes.ToArray()[i].inOrOut == "花费")
                        outcomes += incomesList.AllIncomes.ToArray()[i].amount;
                    else
                        incomes += incomesList.AllIncomes.ToArray()[i].amount;
                }
                if (incomesList.AllIncomes.ToArray()[i].date.Day == DateTimeOffset.Now.Day)
                {
                    if (incomesList.AllIncomes.ToArray()[i].inOrOut == "花费")
                        todayOutcomes += incomesList.AllIncomes.ToArray()[i].amount;
                    else
                        todayIncomes += incomesList.AllIncomes.ToArray()[i].amount;
                }
            }
            incomesText.Text = ((int)incomes).ToString();
            outcomesText.Text = ((int)outcomes).ToString();
            todayOutcomesText.Text = ((int)todayOutcomes).ToString();
            todayIncomesText.Text = ((int)todayIncomes).ToString();

            goalsNumberText.Text = goalsList.AllGoals.Count.ToString();
            Thickness margin;
            margin.Top = 440 * outcomes / (incomes + 1) - 220;
            margin.Left = 0; margin.Right = 0; margin.Bottom = 0;
            webview.Margin = margin;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 改回顶栏的颜色
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Color.FromArgb(0, 136, 214, 255);
            viewTitleBar.ButtonBackgroundColor = Color.FromArgb(0, 136, 214, 255);
        }

        private void goalsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GoalsPage));
        }

        private void waterTankButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Details));
        }
    }
}
