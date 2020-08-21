using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Miner : MonoBehaviour
{

    public GameObject gridGameObject;
    Rigidbody2D playerRigid;
    public Camera cam;

    Tilemap tilemap;
    Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        if (gridGameObject != null)
        {
            grid = gridGameObject.GetComponent<Grid>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector3Int mp = new Vector3Int((int) Mathf.Floor(mouse.x), (int) Mathf.Floor(mouse.y), (int) Mathf.Ceil(mouse.z));
        //if (Input.GetButton("Fire1") && tilemap != null)
        //{
        //    if(tilemap.GetTile(mp))
         //   {
        //        Debug.Log(mp);
        //        if (tilemap.GetTile(mp).name == "Wal") 
        //        {
        //            tilemap.SetTile(tilemap.WorldToCell(mp), null);
        //        }
        //    } else
        //    {
         //       Debug.Log("No Tile Found at " + mp);
        //    }
        //}
    }
}
