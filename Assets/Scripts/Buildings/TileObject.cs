using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public int x;
    public int y;

    public ObjGrid Handler;

    // Start is called before the first frame update
    void Start()
    {
        Handler = GameObject.Find("Grid").GetComponent<ObjGrid>();
        x = (int) gameObject.transform.position.x;
        y = (int) gameObject.transform.position.y;

        Handler.add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
