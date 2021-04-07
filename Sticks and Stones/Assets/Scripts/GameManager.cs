using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int gridX = 3;
    private readonly int gridY = 3;
    
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
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                var dot = Instantiate(dotPrefab);
                dot.transform.position = new Vector3(x, y);
            }
        }
    }
}
