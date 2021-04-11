using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int gridX = 10; // horizontal grid size of dots
    private readonly int gridY = 10; // vertical grid size of dots
    
    public GameObject dotPrefab;
    public GameObject lineHorizontalPrefab;
    public GameObject lineVerticalPrefab;

    private int[,] grid;
    private Camera mainCamera;

    private GameObject firstDot;
    private GameObject secondDot;
    private int[] firstDotCoord;
    private int[] secondDotCoord;
    
    private bool isFirstDotSelected = false;
    private bool isSecondDotSelected = false;

    private List<GameObject> occupiedDots;
    private List<GameObject> connections;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        grid = new int[gridX, gridY]; // create grid given dimensions values
        firstDotCoord = new int[2];
        secondDotCoord = new int[2];

        occupiedDots = new List<GameObject>();
        connections = new List<GameObject>();

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
                    
                    DrawLine();

                    firstDot = null;
                    secondDot = null;

                    isFirstDotSelected = false;
                    isSecondDotSelected = false;
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
        for (int x = -10; x < gridX; x++)
        {
            for (int y = -10; y < gridY; y++)
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
}
