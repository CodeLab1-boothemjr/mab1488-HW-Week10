using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour
{
    public Material defaultColor;
    public Material hoverColor;
    public Material selectedColor;

    private Boolean selected;
    
    // Start is called before the first frame update
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        if (selected)
        {
            GetComponent<SpriteRenderer> ().material = defaultColor;
        }
        else
        {
            GetComponent<SpriteRenderer> ().material = selectedColor;
        }
        selected = !selected;
    }

    private void OnMouseEnter()
    {
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = hoverColor;
        }
    }
    
    private void OnMouseExit()
    {
        if (!selected)
        {
            GetComponent<SpriteRenderer> ().material = defaultColor;
        }
    }
}
