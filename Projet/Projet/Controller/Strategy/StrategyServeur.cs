using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;
using Controller;
using Model.Enums;
using Model.Pathfinding;

namespace Controller.Strategy
{
    public class StrategyServeur : IStrategy
    {
        public void Call(object instance, object[] args)
        {
            if (instance.GetType().Name == "Personnel")
            {
                var start = new MapPoint((int)args[0], (int)args[1]);
                var end = new MapPoint((int)args[2], (int)args[3]);

                RestaurantController.Vue.UpdatePositionNeeded((int)args[2], (int)args[3]);

                var path = MapController.Instance.FindPath(start, end);

                foreach (var point in path.Cells)
                {
                    Thread.Sleep(200);

                    ((Personnel)instance).PosX = point.X;
                    ((Personnel)instance).PosY = point.Y;
                }
                
            }
        }
    }
}