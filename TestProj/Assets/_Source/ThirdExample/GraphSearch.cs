using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThirdExample
{
    public class GraphSearch 
    {
        public static BfsResult BfsGetRange(HexGrid hexGrid, Vector3Int startPos, int movementPoints)
        {
            Dictionary<Vector3Int, Vector3Int?> visitedNodes = new Dictionary<Vector3Int, Vector3Int?>();
            Dictionary<Vector3Int, int> costSoFar = new Dictionary<Vector3Int, int>();
            Queue<Vector3Int> nodesToVisitQueue = new Queue<Vector3Int>();
            
            nodesToVisitQueue.Enqueue(startPos);
            costSoFar.Add(startPos, 0);
            visitedNodes.Add(startPos,null);

            while (nodesToVisitQueue.Count > 0)
            {
                Vector3Int currNode = nodesToVisitQueue.Dequeue();
                foreach (Vector3Int neighbourPoss in hexGrid.GetNeighboursFor(currNode))
                {
                    if (hexGrid.GetTileAt(neighbourPoss).IsObstacle())
                    {
                        continue;
                    }

                    int nodeCost = hexGrid.GetTileAt(neighbourPoss).GetCost();
                    int currCost = costSoFar[currNode];
                    int newCost = currCost + nodeCost;

                    if (newCost <= movementPoints)
                    {
                        if (!visitedNodes.ContainsKey(neighbourPoss))
                        {
                            visitedNodes[neighbourPoss] = currNode;
                            costSoFar[neighbourPoss] = newCost;
                            nodesToVisitQueue.Enqueue(neighbourPoss);
                        }
                        else if (costSoFar[neighbourPoss] > newCost)
                        {
                            costSoFar[neighbourPoss] = newCost;
                            visitedNodes[neighbourPoss] = currNode;
                        }
                    }
                }
            }

            return new BfsResult { VisitedNodesDict = visitedNodes };
        }

        public static List<Vector3Int> GeneratePathBfs(Vector3Int current,
            Dictionary<Vector3Int, Vector3Int?> visitedNodesDict)
        {
            List<Vector3Int> path = new List<Vector3Int>();
            path.Add(current);
            while (visitedNodesDict[current] != null)
            {
                path.Add(visitedNodesDict[current].Value);
                current = visitedNodesDict[current].Value;
            }
            path.Reverse();
            return path.Skip(1).ToList();
        }
    }

    public struct BfsResult
    {
        public Dictionary<Vector3Int, Vector3Int?> VisitedNodesDict;

        public List<Vector3Int> GetPathTo(Vector3Int destination)
        {
            if (VisitedNodesDict.ContainsKey(destination) == false)
            {
                return new List<Vector3Int>();
            }

            return GraphSearch.GeneratePathBfs(destination, VisitedNodesDict);
        }

        public bool IsHexPosInRange(Vector3Int pos)
        {
            return VisitedNodesDict.ContainsKey(pos);
        }

        public IEnumerable<Vector3Int> GetRangePositions()
        {
           return VisitedNodesDict.Keys;
        }
    }
}
