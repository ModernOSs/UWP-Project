﻿using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

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

            goalsList = App.user.goalsList;
        }

        private Models.GoalsList goalsList { set; get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // 改回顶栏的颜色
            var viewTitleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.BackgroundColor = Windows.UI.Colors.LightGray;
            viewTitleBar.ButtonBackgroundColor = Windows.UI.Colors.LightGray;

            goalCount.Text = goalsList.goalCount.ToString();
            finishedGoalCount.Text = goalsList.finishedGoalCount.ToString();

            //更新磁贴
            UpdateWideTile();
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
            goalsList.finishGoal((sender as SymbolIcon).Tag.ToString());
            //  分享
            string id = (sender as SymbolIcon).Tag.ToString();
            for (int i = 0; i < goalsList.AllGoals.Count; ++i)
            {
                if (goalsList.AllGoals[i].id == id)
                {
                    goalsList.sharedGoal = goalsList.AllGoals[i];
                    break;
                }
            }
            DataTransferManager.ShowShareUI();

            Frame.Navigate(typeof(GoalsPage));
        }

        private void delete_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            goalsList.removeGoal((sender as SymbolIcon).Tag.ToString());
            App.upload();
            Frame.Navigate(typeof(GoalsPage));
        }

        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();
            //args.Request.Data.Properties.Title = goalsList.sharedGoal.goalName;
            //args.Request.Data.SetText(goalsList.sharedGoal.description);
            //if (sharedGoal.imageName == "default.jpg")
            //{
            //    args.Request.Data.SetBitmap(Windows.Storage.Streams.RandomAccessStreamReference.CreateFromUri(sharedGoal.bitmapImageSource.UriSource));
            //}
            //else
            //{
            //    StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(sharedGoal.imageName);
            //    var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            //    args.Request.Data.SetBitmap(Windows.Storage.Streams.RandomAccessStreamReference.CreateFromStream(stream));
            //}
            deferral.Complete();
            goalsList.sharedGoal = null;
        }

        private void goalsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GoalsPage));
        }

        private void splitViewButton_Click(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Details));
        }

        private void addNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewItemPage));
        }

        private void navigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            Grid e_ = (Grid)e.ClickedItem;
            string pageName = ((TextBlock)VisualTreeHelper.GetChild(e_, 1)).Text;
            if (pageName == "收支详情")
                Frame.Navigate(typeof(Details));
            else if (pageName == "添加收支")
                Frame.Navigate(typeof(AddNewItemPage));
            else if (pageName == "目标详情")
                Frame.Navigate(typeof(GoalsPage));
            else if (pageName == "添加目标")
                Frame.Navigate(typeof(AddGoal));
            else
                Frame.Navigate(typeof(MainPage));
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        // 磁贴更新----goalslist
        private void UpdateWideTile()
        {
            Models.Goal firstUnfinishedGoal = goalsList.getFirstUnfinishedGoal();
            if (firstUnfinishedGoal != null)
            {
                App.UpdateTile(new TileBindingContentAdaptive()
                {
                    Children =
                    {
                        new TileText()
                        {
                            Text = "最新目标",
                            Style = TileTextStyle.SubtitleSubtle
                        },
                        new TileText()
                        {
                            Text = firstUnfinishedGoal.goalName,
                            Style = TileTextStyle.Subtitle
                        },
                        //new TileText()
                        //{
                        //    Text = firstUnfinishedGoal.description,
                        //    Style = TileTextStyle.CaptionSubtle
                        //},
                        new TileText()
                        {
                            Text = firstUnfinishedGoal.dueTime.ToString("yyyy/MM/dd dddd"),
                            Style = TileTextStyle.CaptionSubtle
                        }
                        //new TileImage()
                        //{
                        //    Source = new TileImageSource("ms-appdata:///local/Projects/03509dce-9bf3-47c8-be42-7cd32ce458b4/Slides/" + firstUnfinishedGoal.imageName),
                        //    Align = TileImageAlign.Left
                        //}
                    }
                }, 1);
            }
            else
            {
                TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            }
        }
    }
}
