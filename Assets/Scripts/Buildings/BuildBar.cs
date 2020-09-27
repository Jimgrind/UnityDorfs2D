using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Handles the visuals and duration portion of building, upgrading, or destroying.
public class BuildBar : MonoBehaviour
{
    public GameObject target; // build target
    public GameObject builder; // the player making it
    public int duration; // target time
    private double distance; // maximum distance you can build from
    private int time; // current build time

    // Used for game object interactions
    public void connect(GameObject b, GameObject t, int T, double dist = 3) {
        target = t;
        duration = T;
        builder = b;
        distance = dist;
        Debug.Log("Construction Begins.");
    }

    // Used for mining, or non-object stuff (ores, walls, etc)
    public void connect(GameObject b, string title, int T, double dist = 3) {
        builder = b;
        gameObject.name = title;
        duration = T;
        distance = dist;
        target = this.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update visuals

        //Take cases for canceling. May need to change distance calculator; it may calculate from the wrong point (bottom left, not center)
        if (Input.GetButtonUp("ContextUse")) {
            Debug.Log("Construction halted.");
            Destroy(gameObject);
        }
        if (Vector3.Distance(builder.transform.position, target.transform.position) > distance) {
            Debug.Log("Construction Interupted.");
            Destroy(gameObject);
        }
        
        //Complete the process
        if (time >= duration) {
            //Send the build message
            Debug.Log("Construction Complete.");
            if (target == this.gameObject) {
                builder.GetComponent<Miner>().finish(gameObject.name, target.transform.position);
            } else {
                builder.GetComponent<Miner>().finish(target);
            }
            Destroy(gameObject);
        }
        ++time;
    }
}
