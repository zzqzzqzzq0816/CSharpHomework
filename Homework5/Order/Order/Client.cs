using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Client
    {
        public string ClientName { get; set; }
        public string ClientPlace { get; set; }
        public Client(string name,string place)
        {
            ClientName = name;
            ClientPlace = place;
        }
        public override string ToString()
        {
            return ClientName+" "+ClientPlace;
        }
    }
}
