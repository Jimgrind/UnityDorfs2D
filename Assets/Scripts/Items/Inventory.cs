using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    static ItemDB database;

    // Start is called before the first frame update
    void Start()
    {
        items.Insert(0, database.GetItem(0));
        items.Insert(1, database.GetItem(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
