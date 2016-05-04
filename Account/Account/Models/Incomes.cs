using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    class Incomes
    {
        private int id;
        private string source;
        private double amount;
        private DateTimeOffset date;

        public Incomes(int id, string source, double amount, DateTimeOffset date)
        {
            this.id = id;
            this.source = source;
            this.amount = amount;
            this.date = date;
        }

        public int getId()
        {
            return id;
        }
    }
}
