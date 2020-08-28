using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Miner : MonoBehaviour
{

    public GameObject gridGameObject;
    public GameObject tileMapGameObject;
    
    public Camera cam;

    public string[] Mineable;

    Rigidbody2D playerRigid;

    Tilemap tilemap;
    Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        if (gridGameObject != null)
        {
            grid = gridGameObject.GetComponent<Grid>();
            tilemap = tileMapGameObject.GetComponent<Tilemap>();
        }

        // List of all mineable blocks
        Mineable = new string[5];
        Mineable[0] = "Wal";
        Mineable[1] = "Wall";
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mp = new Vector3Int((int) Mathf.Floor(mouse.x), (int) Mathf.Floor(mouse.y), 0);
        if (Input.GetButton("Fire1") && tilemap != null)
        {
            if(tilemap.GetTile(mp))
            {
                //Debug.Log(mp);
                //Debug.Log(tilemap.GetTile(mp).name);
                if (tilemap.GetTile(mp).name == "Wal") 
                {
                    tilemap.SetTile(tilemap.WorldToCell(mp), null);
                    //Debug.Log("Setting Tile at " + mp + " To NULL");
                }
            } else
            {
                Debug.Log("No Tile Found at " + mp);
            }
        }
    }
}
