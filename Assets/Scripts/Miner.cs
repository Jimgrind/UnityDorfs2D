using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Tilemaps;

public class Miner : NetworkBehaviour
{

    public Tile floor;
    public Tile wall;

    Tilemap tm;
    Grid g;
    Camera cam;
    Vector3Int tile_position;
    // Start is called before the first frame update
    void Start()
    {
        tm = GameObject.Find("Solids").GetComponent<Tilemap>();
        g = GameObject.Find("Grid").GetComponent<Grid>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        tile_position = new Vector3Int();
    }

    // Update is called once per frame
    [Client]
    void Update()
    {
        if(!isLocalPlayer) { return; }   

        if(g != null && tm != null && Input.GetButtonDown("Fire1")) {
            Debug.Log("Clicked");
            tile_position = g.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));

            if(tm.GetTile(tile_position) == wall) {
                Mine_Cmd(tile_position);
            }
        }
    }

    [Command]
    void Mine_Cmd(Vector3Int pos) {
        //Checks
        if (((transform.position - new Vector3(0.5f, 0.5f, 0)) - (Vector3)pos).sqrMagnitude < 6) {
            Mine_Rpc(pos);
        }
    }

    [ClientRpc]
    void Mine_Rpc(Vector3Int pos) {
        tm.SetTile(pos, floor);
    }
}
