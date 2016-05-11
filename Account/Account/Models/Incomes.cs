using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    public enum kind { food, traffic, shopping , medical , travel, entertainment , contact , investment, education , other, bonus, salary, financial, welfare, otherincome };
    public class Incomes
    {
        public kind kind;
        public int id;
        public string source;
        public double amount;
        public DateTimeOffset date;
        public string inOrOut;

        public Incomes(int id, kind kind, string source, double amount, DateTimeOffset date, string inOrOut)
        {
            this.id = id;
            this.kind = kind;
            this.source = source;
            this.amount = amount;
            this.date = date;
            this.inOrOut = inOrOut;
        }
    }
}
