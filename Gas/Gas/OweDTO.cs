using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class OweDTO
    {
        private string id, date, customer, gas;
        private float price, quantity, total;
        private string note;

        public OweDTO(string id, string date, string customer, string gas, float price, float quantity, float total, string note) : this(id, date, customer, gas, price, quantity, total)
        {
            this.Note = note;
        }

        public OweDTO(string id, string date, string customer, string gas, float price, float quantity, float total)
        {
            this.Id = id;
            this.Date = date;
            this.Customer = customer;
            this.Gas = gas;
            this.Price = price;
            this.Quantity = quantity;
            this.Total = total;
        }

        public OweDTO(string date, string customer, string gas, float price, float quantity, float total)
        {
            this.date = date;
            this.customer = customer;
            this.gas = gas;
            this.price = price;
            this.quantity = quantity;
            this.total = total;
        }

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Customer { get => customer; set => customer = value; }
        public string Gas { get => gas; set => gas = value; }
        public float Price { get => price; set => price = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public float Total { get => total; set => total = value; }
        public string Note { get => note; set => note = value; }
    }
}
