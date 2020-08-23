using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorGen : TileGenBase
{
    public Tile t;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        print(size);
        for(int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                for (int k = 0; k < size.z; k++)
                {
                    for (int l = 0; l < border; l++)
                    {
                        Vector3Int pos = new Vector3Int(i + l*(size.x + border), j, k);
                        tilemap.SetTile(pos, t);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
