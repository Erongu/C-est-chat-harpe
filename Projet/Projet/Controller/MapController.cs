using Projet.Model.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Controller
{
    public class MapController
    {
        private static MapController m_instance = null;
        private bool m_isInitalized = false;

        public static MapController Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new MapController();
                return m_instance;
            }
        }

        public List<List<int>> RawMap
        {
            get;
            private set;
        }

        public MapPoint[] Cells
        {
            get;
            private set;
        }

        public MapController()
        {

        }

        public void Initialize(List<List<int>> map)
        {
            RawMap = map;

            BuildMap(map);

            m_isInitalized = true;
        }

        private void BuildMap(List<List<int>> map)
        {
            var cellsList = new List<MapPoint>();

            for (var y = 0; y < map.Count; y++)
                for (var x = 0; x < map[y].Count; x++)
                    cellsList.Add(new MapPoint(y, x, x == 1));

            Cells = cellsList.ToArray();
        }

        public bool IsInMap(int x, int y)
        {
            return Cells.Any(entry => entry.X == x && entry.Y == y);
        }

        //Chargement de map
        public void LoadMap()
        {
            Console.WriteLine("WSHLESANG");
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"collisions.txt");
            while ((line = file.ReadLine()) != null)
            {
                int n = 0;
                foreach (char c in line)
                {
                    RawMap[counter][n] = (int)Char.GetNumericValue(c);
                    n++;
                }
                counter++;
            }

            file.Close();
        }
    }
}
