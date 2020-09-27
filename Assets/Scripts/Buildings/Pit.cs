using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pit : MonoBehaviour
{
    protected bool[] walls; // 4 walls, clockwise from left
    private GameObject[] effectors; // 4 collider effector pairs
    public bool spikes;
    Tilemap tilemap;
    ObjGrid handler; //This may end up inefficient and is possible to just replace throughougt code
    private Transform mask;

    public void setSpikes() {
        spikes = true;
        // set visuals
    }

    protected void setWalls() {
        //use the walls variable to build the image
        double px = 0; double py = 0; // positions
        double sx = 1; double sy = 1; // scales
        
        if (walls[0]) {
            px += 0.0625; sx -= 0.125;
            effectors[0].SetActive(true);
        } else effectors[0].SetActive(false);
        if (walls[1]) {
            py -= 0.0625; sy -= 0.125;
            effectors[1].SetActive(true);
        } else effectors[1].SetActive(false);
        if (walls[2]) {
            px -= 0.0625; sx -= 0.125;
            effectors[2].SetActive(true);
        } else effectors[2].SetActive(false);
        if (walls[3]) {
            py += 0.0625; sy -= 0.125;
            effectors[3].SetActive(true);
        } else effectors[3].SetActive(false);

        Debug.Log("Pit refreshed with walls: " + walls[0] + "" + walls[1] + "" + walls[2] + "" + walls[3]);
        Debug.Log("old mask Pos: " + mask.localPosition.ToString() + " size: " + mask.lossyScale.ToString());
        Debug.Log("new mask sizing: " + px + " " + py + " size " + sx + " " + sy);
        mask.localPosition = new Vector3((float) px, (float) py, 0);
        mask.localScale = new Vector3((float) sx, (float) sy, 0);

    }
    
    void Start()
    {
        gameObject.name = "pitCover";
        effectors = new GameObject[4];
        EdgeCollider2D[] temp = gameObject.GetComponentsInChildren<EdgeCollider2D>(true);
        for (int i = 0; i<4; ++i) {
            effectors[i] = temp[i].gameObject;
        }

        mask = gameObject.GetComponentInChildren<SpriteMask>().gameObject.transform;
        tilemap = GameObject.Find("Solids").GetComponent<Tilemap>();
        TileObject location = gameObject.GetComponent<TileObject>();
        int x = location.x;
        int y = location.y;

        walls = new bool[4];
        walls[0] = true; walls[1] = true; walls[2] = true; walls[3] = true;

        handler = location.Handler;
        
        //Does not count for corners. This could be done to make it look better, but likely will not.
        // The script can encounter a null reference error in the rare case that two pits are 
        // placed next to each other simultaniously, but no real problem will occur.
        //Left
        if (tilemap.GetTile(new Vector3Int(x-1, y, 0)).name == "pit") {
            walls[0] = false;
            //tell the other pit.walls[2] = false; and update it
            Pit side = handler.getObjAt(x-1, y).GetComponent<Pit>();
            side.walls[2] = false;
            side.setWalls();
        }
        //Up
        if (tilemap.GetTile(new Vector3Int(x, y+1, 0)).name == "pit") {
            walls[1] = false;
            //tell the other pit.walls[3] = false; and update it
            Pit side = handler.getObjAt(x, y+1).GetComponent<Pit>();
            side.walls[3] = false;
            side.setWalls();
        }
        //Right
        if (tilemap.GetTile(new Vector3Int(x+1, y, 0)).name == "pit") {
            walls[2] = false;
            //tell the other pit.walls[0] = false; and update it
            Pit side = handler.getObjAt(x+1, y).GetComponent<Pit>();
            side.walls[0] = false;
            side.setWalls();
        }
        //Down
        if (tilemap.GetTile(new Vector3Int(x, y-1, 0)).name == "pit") {
            walls[3] = false;
            //tell the other pit.walls[1] = false; and update it
            Pit side = handler.getObjAt(x, y-1).GetComponent<Pit>();
            side.walls[1] = false;
            side.setWalls();
        }
        setWalls();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
