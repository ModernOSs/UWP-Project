using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    public class Incomes
    {
        public int id;
        public string source;
        public double amount;
        public DateTimeOffset date;
        public string inOrOut;

        public Incomes(int id, string source, double amount, DateTimeOffset date, string inOrOut)
        {
            this.id = id;
            this.source = source;
            this.amount = amount;
            this.date = date;
            this.inOrOut = inOrOut;
        }
    }
}
