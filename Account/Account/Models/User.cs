using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    class User
    {
        private string username;
        private string password;
        private IncomesList incomesList;
        // 加入其它list类

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            // 后期加入“数据包”
        }

        public void addIncome(string source, double amount, DateTimeOffset date)
        {
            incomesList.addIncome(source, amount, date);
        }

        public void removeIncome(int id)
        {
            incomesList.removeIncome(id);
        }
    }
}
