using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Stack : MonoBehaviour
{

    private GameObject[] list;
    private Stack next;
    private int length;
    private int spot; // The current end fill location. list[spot] should be empty

    //Key the info based on the coordinate system, as that is what is being searched for.

    // Start is called before the first frame update
    void Start()
    {
        length = 8;
        spot = 0;
        list = new GameObject[length];
        next = null;
    }

    protected void remove(GameObject obj) {

    }

    public GameObject getObjAt(Vector2Int point) {
        GameObject found = null;
        for (int i=0; i<spot; ++i) {
            found = list[i];
            if (point.x == found.GetComponent<TileObject>().x && point.y == found.GetComponent<TileObject>().y) //Match coordinates
                return list[i];
        }
        // Proceed to next portion of stack
        if (next != null)
            found = next.getObjAt(point);
        return found;
    }

    public bool isObjAt(Vector2Int point, string type) {
        return (type == getObjAt(point).name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
