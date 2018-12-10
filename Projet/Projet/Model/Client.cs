using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
    class Client
    {
        public int Type
        {
            get;
            protected set;
        }

        public Client()
        {
            //Typage du client
            Random rnd = new Random();
            this.Type = rnd.Next(1, 3);
            
        }
       
    }
}
