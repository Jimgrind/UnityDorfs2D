using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuSlot : MonoBehaviour
{

    GameObject textObject;
    Text textField;
    Font arial;
    
    RectTransform t;
    string text;
    int buildingID;
    // Start is called before the first frame update

    public void Init(string objectName, int buildingID) {
        Debug.Log("Initializing Slot");

        textObject = new GameObject();
        textObject.transform.parent = transform;
        textObject.name = "Build Slot";
        textObject.AddComponent<Text>();
        //textObject.AddComponent<Button>();

        t = GetComponent<RectTransform>();

        this.text = objectName;
        this.buildingID = buildingID;

        Debug.Log(objectName);
    }

    void Start() {
        textField = textObject.GetComponent<Text>();
        t = GetComponent<RectTransform>();

        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        textField.text = text;
        textField.font = arial;

        t.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
