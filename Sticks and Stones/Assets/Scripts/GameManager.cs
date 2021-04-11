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

    private GameObject firstDot;
    private GameObject secondDot;
    private int[] firstDotCoord;
    private int[] secondDotCoord;
    
    private bool isFirstDotSelected = false;
    private bool isSecondDotSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        grid = new int[gridX, gridY]; // create grid given dimensions values
        firstDotCoord = new int[2];
        secondDotCoord = new int[2];

        DrawGrid();
        DrawLines();
    }

    private void Update()
    {
        GameObject clickedObject =  GetClickedObject();
        if (clickedObject != null)
        {
            int[] tempCoord = clickedObject.GetComponent<DotScript>().GetCoordinates();
            
            // if new coord are already in the first dot slot
            if (firstDotCoord == tempCoord)
            {
                //deselect
                clickedObject.GetComponent<DotScript>().SwapDotSelection();
                //reset dot selected
                firstDotCoord = null;
                isFirstDotSelected = false;
            }
            // if new coord are already in the second dot slot
            else if (secondDotCoord == tempCoord)
            {
                //deselect
                clickedObject.GetComponent<DotScript>().SwapDotSelection();
                //reset do selected
                firstDotCoord = null;
                isSecondDotSelected = false;
            }
            // if first dot isn't selected
            else if (!isFirstDotSelected)
            {
                firstDot = clickedObject; // store the clicked object into firstDot
                firstDot.GetComponent<DotScript>().SwapDotSelection(); // "select" the dot
                firstDotCoord = tempCoord; // store the coordinates
                isFirstDotSelected = true; // set flag
            }
            // if second dot isn't selected
            else if (!isSecondDotSelected)
            {
                secondDot = clickedObject; // stored the clicked object into secondDot
                secondDot.GetComponent<DotScript>().SwapDotSelection(); // "select" the dot
                secondDotCoord = tempCoord; // store the coordinates
                isSecondDotSelected = true; // set flag
            }
            else
            {
                Debug.Log("dot1 = " + firstDotCoord[0] + ", " + firstDotCoord[1] 
                          + "\n dot2 = " + secondDotCoord[0] + ", " + secondDotCoord[1]);
                //Debug.Log("Both dots have already been selected.");
            }

        }

        clickedObject = null; // clear the clicked object
        
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
    
    // draw a line between two dots
    void DrawLine()
    {
        //var line = Instantiate(lineHorizontalPrefab);
        //var line2 = Instantiate(lineVerticalPrefab);
    }
}
