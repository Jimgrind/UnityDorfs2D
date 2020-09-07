using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{

    public int Offset = 64; // This should be static, but if it is it will break things
    public int levels = 10;
    private int Half;

    // Terrain generation
    public Tilemap map;
    public Tile barrier;

    private void BuildWall(float offset)
    {
        for (int x = (int) (Offset * (offset - 0.5) - 3); x < (int) (Offset * (offset - 0.5) + 3); ++x)
        {
            for (int y= -Half -3; y < Half + 3; ++y)
            {
                map.SetTile(new Vector3Int(x, y, 0), barrier);
            }
        }
    }

    //Builds a right-aligned U shape of barrier
    private void BuildBarrier(float offset)
    {
        BuildWall(offset+1);
        for (int x = (int) (Offset * (offset - 0.5) + 3); x < (int) (Offset * (offset + 0.5) - 3); ++x)
        {
            //Bottom wall
            for (int y = -Half -3; y< -Half; ++y)
            {
                map.SetTile(new Vector3Int(x, y, 0), barrier);
            }
            //Top wall
            for (int y = Half; y < Half + 3; ++y)
            {
                map.SetTile(new Vector3Int(x, y, 0), barrier);
            }
        }
    }

    // Start is called before the first frame update.
    // Create borders
    void Start()
    {
        Half = Offset / 2;
    
        BuildWall(0); //Cap it off
        for (int i = 0; i < levels; ++i)
        {
            BuildBarrier(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
