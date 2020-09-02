using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Miner : MonoBehaviour
{

    public GameObject gridGameObject;
    public GameObject tileMapGameObject;

    //We will likely want to move this to a list in another object
    public Tile flooring;
    
    public Camera cam;
    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mp = new Vector3Int((int) Mathf.Floor(mouse.x), (int) Mathf.Floor(mouse.y), 0);
        if (Input.GetButtonDown("Fire1") && tilemap != null)
        {
            TileBase targ = tilemap.GetTile(mp);
            //Debug.Log(mp);
            //Debug.Log(tilemap.GetTile(mp).name);
            switch (targ.name) {
                case "Wal":
                    tilemap.SetTile(tilemap.WorldToCell(mp), flooring);
                    break;
                case "Wall":
                    tilemap.SetTile(tilemap.WorldToCell(mp), flooring);
                    break;

                case null:
                    Debug.Log("No Tile Found at " + mp);
                    break;

                default:
                    break;
            }
        }
    }
}
