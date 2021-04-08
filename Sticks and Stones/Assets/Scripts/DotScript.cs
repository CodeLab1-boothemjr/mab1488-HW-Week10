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
    
    // Start is called before the first frame update
    void Start()
    {
        selected = false; // start the dot as not selected
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        // if already selected when clicked
        if (selected)
        {
            // change to default color
            GetComponent<SpriteRenderer> ().material = defaultColor;
        }
        // if not already selected when clicked
        else
        {
            // change to selected color
            GetComponent<SpriteRenderer> ().material = selectedColor;
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
