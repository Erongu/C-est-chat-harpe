using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Salle;

namespace Projet.Model.Personnel
{
    static class MaitreHotel
    {
        public static Groupe CheckNouveauGroupe(List<Groupe> groupe, List<Groupe> groupeUpdate)//Si on a un nouvel élément dans la liste, on le retourne
        {
            if (groupe.Count < groupeUpdate.Count)
            {
                return groupeUpdate.Last();
            }
            return null;
        }

        public static Table RechercheTable(List<Table> tables, Groupe grp)
        {
            foreach (Table table in tables)
            {
                if ((table.Groupe == null) && ((table.Place == grp.Taille) || (table.Place == grp.Taille + 1)))//Si il n'y a pas de groupe a la table et si le groupe est assez nombreux
                {
                    return table;
                }
            }
            return null;
        }

    }
}
