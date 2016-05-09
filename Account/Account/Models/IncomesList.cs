using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    public class IncomesList
    {
        private ObservableCollection<Incomes> allIncomes = new ObservableCollection<Incomes>();
        private int incomesCount;
        public ObservableCollection<Incomes> AllIncomes { get { return allIncomes; } set { allIncomes = value; } }

        public IncomesList()
        {
            incomesCount = 0;
        }

        public void addIncome(kind kind, string source, double amount, DateTimeOffset date, string inOrOut)
        {
            allIncomes.Add(new Incomes(incomesCount, kind, source, amount, date, inOrOut));
            incomesCount++;
        }

        public void removeIncome(int id)
        {
            for (int i = 0; i < AllIncomes.Count; i++)
            {
                if (AllIncomes.ToArray()[i].id == id)
                {
                    AllIncomes.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
