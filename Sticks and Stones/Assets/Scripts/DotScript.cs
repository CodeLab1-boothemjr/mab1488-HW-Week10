using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour
{
    // Place to store the different materials use to differentiate between the state of the dots
    public Material defaultColor;   //material for when not interacting with the dot
    public Material hoverColor;     //material for hovering over the dot
    public Material selectedColor;  //material for selected dot

    private Boolean selected;       //variable to determine if the dot is currently selected
    
    public int[] coordinates;       //place to store the coordinates of the dots
    
    // Start is called before the first frame update
    void Start()
    {
        selected = false;           //start all the dots as not selected
    }

    // Stores the coordinates of the dot in the game object
    public void SetCoordinates(int x, int y)
    {
        coordinates = new[] {x, y};
    }
    
    public int[] GetCoordinates()
    {
        return coordinates;         //give the coordinates of the dot
    }
    
    // todo: consider removing if unused
    public string CoordinatesToString()
    {
        return "x, y = " + coordinates[0] + ", " + coordinates[1];
    }
    
    public void SelectDot()
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
        
    }

    // When the mouse is over the dot
    private void OnMouseEnter()
    {
        // ignore hover color if dot has been selected
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = hoverColor;  //change the color of the material to indicate that the mouse is over it
        }
    }
    
    // When the mouse leaves the dot
    private void OnMouseExit()
    {
        // ignore hover UNcolor if dot has been selected
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = defaultColor; //change the color of the material to indicate that the mouse left the dot
        }
    }
}