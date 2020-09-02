using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZMovement : MonoBehaviour
{


    //public GameObject gm_game_object;
    public GridManager gm;
    private Vector3 offset;
    public bool goesDown;
    //public Grid grid;
    private int duration;

    //public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Grid_Manager temp = gm_game_object.GetComponent<Grid_Manager>();

        //Build the offset vector
        offset = new Vector3(0, goesDown ? gm.Offset * -1 : gm.Offset, 0);
        duration = 0;

        //Flip the functions
        if (goesDown) {
            GetComponent<Transform>().Rotate(0, 0, 180);
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    // All of this likely needs to be rewritten when multiple entities are using it.
    //Possibly move the duration tracking to the entities being teleported (player, enemies, etc)
    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log("Triggered");
        if (obj.gameObject.tag == ("Player"))
        {
            duration += 1; //This should prevent teleports induced before colliders push the player back
            if (duration > 2) {
                obj.gameObject.transform.Translate(obj.gameObject.transform.InverseTransformVector(offset));
            }
        }
    }
    
    //moving the duration would ping the leaving object, telling it to reset its counter.
    void OnTriggerLeave2D(Collider2D obj) {
        duration = 0;
    }

    /*
    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log("Triggered");
        Vector3 pos = obj.transform.position;
        Vector3 pf = obj.gameObject.transform.position;

        

        if (obj.gameObject.tag == ("Player") && Input.GetKey(KeyCode.R))
        {
            obj.gameObject.transform.Translate(new Vector3(1, 0, 0) * grid.cellSize.x * ((gm.GetSize().x) + gm.GetBorder()));
        } else if (obj.gameObject.tag == ("Player") && Input.GetKey(KeyCode.F))
        {
            obj.gameObject.transform.Translate(new Vector3(-1, 0, 0) * grid.cellSize.x * ((gm.GetSize().x) + gm.GetBorder()));
        }

    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
