using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LinkedList
{
    public TileObject data;
    protected LinkedList next = null;
    protected LinkedList prev = null;

    // Start is called before the first frame update
    
    public LinkedList(TileObject obj)
    {
        data = obj;
    }

    //Call this remove function when an object is removed by other means. 
    //May need to be moved to another object or changed to be found before call
    public void remove()
    {
        //unlink
        if (prev == null)
        {
            // Changing the head
            GameObject.Find("Grid").GetComponent<ObjGrid>().resetHead(next);
        }
        else
        {
            prev.next = next;
        }
        if (next != null) next.prev = prev;
    }

    public void setPrev(LinkedList obj)
    {
        if (prev == null) Debug.Log("List could encounter error!");
        prev = obj;
        obj.next = this;
    }

    public GameObject getObject(int x, int y)
    {
        if (data.x == x && data.y == y)
            return data.gameObject;
        if (next == null) return null;
        return next.getObject(x, y);
    }
}
