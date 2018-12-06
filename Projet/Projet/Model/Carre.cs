using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model
{
    class Carre
    {
        //Rangs
        private List<Rang> rangs;
        private int numero;

        //Constructeur
        public Carre(int numero)
        {
            this.numero = numero;
            //Creation des rangs
            rangs.Add(new Rang(1, numero));
            rangs.Add(new Rang(2, numero));
        }

        //Getter and Setter
        public List<Rang> getRang()
        {
            return this.rangs;
        }

        public Rang getRang(int numero)
        {
            foreach (Rang rang in rangs)
            {
                if (rang.getNumero() == numero) { return rang; }
            }
            return null;
        }

        public int getNumero()
        {
            return this.numero;
        }

    }
}
