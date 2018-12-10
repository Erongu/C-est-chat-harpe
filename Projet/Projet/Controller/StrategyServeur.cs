using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;

namespace Controller
{
    public class StrategyServeur : IStrategy
    {
        protected List<Dictionary<string, int>> GetChemin(List<Dictionary<string, int>> closedList, Dictionary<string, int> end)
        {
            int isSearching = 0;
            Dictionary<string, int> previous = new Dictionary<string, int>(){ };
            List<Dictionary<string, int>> path = new List<Dictionary<string, int>>() { };

            while (closedList.Count > 0)
            {
                if (isSearching == 0)
                {
                    int cout = closedList.Count;
                    int kept = 0;
                    for (int i = 0; i < cout; i++)
                    {
                        Dictionary<string, int> j = closedList[i];
                        Dictionary<string, int> test = new Dictionary<string, int>() { { "x", j["x"] }, { "y", j["y"] } };
                        if (test == end)
                        {
                            if (j["cout"] < cout)
                            {
                                cout = j["cout"];
                                previous = j;
                            }
                        }
                        kept = i;
                    }
                    path.Insert(0, previous);
                    for (int k = kept; k < cout; k++)
                    {
                        closedList.RemoveAt(k);
                    }
                }
                for (int i = 0; i < closedList.Count; i++)
                {
                    Dictionary<string, int> j = closedList[i];
                    if (j["cout"] == previous["cout"] - 1 && ((j["x"] == previous["x"] - 1 && j["y"] == previous["y"]) || (j["x"] == previous["x"] + 1 && j["y"] == previous["y"]) || (j["y"] == previous["y"] - 1 && j["x"] == previous["x"]) || (j["y"] == previous["y"] + 1 && j["x"] == previous["x"])))
                    {
                        previous = j;
                        path.Insert(0, j);
                        for (int k = i; k < closedList.Count; k++)
                        {
                            closedList.RemoveAt(k);
                        }
                    }
                }
                isSearching += 1;
            }
            return path;
        }

        protected List<Dictionary<string, int>> Disperse(List<List<int>> g, Dictionary<string, int> objectif, Dictionary<string, int> depart, List<int> obstacles)
        {
            try
            {
                List<Dictionary<string, int>> closedList = new List<Dictionary<string, int>>() { };
                List<Dictionary<string, int>> openList = new List<Dictionary<string, int>>() { depart };
                int index = 0;
                while (index < openList.Count)
                {
                    Dictionary<string, int> u = openList[index];
                    var cardinalSearch = new List<int>[4] { new List<int>() { -1, 0 }, new List<int>() { 1, 0 }, new List<int>() { 0, -1 }, new List<int>() { 0, 1 } };
                    foreach ( List<int> i in cardinalSearch)
                    {
                        if (0 <= u["x"] + i[0] && u["x"] + i[0] < g.Count && 0 <= u["y"] + i[1] && u["y"] + i[1] < g[0].Count)
                        {
                            Dictionary<string, int> v = new Dictionary<string, int>() { { "x", u["x"] + i[0] }, { "y", u["y"] + i[1] }, { "cout", 0} };
                            if (!obstacles.Contains(g[v["x"]][v["y"]]))
                            {
                                v["cout"] = u["cout"] + 1;
                                if (closedList.Any(x => x["x"] == v["x"] && x["y"] == v["y"]))
                                {
                                    if (closedList.First(x => x["x"] == v["x"] && x["y"] == v["y"])["cout"] > v["cout"])
                                    {
                                        openList.Add(v);
                                    }
                                }
                                else if (openList.Any(x => x["x"] == v["x"] && x["y"] == v["y"]))
                                {
                                    if (openList.First(x => x["x"] == v["x"] && x["y"] == v["y"])["cout"] > v["cout"])
                                    {
                                        openList.Add(v);
                                    }
                                }
                                else
                                {
                                    openList.Add(v);
                                }
                            }
                        }
                    }

                    closedList.Add(u);
                    index += 1;
                }
                return GetChemin(closedList, objectif);
            }
            catch
            {
                return new List<Dictionary<string, int>>() { };
            }
        }

        public void method(object instance, object[] args)
        {
            if (instance.GetType().Name == "Personnel")
            {
                Dictionary<string, int> coordEnd = new Dictionary<string, int>() { { "x", (int)args[2] }, { "y", (int)args[3] } };
                Dictionary<string, int> coordStart = new Dictionary<string, int>() { { "x", (int)args[0] }, { "y", (int)args[1] } };
                List<List<int>> g = (List<List<int>>)args[4];
                List<Dictionary<string, int>> path = this.Disperse(g, coordEnd, coordStart, new List<int>() { 1 });

                foreach (Dictionary<string, int> position in path)
                {
                    Thread.Sleep(200);
                    ((Personnel)instance).setPosX(position["x"]);
                    ((Personnel)instance).setPosY(position["y"]);
                    Console.WriteLine(position);
                }
            }
        }
    }
}