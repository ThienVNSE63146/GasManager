using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas
{
    class UserDTO
    {
        private int id;
        private string name, address, phone;

        public UserDTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public UserDTO(int id, string name, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }

        public UserDTO(string name, string address, string phone)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
