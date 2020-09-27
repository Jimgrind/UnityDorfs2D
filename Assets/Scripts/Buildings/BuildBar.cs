using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Handles the visuals and duration portion of building, upgrading, or destroying.
public class BuildBar : MonoBehaviour
{

    public string title;
    public GameObject target; // build target
    public GameObject builder; // the one making it
    public int duration; // target time
    private int distance; // maximum distance you can build from
    private int time; // current build time

    public void connect(string name, GameObject b, GameObject t, int T, int dist = 4) {
        title = name;
        target = t;
        duration = T;
        builder = b;
        distance = dist;
        Debug.Log("Construction Begins.");
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
            builder.GetComponent<Build>().finish(title);
            Destroy(gameObject);
        }
        ++time;
    }
}
