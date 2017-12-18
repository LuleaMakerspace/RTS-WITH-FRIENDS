using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : INode<Node> {

	 public bool walkable;
        public Vector2 worldPosition;
        public int gridX;
        public int gridY;

        public int gCost;
        public int hCost;
        public Node parent;

        public Node(bool _walkable, Vector2 _worldPos, int _gridX, int _gridY)
        {
            walkable = _walkable;
            worldPosition = _worldPos;
            gridX = _gridX;
            gridY = _gridY;
        }

        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }

        public int QueueIndex { get; set; }

        public int Priority
        {
            get
            {
                return fCost;
            }
        }

        public int CompareTo(Node other)
        {
            int compare = fCost.CompareTo(other.fCost);

            if (compare == 0)
            {
                compare = hCost.CompareTo(other.hCost);
            }

            return -compare;
        }
}

public interface INode<T>
{
	int Priority { get; }
	int QueueIndex { get; set; }
}