using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Pathfinding : MonoBehaviour, IDisposable {
	 Grid grid;

		void Start()
		{
			grid =  GameController.Instance.GetComponent<Grid>();
		}

        public void FindPathPriority(Vector2 startPos, Vector2 targetPos, int id, Action<List<Vector2>, int> callback)
        {
            print("Försöker hitta path");
            print(startPos);
            print(targetPos);
            var startNode = grid.NodeFromWorldPoint(startPos);
            var targetNode = grid.NodeFromWorldPoint(targetPos);

            var openSet = new PriorityQueue<Node>(grid.MaxSize);
            var closedSet = new HashSet<Node>();
            openSet.Enqueue(startNode);
            var hasPath = false;
            while (openSet.Count > 0)
            {
                var currentNode = openSet.Dequeue();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    hasPath = true;
                    break;
                }

                foreach (var neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);                    

                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode) + newMovementCostToNeighbour;
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Enqueue(neighbour);
                        else
                        {
                            openSet.UpdateItem(neighbour);
                        }
                    }
                }
            }

            if (hasPath)
                callback(RetracePath(startNode, targetNode), id);
            else
                callback(null, id);
        }

        List<Vector2> RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }
            path.Reverse();
            return path.Select(n => n.worldPosition).ToList();
        }

        int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = Math.Abs(nodeA.gridX - nodeB.gridX);
            int dstY = Math.Abs(nodeA.gridY - nodeB.gridY);

            if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);
            return 14 * dstX + 10 * (dstY - dstX);
        }

        public void Dispose()
        {           
        }
}
