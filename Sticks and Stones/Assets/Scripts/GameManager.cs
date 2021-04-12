using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int gridX = 8; // horizontal grid size of dots
    private readonly int gridY = 8; // vertical grid size of dots
    
    public GameObject dotPrefab;
    public GameObject lineHorizontalPrefab;
    public GameObject lineVerticalPrefab;

    private GameObject[,] grid;
    private Camera mainCamera;

    private GameObject firstDot;
    private GameObject secondDot;
    private int[] firstDotCoord;
    private int[] secondDotCoord;
    
    private bool isFirstDotSelected = false;
    private bool isSecondDotSelected = false;

    private List<GameObject> occupiedDots;
    private List<GameObject[]> connections;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        grid = new GameObject[gridX, gridY]; // create grid given dimensions values
        firstDotCoord = new int[2];
        secondDotCoord = new int[2];

        occupiedDots = new List<GameObject>();
        connections = new List<GameObject[]>();

        DrawGrid();
        //DrawLines();
    }

    private void Update()
    {
        GameObject clickedObject =  GetClickedObject();
        if (clickedObject != null) //todo - switch null check to boolean
        {
            if (!isFirstDotSelected)
            {
                firstDot = clickedObject;

                if (!firstDot.GetComponent<DotScript>().fullyOccupied)
                {
                    firstDot.GetComponent<DotScript>().SelectDot();
                    firstDotCoord = firstDot.GetComponent<DotScript>().GetCoordinates();
                    isFirstDotSelected = true;
                }
            }
            else if (!isSecondDotSelected)
            {
                secondDot = clickedObject;
                
                if (!secondDot.GetComponent<DotScript>().fullyOccupied)
                {
                    secondDot.GetComponent<DotScript>().SelectDot();
                    secondDotCoord = secondDot.GetComponent<DotScript>().GetCoordinates();
                    isSecondDotSelected = true;
                    
                    occupiedDots.Add(firstDot);
                    occupiedDots.Add(secondDot);

                    //need to check all perpendicular neighbors of each dot to see if there are any open moves, if not, make it fully occupied
                    // if ()
                    // {
                    //     firstDot.GetComponent<DotScript>().fullyOccupied = true;
                    // }
                    //
                    // if ()
                    // {
                    //     secondDot.GetComponent<DotScript>().fullyOccupied = true;
                    // }
                    

                    GameObject[] connection = new GameObject[2];
                    connection[0] = firstDot;
                    connection[1] = secondDot;
                    connections.Add(connection);

                    DrawLine();

                    isFirstDotSelected = false;
                    isSecondDotSelected = false;
                    
                    secondDot.GetComponent<DotScript>().SelectDot();
                    firstDot.GetComponent<DotScript>().SelectDot();
                    
                    FindBox(firstDot, secondDot);
                }

            }
            else
            {
                Debug.Log("dot1 = " + firstDotCoord[0] + ", " + firstDotCoord[1] 
                            + "\n dot2 = " + secondDotCoord[0] + ", " + secondDotCoord[1]);
                //Debug.Log("Both dots have already been selected.");
            }
        }
    }

    private GameObject GetClickedObject()
    {
        //on left click
        if (Input.GetMouseButtonDown(0))
        {
            //get the position of the mouse
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //cast a ray from the point of the mouse
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            //store the first thing it hits into a var
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
            //if it hit something, ie. it's not null
            if (hit2D.collider != null)
            {
                //print the coordinates of the dot it hits
                return hit2D.collider.gameObject;
            }
        }
        return null;
    }

    // Draw the grid of dots
    void DrawGrid()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                var dot = Instantiate(dotPrefab); // create a dot
                dot.GetComponent<DotScript>().SetCoordinates(x, y); // set coordinates in dot game object
                dot.transform.position = new Vector3(x - 4, y - 3); // put dot in correct position

                grid[x, y] = dot;
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
    
    // draw a line between two dots
    void DrawLine()
    {
        if (occupiedDots[occupiedDots.Count - 2].transform.position.x == occupiedDots[occupiedDots.Count - 1].transform.position.x)
        {
            var line2 = Instantiate(lineVerticalPrefab);
            float yPos = occupiedDots[occupiedDots.Count - 2].transform.position.y +
                         (occupiedDots[occupiedDots.Count - 1].transform.position.y - 
                          occupiedDots[occupiedDots.Count - 2].transform.position.y) / 2;
            line2.transform.position = new Vector2(occupiedDots[occupiedDots.Count - 2].transform.position.x, yPos);
        }
        else
        {
            var line = Instantiate(lineHorizontalPrefab);
            
            float xPos = occupiedDots[occupiedDots.Count - 2].transform.position.x +
                         (occupiedDots[occupiedDots.Count - 1].transform.position.x - 
                          occupiedDots[occupiedDots.Count - 2].transform.position.x) / 2;
            line.transform.position = new Vector2(xPos, occupiedDots[occupiedDots.Count - 2].transform.position.y);
        }
    }

    //check if new connection completes a box
    void FindBox(GameObject dot1, GameObject dot2)
    {
        int y = 0;
        int x = 0;
        
        //these are the index values we can plug into the grid array to check neighbors
        int xIndex = 0;
        int yIndex = 0;
        
        for (x = 0; x < gridX; x++)
        {
            if (dot1.transform.position.x == grid[x,y].transform.position.x)
            {
                xIndex = x;
            }
        }
        
        for (y = 0; y < gridY; y++)
        {
            if (dot1.transform.position.y == grid[xIndex, y].transform.position.y)
            {
                yIndex = y;
            }
        }
        
        Debug.Log("first dot is at: " + xIndex + ", " + yIndex);
        
        //check if there is a connection made between neighboring spots
        if(grid[xIndex - 1, yIndex - 1] )

        firstDot = null;
        secondDot = null;
    }
}
