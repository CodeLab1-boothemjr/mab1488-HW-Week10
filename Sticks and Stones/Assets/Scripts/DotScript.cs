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
    
    public int[] coordinates;
    
    
    // Start is called before the first frame update
    void Start()
    {
        selected = false; // start the dot as not selected
    }

    // stores the coordinates of the dot in the game object
    public void SetCoordinates(int x, int y)
    {
        coordinates = new[] {x, y};
    }
    
    public int[] GetCoordinates()
    {
        return coordinates;
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
