using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjGrid : MonoBehaviour {
    //Exists to store objects and be able to refer to them as if this were a tilemap.
    private LinkedList[] head;
        
    public void add(TileObject obj) {
        int spot = Hash(obj.x, obj.y);
        LinkedList newObj = new LinkedList(obj);
        if (head[spot] == null)
        {
            head[spot] = newObj;
        } else
        {
            head[spot].setPrev(newObj);
            head[spot] = newObj;
        }
    }

    // It may be unneeded to remove items from this side
    /*public void remove(GameObject obj) {
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //TODO make objects add themselves into the stacks on their initialization
        head = new LinkedList[16];
    }

    //Search through an object type, for one at coords.
    public GameObject getObjAt(int x, int y) {
        return head[Hash(x, y)].getObject(x, y);
    }

    //Likely want to remove this, instead use tilemap images whenever possible.
    /*public bool isObjAt(Vector2 point, string type) {
        return false;
        //return (getObjAt(point).name == type);
    }*/

    // Used to reset the head of a portion of the hash
    // Re-hashing is perfectly ok because it will get the same data as it did when it was put here.
    public void resetHead(LinkedList obj)
    {
        head[Hash(obj.data.x, obj.data.y)] = obj;
    }

    void Update() {}

    private int Hash(int x, int y) {
        return 0;
    }
}
