using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileGenBase : MonoBehaviour
{
    protected Vector3Int size;

    protected int border;

    public GameObject gm_game_object;
    private GridManager gm;
    protected Tilemap tilemap;


    protected void Init()
    {
        if(gm_game_object != null)
        {
            gm = gm_game_object.GetComponent<GridManager>();
        } else
        {
            Debug.Log("No Grid Manager Found");
        }
        //size = gm.GetSize();
        //border = gm.GetBorder();
        //tilemap = GetComponent<Tilemap>();
        
        //Debug.Log("Size: " + size);
        //Debug.Log("Border " + border);
    }
}
