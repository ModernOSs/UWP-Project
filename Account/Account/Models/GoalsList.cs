using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    class GoalsList
    {
        private ObservableCollection<Goal> allGoals = new ObservableCollection<Goal>();
        private int goalsCount;
        public ObservableCollection<Goal> AllGoals { get { return allGoals; } set { allGoals = value; } }

        public GoalsList()
        {
            this.goalsCount = 0;
        }

        public void addGoal(string name, double price, DateTimeOffset dueTime, string description)
        {
            AllGoals.Add(new Goal(name, price, dueTime, description));
            goalsCount++;
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
