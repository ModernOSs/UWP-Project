using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Account.Models
{
    public class User
    {
        public string username;
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
            incomesList.addIncome(kind.food, "火锅", 120.5, new DateTime(2016, 5, 3), "支出");
            incomesList.addIncome(kind.entertainment, "唱K", 30, new DateTime(2016, 5, 3), "支出");
        }
    }
}
