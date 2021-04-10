using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour
{
    public Material defaultColor;
    public Material hoverColor;
    public Material selectedColor;

    private Boolean selected; // if the dot is currently selected

    private int xPos = -1;
    private int yPos = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        selected = false; // start the dot as not selected
    }

    // stores the coordinates of the dot in the game object
    public void SetCoordinates(int x, int y)
    {
        xPos = x;
        yPos = y;
    }

    public string GetCoordinates()
    {
        return "x, y = " + xPos + ", " + yPos;
    }
    
    private void OnMouseDown()
    {
        // if not already selected when clicked
        if (!selected)
        {
            // change to selected color
            GetComponent<SpriteRenderer> ().material = selectedColor;
        }
        // if already selected when clicked
        else
        {
            // change to default color
            GetComponent<SpriteRenderer> ().material = defaultColor;
        }
        selected = !selected;
        
        //todo - remove comment
        //Debug.Log("x, y = " + xPos + ", " + yPos);
        
        

    }

    private void OnMouseEnter()
    {
        // ignore hover color if dot has been selected
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = hoverColor;
        }
    }
    
    private void OnMouseExit()
    {
        // ignore hover UNcolor if dot has been selected
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = defaultColor;
        }
    }
}
