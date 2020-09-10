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
        int x, y;
        x = (int) gameObject.transform.localPosition.x;
        y = (int) gameObject.transform.localPosition.y;

        Handler.add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
