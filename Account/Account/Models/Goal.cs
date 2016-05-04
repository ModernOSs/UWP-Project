using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Models
{
    class Goal
    {
        private string id;
        private string name;
        private double price;
        private DateTimeOffset dueTime;
        private string description;

        public Goal(string name, double price, DateTimeOffset dueTime, string description)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.price = price;
            this.dueTime = dueTime;
            this.description = description;
        }

        public string getId()
        {
            return this.id;
        }
    }
}
