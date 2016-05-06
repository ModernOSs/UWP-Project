using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Account
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AddGoal : Page
    {
        public AddGoal()
        {
            this.InitializeComponent();

        }

        private BitmapImage bitmapImageSource;
        private string imageName;
        private Models.GoalsList GoalsList;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //  获取GoalsList
            GoalsList = ((Models.GoalsList)e.Parameter);

            //  将bitmapImageSource 和 imageName 设置为默认图片
            BitmapImage bitmapimage = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/default.jpg");
            bitmapimage.UriSource = uri;
            image.Source = bitmapimage;
            bitmapImageSource = bitmapimage;
            imageName = "default.jpg";
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            string result = CheckItemValidation();
            if (result != "")
            {
                var message = new MessageDialog(result).ShowAsync();
            }
            else
            {
                GoalsList.addGoal(name.Text, Convert.ToDouble(price.Text), dueTime.Date, description.Text, imageName, bitmapImageSource);
                Frame.Navigate(typeof(GoalsPage), GoalsList);
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            price.Text = "";
            description.Text = "";
            dueTime.Date = DateTime.Today;

            BitmapImage bitmapimage = new BitmapImage();
            Uri uri = new Uri("ms-appx:///Assets/default.jpg");
            bitmapimage.UriSource = uri;
            image.Source = bitmapimage;
            bitmapImageSource = bitmapimage;
            imageName = "default.jpg";
        }

        private async void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".gif");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                BitmapImage bitmapimage = new BitmapImage();
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                await bitmapimage.SetSourceAsync(stream);
                image.Source = bitmapimage;
                bitmapImageSource = bitmapimage;
                imageName = file.Name;

                await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.ReplaceExisting);
            }
        }

        private string CheckItemValidation()
        {
            string[] errInfo = { "目标名称不能为空\n",
                                 "目标描述不能为空\n",
                                 "目标价格不能为空\n",
                                 "完成日期不能早于今天\n" };
            string err = "";
            if (name.Text == "")
            {
                err += errInfo[0];
            }
            if (description.Text == "")
            {
                err += errInfo[1];
            }
            if (price.Text == "")
            {
                err += errInfo[2];
            }
            if (dueTime.Date < DateTime.Today)
            {
                err += errInfo[3];
            }
            return err;
        }
    }
}
