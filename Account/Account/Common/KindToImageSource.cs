using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Account.Common
{
    class KindToImageSource : IValueConverter
    {
        //Convert是将kind类型转化为图片的Url
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Models.kind kind = (Models.kind)value;
            switch (kind)
            {
                case Models.kind.contact:
                    return UrlToImageSource("/Assets/contact.png");
                case Models.kind.education:
                    return UrlToImageSource("/Assets/education.png");
                case Models.kind.food:
                    return UrlToImageSource("/Assets/food.png");
                case Models.kind.fun:
                    return UrlToImageSource("/Assets/fun.png");
                case Models.kind.medical:
                    return UrlToImageSource("/Assets/medical.png");
                case Models.kind.money:
                    return UrlToImageSource("/Assets/money.png");
                case Models.kind.other:
                    return UrlToImageSource("/Assets/other.png");
                case Models.kind.shopping:
                    return UrlToImageSource("/Assets/shopping.png");
                case Models.kind.traffic:
                    return UrlToImageSource("/Assets/traffic.png");
                case Models.kind.travel:
                    return UrlToImageSource("/Assets/travel.png");
                default:
                    return UrlToImageSource("/Assets/other.png");
            }
        }

        //不是双向绑定，此方法直接抛出异常，不实现方法体
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public ImageSource UrlToImageSource(string url)
        {
            url = Directory.GetCurrentDirectory() + url;
            return new BitmapImage(new Uri(url));
        }
    }
}