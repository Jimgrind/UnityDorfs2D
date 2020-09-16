using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileGenBase : MonoBehaviour
{

    protected GridManager gm;
    protected int offset;

    protected void Init()
    {
        gm = GetComponent<GridManager>();
        offset = gm.layerSize + gm.bufferSize;
    }
}
