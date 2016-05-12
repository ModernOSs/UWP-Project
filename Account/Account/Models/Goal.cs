using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Account.Models
{
    public class Goal
    {
        public string id;
        public string goalName;
        public double price;
        public DateTimeOffset dueTime;
        public string description;
        public string imageName;
        public BitmapImage bitmapImageSource;
        public bool finished;

        public Goal(string name, double price, DateTimeOffset dueTime, string description, string imageName, BitmapImage bitmapImageSource)
        {
            this.id = Guid.NewGuid().ToString();
            this.goalName = name;
            this.price = price;
            this.dueTime = dueTime;
            this.description = description;
            this.imageName = imageName;
            this.bitmapImageSource = bitmapImageSource;
            this.finished = false;
        }

        public string getId()
        {
            return this.id;
        }
    }
}
