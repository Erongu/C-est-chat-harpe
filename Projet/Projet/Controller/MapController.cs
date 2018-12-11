using Model.Enums;
using Model.Pathfinding;
using Model.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MapController
    {
        public const int MAX_ITERATION = 500;

        private static MapController m_instance = null;
        private bool m_isInitalized = false;
        private AsyncRandom m_random = new AsyncRandom();

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

            LogController.Instance.Info("Creation de la map");

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
                    cellsList.Add(new MapPoint(x, y, isObstacle));
                }
            }

            file.Close();

            Cells = cellsList.ToArray();
        }

        public MapPoint GetRandomFreeCell()
        {
            var freeCells = Cells.Where(x => x.Obstacle == false).ToList();
            var peek = new AsyncRandom().Next(0, freeCells.Count - 1);
            return freeCells[peek];
        }

        private static double GetHeuristic(MapPoint pointA, MapPoint pointB)
        {
            var dxy = new Point(Math.Abs(pointB.X - pointA.X), Math.Abs(pointB.Y - pointA.Y));
            var orthogonalValue = Math.Abs(dxy.X - dxy.Y);

            return 1 * (orthogonalValue + dxy.X + dxy.Y);
        }

        public Model.Pathfinding.Path FindPath(MapPoint start, MapPoint end)
        {
            var stopwatch = Stopwatch.StartNew();

            int iteration = 0;
            bool success = false;

            var matrix = new PathNode[Cells.Length];
            var openList = new PriorityQueueB<int>(new ComparePfNodeMatrix(matrix));
            var closedList = new List<PathNode>();

            var location = start.CellId;

            matrix[location].CellId = location;
            matrix[location].Parent = -1;
            matrix[location].G = 0;
            matrix[location].F = 1;
            matrix[location].Status = NodeState.Open;

            openList.Push(start.CellId);

            while (openList.Count > 0)
            {
                location = openList.Pop();
                var locationPoint = new MapPoint(location);

                if (matrix[location].Status == NodeState.Closed)
                    continue;

                if (location == end.CellId)
                {
                    matrix[location].Status = NodeState.Closed;
                    success = true;
                    break;
                }

                if (iteration > MAX_ITERATION)
                    return new Model.Pathfinding.Path(new List<MapPoint>());

                for (int i = 0; i < 4; i++)
                {
                    var newLocationPoint = locationPoint.GetMapPointInDirection((DirectionsEnum)i);

                    if (newLocationPoint == null)
                        continue;

                    var newLocation = newLocationPoint.CellId;

                    if (newLocation < 0)
                        continue;

                    if (!newLocationPoint.IsInMap())
                        continue;

                    if (!newLocationPoint.Equals(end) && newLocationPoint.IsObstacle())
                        continue;

                    double newG = matrix[location].G + 1;

                    if ((matrix[newLocation].Status == NodeState.Open ||
                        matrix[newLocation].Status == NodeState.Closed) &&
                        matrix[newLocation].G <= newG)
                        continue;

                    matrix[newLocation].CellId = newLocation;
                    matrix[newLocation].Parent = location;
                    matrix[newLocation].G = newG;
                    matrix[newLocation].H = GetHeuristic(newLocationPoint, end);
                    matrix[newLocation].F = newG + matrix[newLocation].H;

                    openList.Push(newLocation);
                    matrix[newLocation].Status = NodeState.Open;
                }

                matrix[location].Status = NodeState.Closed;

                iteration++;
            }

            if (success)
            {
                var node = matrix[end.CellId];

                while (node.Parent != -1)
                {
                    closedList.Add(node);
                    node = matrix[node.Parent];
                }

                closedList.Add(node);
            }

            closedList.Reverse();

            var path = closedList.Select(x => new MapPoint(x.CellId)).ToList();

            stopwatch.Stop();
            LogController.Instance.Debug($"Chemin de {start} à {end} trouvé en {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Reset();
            return new Model.Pathfinding.Path(path);
        }

        internal class ComparePfNodeMatrix : IComparer<int>
        {
            private readonly PathNode[] m_matrix;

            public ComparePfNodeMatrix(PathNode[] matrix)
            {
                m_matrix = matrix;
            }

            #region IComparer<int> Members

            public int Compare(int a, int b)
            {
                if (m_matrix[a].F > m_matrix[b].F)
                {
                    return 1;
                }

                if (m_matrix[a].F < m_matrix[b].F)
                {
                    return -1;
                }
                return 0;
            }

            #endregion
        }

    }
}
