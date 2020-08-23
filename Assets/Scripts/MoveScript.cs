using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MoveScript : MonoBehaviour
{
    Rigidbody2D playerRigid;
    Tilemap curr_tilemap;
    Tilemap up_tilemap;
    Tilemap down_tilemap;
    public float speed = 30;
    public Camera cam;
    float cancelDist = 20;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   

        //We will need to fix diagonal movement eventually
        float hoInput = Input.GetAxisRaw("Horizontal");
        float veInput = Input.GetAxisRaw("Vertical");

        playerRigid.MovePosition(playerRigid.position + (new Vector2(hoInput, veInput).normalized * speed * Time.deltaTime) );

        //Rotation
        float y = Input.mousePosition.y - (Screen.height/2);
        float x = Input.mousePosition.x - (Screen.width/2);
        float angle = Mathf.Atan2(y,x);

        if(new Vector2(x,y).magnitude > cancelDist){
          playerRigid.MoveRotation((Mathf.Rad2Deg*angle)-90);
        }

    }
}
