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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GoalsPage : Page
    {
        public GoalsPage()
        {
            this.InitializeComponent();
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;
            NavigationCacheMode = NavigationCacheMode.Enabled;

            goalsList = new Models.GoalsList();
        }

        private Models.GoalsList goalsList { set; get; }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 改回顶栏的颜色
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;

        }

        private void addGoalButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddGoal), goalsList);
        }

        private void goalList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void finish_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            (sender as SymbolIcon).Visibility = Visibility.Collapsed;
            goalsList.finishGoal();
        }

        private void delete_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            goalsList.removeGoal((sender as SymbolIcon).Tag.ToString());
        }
    }
}
