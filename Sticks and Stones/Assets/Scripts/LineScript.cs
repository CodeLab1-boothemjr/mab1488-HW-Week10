using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    //todo - add code for changing colors

    private int[] anchor;
    private int[] endPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoordinates(int x1, int y1, int x2, int y2)
    {
        anchor = new[] {x1, y1};
        endPoint = new[] {x2, y2};
    }

    List<int[]> GetCoordinates()
    {
        return new List<int[]>(){anchor, endPoint};
    }
}
