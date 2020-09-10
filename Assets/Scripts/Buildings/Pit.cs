using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pit : MonoBehaviour
{
    protected bool[] walls;
    public bool spikes;
    Tilemap tilemap;
    ObjGrid handler; //This may end up inefficient and is possible to just replace throughougt code


    protected void setWalls() {
        //use the walls variable to build the image
    }
    
    void Start()
    {
        tilemap = GameObject.Find("Solids").GetComponent<Tilemap>();
        TileObject location = gameObject.GetComponent<TileObject>();
        int x = location.x;
        int y = location.y;

        walls = new bool[4];
        walls[0] = true; walls[1] = true; walls[2] = true; walls[3] = true;

        handler = location.Handler;
        
        //Does not count for corners. This could be done to make it look better, but likely will not.
        //Left
        if (tilemap.GetTile(new Vector3Int(x-1, y, 0)).name == "Pit") {
            walls[0] = false;
            //tell the other pit.walls[2] = false; and update it
            handler.getObjAt(new Vector2Int(x-1, y));
        }
        //Up
        if (tilemap.GetTile(new Vector3Int(x, y+1, 0)).name == "Pit") {
            walls[1] = false;
            //tell the other pit.walls[3] = false; and update it
        }
        //Right
        if (tilemap.GetTile(new Vector3Int(x+1, y, 0)).name == "Pit") {
            walls[2] = false;
            //tell the other pit.walls[0] = false; and update it
        }
        //Down
        if (tilemap.GetTile(new Vector3Int(x, y-1, 0)).name == "Pit") {
            walls[3] = false;
            //tell the other pit.walls[1] = false; and update it
        }
        setWalls();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
