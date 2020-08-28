using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ZMovement : MonoBehaviour
{


    public GameObject gm_game_object;
    Grid_Manager gm;
    Grid grid;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (gm_game_object != null)
        {
            gm = gm_game_object.GetComponent<Grid_Manager>();
            grid = gm_game_object.GetComponent<Grid>();
        }
        else
        {
            Debug.Log("No Grid Manager Found");
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        Debug.Log("Triggered");
        Vector3 pos = obj.transform.position;
        Vector3 pf = obj.gameObject.transform.position;

        

        if (obj.gameObject.tag == ("Player") && Input.GetKeyDown(KeyCode.R))
        {
            obj.gameObject.transform.Translate(new Vector3(1, 0, 0) * grid.cellSize.x * ((gm.GetSize().x) + gm.GetBorder()));
        } else if (obj.gameObject.tag == ("Player") && Input.GetKeyDown(KeyCode.F))
        {
            obj.gameObject.transform.Translate(new Vector3(-1, 0, 0) * grid.cellSize.x * ((gm.GetSize().x) + gm.GetBorder()));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
