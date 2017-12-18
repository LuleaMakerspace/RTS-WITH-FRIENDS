using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid : MonoBehaviour, IDisposable {
		public LayerMask UnwalkableMask; 
		public Vector2 GridWorldSize;
        public float nodeRadius;
        Node[,] grid;
        public int MaxSize { get; private set;}
        float nodeDiameter;
        int gridSizeX, gridSizeY;
        
		void Awake()
        {
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(GridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(GridWorldSize.y / nodeDiameter);
            MaxSize = gridSizeX * gridSizeY;

            CreateGrid();
        }

        void CreateGrid()
        {
            grid = new Node[gridSizeX, gridSizeY];

			Vector2 worldBottomLeft =  new Vector2(transform.position.x, transform.position.y) - Vector2.right * GridWorldSize.x / 2 + Vector2.down * GridWorldSize.y/2; 

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector2 worldPoint = worldBottomLeft + new Vector2((x * nodeDiameter + nodeRadius), (y * nodeDiameter + nodeRadius));
  					bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, UnwalkableMask, -2, 10)); 
                    grid[x, y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }        

        public Node NodeFromWorldPoint(Vector2 worldPosition)
        {
            float percentX = (worldPosition.x + GridWorldSize.x/2) / GridWorldSize.x;
		float percentY = (worldPosition.y + GridWorldSize.y/2) / GridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);

  
            return grid[x, y];
        }

        public void Dispose()
        {
          
        } 

		void OnDrawGizmos()  
		{ 
			Gizmos.color = Color.green; 
			Gizmos.DrawWireCube(transform.position, new Vector3(GridWorldSize.x, GridWorldSize.y, 1)); 
			if(grid != null)  
			{ 
				int i = 0; 
				foreach(var n in grid)  
				{ 
					Gizmos.color = n.walkable ? Color.blue : Color.red; 
					var v = new Vector3(n.worldPosition.x, n.worldPosition.y, 1); 
					i = i++; 
					Gizmos.DrawWireCube(v, Vector3.one * (nodeDiameter - .1f));   
				} 
			} 
		} 
	}
