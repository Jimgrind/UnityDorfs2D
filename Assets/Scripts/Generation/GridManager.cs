using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{

    //Side length of the square of each "world layer"
    public int layerSize = 16;
    //The thickness in tiles of the buffer between world layers
    public int bufferSize = 6;
    //Number of levels
    public int numLayers = 10;

    public int offset; // This should be static, but if it is it will break things

    private int halfBuffer;

    // Terrain generation
    public Tilemap map;
    public Tile barrier;

    //Creates a rectangle of barrier tiles from bottom left to top right
    private void BarrierRect(int x1, int y1, int x2, int y2){

      for(int i = x1;i < x2;i++){

        for(int j = y1;j < y2;j++){

          map.SetTile(new Vector3Int(i,j,0),barrier);

        }
      }
    }

    /*

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

    //Horseshoes right-aligned
    private void BuildBarrier()
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
    */

    // Start is called before the first frame update.
    // Create borders
    void Start()
    {

      offset = layerSize + bufferSize;

      /*
      halfBuffer = bufferSize/2;

      int Xlength = numLayers*layerSize + (numLayers+1)*bufferSize;
      BarrierRect(0,0,Xlength,bufferSize);
      BarrierRect(0,offset-bufferSize,Xlength,offset);

      for(int i = 0;i < numLayers+1;i++){
        BarrierRect(i*offset-bufferSize,bufferSize,i*offset+bufferSize,offset-bufferSize);
      }
      */

      int Xlength = numLayers*layerSize + (numLayers+1)*bufferSize;
      BarrierRect(0,0,Xlength,bufferSize);
      BarrierRect(0,offset,Xlength,offset+bufferSize);

      for(int i = 0;i < numLayers+1;i++){
        BarrierRect(i*offset,bufferSize,i*offset+bufferSize,offset);
      }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
