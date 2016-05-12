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
        public int goalCount;
        public int finishedGoalCount;

        public GoalsList()
        {
            goalCount = 0;
            finishedGoalCount = 0;
        }

        public void addGoal(string name, double price, DateTimeOffset dueTime, string description, string imageName, BitmapImage bitmapImageSource)
        {
            goalCount++;
            AllGoals.Insert(0, new Goal(name, price, dueTime, description, imageName, bitmapImageSource));
            //AllGoals.Add(new Goal(name, price, dueTime, description, imageName, bitmapImageSource));
        }

        public void removeGoal(string id)
        {
            for (int i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].getId() == id)
                {
                    goalCount--;
                    if (AllGoals[i].finished == true) finishedGoalCount--;
                    AllGoals.RemoveAt(i);
                    break;
                }
            }
        }

        public void finishGoal(string id)
        {
            for (int i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].getId() == id)
                {
                    AllGoals[i].finished = true;
                    finishedGoalCount++;
                    break;
                }
            }
        }

        public string nameOfFirstUnfinishedGoal()
        {
            int i = 0;
            DateTimeOffset minTime;
            for (i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].finished == false)
                {
                    minTime = AllGoals[i].dueTime;
                    break;
                }
            }
            if (i == AllGoals.Count) return "";

            string returnName = AllGoals[i].goalName;
            for (i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].finished == false && AllGoals[i].dueTime < minTime)
                {
                    minTime = AllGoals[i].dueTime;
                    returnName = AllGoals[i].goalName;
                }
            }
            return returnName;
        }

        public Goal getFirstUnfinishedGoal()
        {
            for (int i = 0; i < AllGoals.Count; ++i)
            {
                if (AllGoals[i].finished == false)
                {
                    return AllGoals[i];
                }
            }
            return null;
        }
    }
}
