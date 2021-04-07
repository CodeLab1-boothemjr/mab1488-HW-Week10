using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dotPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        DrawGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Draw the grid of dots
    void DrawGrid()
    {
        var dot = Instantiate(dotPrefab);
    }
}
