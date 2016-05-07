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
            incomesList.addIncome("餐饮", 120.5, DateTimeOffset.Now, "花费");
            incomesList.addIncome("工资", 500, DateTimeOffset.Now, "收入");
            incomesList.addIncome("娱乐", 25.5, DateTimeOffset.Now, "花费");
            incomesList.addIncome("生活", 58, DateTimeOffset.Now, "花费");
            incomesList.addIncome("工资", 500, DateTimeOffset.Now, "收入");

            goalsList = new GoalsList();
        }

        public void addIncome(string source, double amount, DateTimeOffset date, string inOrOut)
        {
            incomesList.addIncome(source, amount, date, inOrOut);
        }

        public void removeIncome(int id)
        {
            incomesList.removeIncome(id);
        }
    }
}
