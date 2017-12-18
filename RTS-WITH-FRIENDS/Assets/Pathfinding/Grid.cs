using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid : MonoBehaviour, IDisposable {
		public LayerMask UnwalkableMask; 
		public Vector2 Banan;
        public float nodeRadius;
        Node[,] grid;
        public int MaxSize { get; private set;}
        float nodeDiameter;
        int gridSizeX, gridSizeY;
        
		void Awake()
        {
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt(Banan.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(Banan.y / nodeDiameter);
            MaxSize = gridSizeX * gridSizeY;

            CreateGrid();
        }

        void CreateGrid()
        {
            grid = new Node[gridSizeX, gridSizeY];

			Vector2 worldBottomLeft =  new Vector2(transform.position.x, transform.position.y) - Vector2.right * Banan.x / 2 + Vector2.down * Banan.y/2; 

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
            float percentX = (worldPosition.x + Banan.x/2) / Banan.x;
		float percentY = (worldPosition.y + Banan.y/2) / Banan.y;
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
			Gizmos.DrawWireCube(transform.position, new Vector3(Banan.x, Banan.y, 1)); 
			print(grid);
			if(grid != null)  
			{ 
				Debug.Log("Inne"); 
				int i = 0; 
				foreach(var n in grid)  
				{ 
					Gizmos.color = n.walkable ? Color.blue : Color.red; 
					var v = new Vector3(n.worldPosition.x, n.worldPosition.y, 1); 
					print(i); 
					i = i++; 
					Gizmos.DrawWireCube(v, Vector3.one * (nodeDiameter - .1f));   
				} 
			} 
		} 
	}
