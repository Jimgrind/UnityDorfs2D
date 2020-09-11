using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject buildMenu;
    public GameObject inventory;
    bool isBuildMenuActive;
    // Start is called before the first frame update
    void Start()
    {
        isBuildMenuActive = false;
        buildMenu.SetActive(isBuildMenuActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isBuildMenuActive = !isBuildMenuActive;
            //Debug.Log(isBuildMenuActive);
            buildMenu.SetActive(isBuildMenuActive);
        }
    }
}
