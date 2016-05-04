using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    class IncomesList
    {
        private ObservableCollection<Incomes> allIncomes = new ObservableCollection<Incomes>();
        private int incomesCount;
        public ObservableCollection<Incomes> AllIncomes { get { return allIncomes; } set { allIncomes = value; } }

        public IncomesList()
        {
            incomesCount = 0;
            for (int i = 0; i < 5; i++)
                addIncome("火锅", 100, new DateTime(2001, 4, 8));
        }

        public void addIncome(string source, double amount, DateTimeOffset date)
        {
            allIncomes.Add(new Incomes(incomesCount, source, amount, date));
            incomesCount++;
        }

        public void removeIncome(int id)
        {
            for (int i = 0; i < AllIncomes.Count; i++)
            {
                if (AllIncomes.ToArray()[i].getId() == id)
                {
                    AllIncomes.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
