using System.Collections.Generic;
using System.Linq;

namespace Model
{
    class Carre
    {
        //Rangs
        private List<Rang> Rangs
        {
            get;
        } = new List<Rang>();

        public int Numero
        {
            get;
            protected set;
        }

        //Constructeur
        public Carre(int numero)
        {
            this.Numero = numero;
            //Creation des rangs
            Rangs.Add(new Rang(1, numero));
            Rangs.Add(new Rang(2, numero));
        }

        //Methods
        public Rang GetRang(int numero)
        {
            return Rangs.FirstOrDefault(x => x.Numero == numero);
        }

    }
}
