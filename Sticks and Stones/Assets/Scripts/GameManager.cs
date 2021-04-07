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
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                var dot = Instantiate(dotPrefab);
                dot.transform.position = new Vector3(x, y);
            }
        }
    }
}
