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
        public IncomesList incomesList;
        public GoalsList goalsList;
        // 加入其它list类

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            // 后期加入“数据包”
            // 测试数据
            incomesList = new IncomesList();
            goalsList = new GoalsList();
            incomesList.addIncome(kind.food, "火锅", 120.5, new DateTime(2016, 5, 3), "花费");
            incomesList.addIncome(kind.fun, "唱K", 30, new DateTime(2016, 5, 3), "花费");
            incomesList.addIncome(kind.shopping, "衣服", 110, new DateTime(2016, 4, 3), "花费");
            incomesList.addIncome(kind.education, "衣服", 100, new DateTime(2016, 4, 3), "花费");
            incomesList.addIncome(kind.medical, "衣服", 90, new DateTime(2016, 3, 3), "花费");
            incomesList.addIncome(kind.other, "衣服", 80, new DateTime(2016, 3, 3), "花费");
            incomesList.addIncome(kind.money, "衣服", 70, new DateTime(2016, 2, 3), "花费");
            incomesList.addIncome(kind.traffic, "衣服", 60, new DateTime(2016, 2, 3), "花费");
            incomesList.addIncome(kind.travel, "衣服", 50, DateTimeOffset.Now, "花费");
            incomesList.addIncome(kind.contact, "衣服", 40, DateTimeOffset.Now, "花费");
            incomesList.addIncome(kind.money, "收入", 800, DateTimeOffset.Now, "收入");
            incomesList.addIncome(kind.money, "收入", 800, DateTimeOffset.Now, "收入");
        }

        public void addIncome(kind kind, string source, double amount, DateTimeOffset date, string inOrOut)
        {
            incomesList.addIncome(kind, source, amount, date, inOrOut);
        }

        public void removeIncome(int id)
        {
            incomesList.removeIncome(id);
        }
    }
}
