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
    string pathField;
    // Start is called before the first frame update

    public void Init(string text, string title) {
        Debug.Log("Initializing Slot");

        textObject = new GameObject();
        textObject.transform.parent = transform;
        textObject.AddComponent<Text>();

        t = GetComponent<RectTransform>();

        this.text = text;
        this.pathField = title;

        Debug.Log(text);
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
        //Debug.Log(t.localScale);

    }
}
