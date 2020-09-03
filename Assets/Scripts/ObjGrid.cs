using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjGrid : MonoBehaviour {
    //Exists to store objects and be able to refer to them as if this were a tilemap.
    //Uses stacks of each.
    private Stack head;
    
    public void add(GameObject obj) {

    }

    public void remove(GameObject obj) {

    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO make objects add themselves into the stacks on their initialization
        
    }

    //Search through an object type, for one at coords.
    public GameObject getObjAt(Vector2 point) {
        return null;
    }
    //Likely want to remove this, instead use tilemap images whenever possible.
    public bool isObjAt(Vector2 point, string type) {
        return false;
        //return (getObjAt(point).name == type);
    }

    void Update() {}

}
