using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CamFollow : NetworkBehaviour
{

    //NetworkTransform playerTransform
    GameObject cam;

    public Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        //player = transform.GetChild(0).gameObject;
        cam = GameObject.Find("Main Camera");

        //if (!isLocalPlayer) { cam.SetActive(false); }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocalPlayer) { return; }
        cam.transform.position = transform.position + camOffset;
    }
}
