using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int angle = 0;

        foreach (Transform child in transform) {
            angle += 90; // TODO make this a random +- some ammount for variation
            child.Rotate(new Vector3(0, 0, angle));
        }
        transform.Rotate(new Vector3(0, 0, angle-30)); // move the whole thing a bit

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
