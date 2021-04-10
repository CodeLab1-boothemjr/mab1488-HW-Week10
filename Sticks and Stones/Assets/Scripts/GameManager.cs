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
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        grid = new int[gridX, gridY]; // create grid given dimensions values
        DrawGrid();
        DrawLines();
    }

    private void Update()
    {
        //on left click
        if (Input.GetMouseButtonDown(0))
        {
            //get the position of the mouse
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //cast a ray from the point of the mouse
            Ray ray = mainCamera.ScreenPointToRay (mousePosition);
            //store the first thing it hits into a var
            RaycastHit2D hit2D = Physics2D.GetRayIntersection (ray);
            //if it hit something, ie. it's not null
            if (hit2D.collider != null)
            {
                //print the coordinates of the dot it hits
                Debug.Log(hit2D.collider.gameObject.GetComponent<DotScript>().GetCoordinates());
            }
        }
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
