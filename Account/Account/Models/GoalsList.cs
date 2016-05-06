using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Account.Models
{
    public class GoalsList
    {
        private ObservableCollection<Goal> allGoals = new ObservableCollection<Goal>();
        public ObservableCollection<Goal> AllGoals { get { return allGoals; } set { allGoals = value; } }

        public Models.Goal selectedGoal;


        public GoalsList()
        {

        }

        public void addGoal(string name, double price, DateTimeOffset dueTime, string description, string imageName, BitmapImage bitmapImageSource)
        {
            AllGoals.Add(new Goal(name, price, dueTime, description, imageName, bitmapImageSource));
        }

        public void removeGoal(string id)
        {
            for (int i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].getId() == id)
                {
                    AllGoals.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
