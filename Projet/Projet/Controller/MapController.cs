using Projet.Model.Pathfinding;
using System;
using System.Collections.Generic;
using System.IO;
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

        public MapPoint[] Cells
        {
            get;
            private set;
        }

        public MapController()
        {

        }

        public void Initialize()
        {
            if (m_isInitalized)
                return;

            LoadMap();

            m_isInitalized = true;
        }


        public bool IsInMap(int x, int y)
        {
            return Cells.Any(entry => entry.X == x && entry.Y == y);
        }

        //Chargement de map
        private void LoadMap()
        {
            var cellsList = new List<MapPoint>();

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(@"collisions.txt");
            var fileContent = file.ReadToEnd();

            var lines = fileContent.Split('\n');

            for(var y = 0; y < lines.Length; y++)
            {
                for(var x = 0; x < lines[y].Length; x++)
                {
                    var isObstacle = lines[y][x] == '1';
                    cellsList.Add(new MapPoint(y, x, isObstacle));
                }
            }

            file.Close();

            Cells = cellsList.ToArray();
        }
    }
}
