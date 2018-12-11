using Controller;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pathfinding
{
    public class MapPoint
    {
        static int MapWidth = 42;

        static readonly Point VectorRight = new Point(1, 0);
        static readonly Point VectorDown = new Point(0, -1);
        static readonly Point VectorLeft = new Point(-1, 0);
        static readonly Point VectorUp = new Point(0, 1);

        private MapPoint m_pointInMap;

        public int CellId
        {
            get
            {
                if (Y == 0)
                    return X;

                if (X == 0)
                    return Y * MapWidth;

                return X + (Y * MapWidth);
            }
        }

        public int X
        {
            get;
            protected set;
        }

        public int Y
        {
            get;
            protected set;
        }

        public bool Obstacle
        {
            get;
            set;
        }

        public MapPoint PointInMap
        {
            get
            {
                if (m_pointInMap == null)
                    m_pointInMap = MapController.Instance.Cells.FirstOrDefault(entry => entry.X == X && entry.Y == Y);

                return m_pointInMap;
            }
        }

        public MapPoint(int x, int y, bool isObstacle = false)
        {
            this.X = x;
            this.Y = y;
            this.Obstacle = isObstacle;
        }

        public MapPoint(int cellId, bool isObstacle = false)
        {
            var cell = MapController.Instance.Cells[cellId];

            this.X = cell.X;
            this.Y = cell.Y;
            this.Obstacle = cell.Obstacle;
        }

        public MapPoint GetMapPointInDirection(DirectionsEnum direction)
        {
            MapPoint mapPoint = null;
            switch (direction)
            {
                case DirectionsEnum.DIRECTION_EAST:
                    {
                        mapPoint = GetPoint(X - 1, Y);
                        break;
                    }
                case DirectionsEnum.DIRECTION_SOUTH:
                    {
                        mapPoint = GetPoint(X, Y - 1);
                        break;
                    }
                case DirectionsEnum.DIRECTION_WEST:
                    {
                        mapPoint = GetPoint(X + 1, Y);
                        break;
                    }
                case DirectionsEnum.DIRECTION_NORTH:
                    {
                        mapPoint = GetPoint(X, Y + 1);
                        break;
                    }
            }

            return mapPoint;
        }

        public MapPoint GetPoint(int x, int y)
        {
            return new MapPoint(x, y);
        }

        public bool IsInMap()
        {
            return MapController.Instance.IsInMap(X, Y);
        }

        public bool IsObstacle()
        {
            return (Obstacle || (PointInMap != null && PointInMap.Obstacle));
        }

        public uint ManhattanDistanceTo(MapPoint point)
        {
            return (uint)(Math.Abs(X - point.X) + Math.Abs(Y - point.Y));
        }

        public override bool Equals(object obj)
        {
            if (obj is MapPoint point)
                return point.X == X && point.Y == Y;

            return base.Equals(obj);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
