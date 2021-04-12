using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    //private int[] sides; 
    //

    private int[] anchor;
    private List<int[]> side1;
    private List<int[]> side2;
    private List<int[]> side3;
    private List<int[]> side4;

    
    // anchor var
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // anchor is the bottom left most point of the box
    public void SetAnchor(int x, int y)
    {
        anchor = new[] {x, y};
        side1 = new  List<int[]>(){new int[]{x, y}, new int[]{x, y+1}};
        side2 = new  List<int[]>(){new int[]{x, y+1}, new int[]{x+1, y+1}};
        side3 = new  List<int[]>(){new int[]{x+1, y+1}, new int[]{x+1, y}};
        side4 = new  List<int[]>(){new int[]{x+1, y}, new int[]{x, y}};
        
        //todo - remove, debug only
        //Debug.Log("anchor is " + anchor[0] + ", " + anchor[1]);
    }

    public void HideBox()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ShowBox()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
    
    
}
