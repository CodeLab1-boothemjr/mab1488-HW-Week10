using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int gridX = 3; // horizontal grid size of dots
    private readonly int gridY = 3; // vertical grid size of dots
    
    public GameObject dotPrefab;
    public GameObject lineHorizontalPrefab;
    public GameObject lineVerticalPrefab;

    private int[,] grid;
    
    // Start is called before the first frame update
    void Start()
    {
        grid = new int[gridX, gridY]; // create grid given dimensions values
        DrawGrid();
        //DrawLines();
    }

    private void Update()
    {
        
    }

    // Draw the grid of dots
    void DrawGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                var dot = Instantiate(dotPrefab); // create a dot
                dot.transform.position = new Vector3(x, y); // put dot in correct position
                dot.GetComponent<DotScript>().SetCoordinates(x, y); // set coordinates in dot game object
            }
        }
    }
    
    // TODO - remove after done testing + implementing
    // Draw some lines
    void DrawLines()
    {
        var line = Instantiate(lineHorizontalPrefab);
        var line2 = Instantiate(lineVerticalPrefab);
    }
}
