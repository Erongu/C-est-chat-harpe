using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Strategy;
using Model.Cuisine;
using Model.Salle;

namespace Model
{
    class Restaurant : ClassTemplate
    {
        private List<Carre> Carres
        {
            get;
        } = new List<Carre>();

        public Comptoir Comptoir
        {
            get;
            set;
        }

        public Frigo Frigo
        {
            get;
            set;
        } = new Frigo();

        public VitrineChauffante VitrineChauffante
        {
            get;
            set;
        } = new VitrineChauffante();

        public Evier Evier
        {
            get;
            set;
        }

        //Constructeur
        public Restaurant(Dictionary<string, IStrategy> strategies, Dictionary<string, object> args) : base(strategies, args)
        {
            this.Carres.Add(new Carre(1));
            this.Carres.Add(new Carre(2));

            this.VitrineChauffante = new VitrineChauffante();

            this.Comptoir = new Comptoir();

            this.Frigo = new Frigo();
            this.Evier = new Evier();

        }

        //Methods
        public Carre GetCarre(int numero)
        {
            return Carres.FirstOrDefault(x => x.Numero == numero);
        }

        public List<Table> GetAllTables()
        {
            List<Table> tables = null;

            var allProducts = new List<Table>(GetCarre(1).GetRang(1).Tables.Count +
                                    GetCarre(1).GetRang(2).Tables.Count +
                                    GetCarre(1).GetRang(1).Tables.Count +
                                    GetCarre(2).GetRang(2).Tables.Count);

            allProducts.AddRange(GetCarre(1).GetRang(1).Tables);
            allProducts.AddRange(GetCarre(1).GetRang(2).Tables);
            allProducts.AddRange(GetCarre(2).GetRang(1).Tables);
            allProducts.AddRange(GetCarre(2).GetRang(2).Tables);

            return (List<Table>)allProducts;
        }
    }
}
