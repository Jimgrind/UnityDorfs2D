using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MoveScript : MonoBehaviour
{
    Rigidbody playerRigid;
    Tilemap curr_tilemap;
    Tilemap up_tilemap;
    Tilemap down_tilemap;
    public float speed = 30;
    public GameObject gridGameObject;
    public Camera cam;
    float cancelDist = 20;
    Grid grid;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        //Transform transform;
        if (gridGameObject != null)
        {
            grid = gridGameObject.GetComponent<Grid>();
        }
    }

    void Stairs()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mp = new Vector3Int((int) Mathf.Floor(mouse.x), (int) Mathf.Floor(mouse.y), (int) Mathf.Ceil(mouse.z));
        if (Input.GetButton("Fire1") && curr_tilemap != null)
        {
            Debug.Log("Checking Stairs");
            if(curr_tilemap.GetTile(mp))
           {
                Debug.Log(mp);
                if (curr_tilemap.GetTile(mp).name == "Stairs")
                {
                    Debug.Log("TP");
                    transform.TransformPoint(new Vector3(0,0,transform.position.z - 1));
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {   
        foreach(Tilemap tilemap in grid.GetComponentsInChildren<Tilemap>()) {
            if(tilemap.origin.z == Mathf.Ceil(transform.position.z))
            {
                curr_tilemap = tilemap;
                Debug.Log("Found Tilemap");
                break;
            }
        }

        Stairs();
        //We will need to fix diagonal movement eventually
        float hoInput = Input.GetAxisRaw("Horizontal");
        float veInput = Input.GetAxisRaw("Vertical");

        playerRigid.MovePosition(playerRigid.position + (new Vector3(hoInput, veInput, 0).normalized * speed * Time.deltaTime) );

        //Rotation
        float y = Input.mousePosition.y - (Screen.height/2);
        float x = Input.mousePosition.x - (Screen.width/2);
        float angle = Mathf.Atan2(y,x);

        if(new Vector2(x,y).magnitude > cancelDist){
          //playerRigid.MoveRotation((Mathf.Rad2Deg*angle)-90);
        }

    }
}
