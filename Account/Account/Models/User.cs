using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    public class User
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
            // 测试数据
            incomesList = new IncomesList();
            incomesList.addIncome("餐饮", 120.5, DateTimeOffset.Now);
            incomesList.addIncome("娱乐", 30, DateTimeOffset.Now);
            incomesList.addIncome("生活", 108.5, DateTimeOffset.Now);
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
