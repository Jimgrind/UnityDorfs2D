using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuSlot : MonoBehaviour
{

    Text textField;
    SpriteRenderer icon;
    RectTransform t;
    string text;
    string pathField;
    // Start is called before the first frame update

    public void Init(string text, string title) {
        Debug.Log("Initializing Slot");
        textField = transform.Find("Text").gameObject.GetComponent<Text>();
        icon = transform.Find("Icon").gameObject.GetComponent<SpriteRenderer>();
        t = GetComponent<RectTransform>();

        this.text = text;
        this.pathField = title;

        this.textField.text = text;
        icon.sprite = Resources.Load<Sprite>("Assets/Buildings/" + pathField);
    }

    void Start() {
        t.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(t.localScale);

    }
}
