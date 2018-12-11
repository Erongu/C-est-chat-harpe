using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pathfinding
{
    public struct PathNode
    {
        public int CellId;
        public double F;
        public double G;
        public double H;
        public int Parent;
        public NodeState Status;
    }

    public enum NodeState : byte
    {
        None,
        Open,
        Closed
    }

    public class Path
    {
        private List<MapPoint> m_path;

        public List<MapPoint> Cells
        {
            get
            {
                return m_path;
            }
        }

        public Path(List<MapPoint> cells)
        {
            m_path = cells;
        }

        public void AddPoint(MapPoint mapPoint)
        {
            m_path.Add(mapPoint);
        }
    }
}
