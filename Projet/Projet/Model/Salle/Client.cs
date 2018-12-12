using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Strategy;

namespace Model.Salle
{
    
    public class Client : ClassTemplate
    {
        public int Type
        {
            get;
            protected set;
        }

        public Client(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args)
        {
            //Typage du client
            Random rnd = new Random();
            this.Type = rnd.Next(1, 3);
            
        }
       
    }
}
