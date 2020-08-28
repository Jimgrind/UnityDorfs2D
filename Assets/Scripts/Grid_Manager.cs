using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{

    public Vector3Int size;
    public int border;

    // Start is called before the first frame update

    public Vector3Int GetSize()
    {
        return size;
    }

    public int GetBorder()
    {
        return border;
    }
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
