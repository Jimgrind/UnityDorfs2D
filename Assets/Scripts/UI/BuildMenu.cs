using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{

    int slotHeight;
    int slotPadding;

    List<GameObject> blueprints;
    //List<Text> textFields;
    //Text panelText;

    public GameObject forge;
    public GameObject stockpile;
    public GameObject stairs;

    public GameObject slotPrefab;
    GameObject tempSlot;

    // Start is called before the first frame update
    void Start()
    {

        blueprints = new List<GameObject>();
        blueprints.Add(forge);
        blueprints.Add(stockpile);
        blueprints.Add(stairs);

        int i = 0;
        foreach(GameObject bp in blueprints) {
            //textFields.Add(inventory.AddComponent<Text>());
            Debug.Log("Adding Text");
            Debug.Log(bp.name);
            tempSlot = Instantiate(slotPrefab, transform.position + Vector3.up*i*1.2f, Quaternion.identity);
            Debug.Log("Creating Slot at " + (transform.position + Vector3.up * i));
            tempSlot.GetComponent<BuildMenuSlot>().Init("The Text", bp.name);
            tempSlot.transform.SetParent(transform);

            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
