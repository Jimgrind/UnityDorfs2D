using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pit : MonoBehaviour
{
    protected bool[] walls;
    public bool spikes;
    Tilemap tilemap;
    // Start is called before the first frame update

    protected void setWalls() {
        //use the walls variable to build the image
    }

    void Start()
    {
        walls = new bool[4];
        walls[0] = true; walls[1] = true; walls[2] = true; walls[3] = true;

        int x, y;
        x = gameObject.transform.localPosition.x;
        y = gameObject.transform.localPosition.y;
        
        //Does not count for corners. This could be done to make it look better, but likely will not.
        //Left
        if (tilemap.GetTile(new Vector3Int(x-1, y, 0)).name == "Pit") {
            walls[0] = false;
            //tell the other pit.walls[2] = false; and update it
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
