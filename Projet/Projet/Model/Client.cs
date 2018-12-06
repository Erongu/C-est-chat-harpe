using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    
    class Client
    {
        private int type;

        public Client()
        {
            //Typage du client
            Random rnd = new Random();
            this.type = rnd.Next(1, 3);
            
        }

        public int getType(){return this.type;}
       
    }
}
