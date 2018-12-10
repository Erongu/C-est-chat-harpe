using Projet.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Model.Pathfinding
{
    public class MapPoint
    {
        static readonly Point VectorRight = new Point(1, 0);
        static readonly Point VectorDown = new Point(0, -1);
        static readonly Point VectorLeft = new Point(-1, 0);
        static readonly Point VectorUp = new Point(0, 1);

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


        public bool IsObstacle
        {
            get;
            set;
        }

        public MapPoint(int x, int y, bool isObstacle = false)
        {
            this.X = x;
            this.Y = y;
            this.IsObstacle = IsObstacle;
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
