using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{

    public GameObject forge;
    public GameObject stockpile;
    public GameObject stairs;

    public GameObject inventory;

    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isActive = !isActive;
        }

        inventory.SetActive(isActive);
    }
}
