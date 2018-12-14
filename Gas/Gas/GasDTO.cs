using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class GasDTO
    {
        private int id;
        private string name;
        private float quantity;
        private float price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }

        public GasDTO(int id, string name, float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public GasDTO(int id, string name, float quantity, float price)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

        public GasDTO(string name, float quantity, float price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
