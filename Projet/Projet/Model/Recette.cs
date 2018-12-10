using Projet.Model;
using System.Collections.Generic;

namespace Model
{
    public class Recette
    {
        private string Nom
        {
            get;
            set;
        }

        private string Categorie
        {
            get;
            set;
        }

        private int NombrePart
        {
            get;
            set;
        }

        private List<Etape> Etapes
        {
            get;
            set;
        } = new List<Etape>();

    }
}