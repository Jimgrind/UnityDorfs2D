using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGen : TileGenBase
{
    public Tile wall;

    private void Rect(Tile tile,int x1, int y1, int x2, int y2){

      for(int i = x1;i < x2;i++){

        for(int j = y1;j < y2;j++){

          gm.map.SetTile(new Vector3Int(i,j,0),tile);

        }
      }
    }

    private void FillLayer(Tile tile,int layer){

      Rect(tile,offset*layer+gm.bufferSize,gm.bufferSize,offset*(layer+1),offset);
    }

    // Start is called before the first frame update
    void Start(){

        Init();

        for(int i = 0;i < gm.numLayers;i++){
          FillLayer(wall,i);
        }
    }

    // Update is called once per frame
    void Update(){

    }
}
