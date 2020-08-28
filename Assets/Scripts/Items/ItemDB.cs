using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{

    public List<Item> items = new List<Item>();


    void Generate_Items()
    {
        items = new List<Item>()
        {
            new Item(0, "pickaxe", "A Dope-ass pickaxe"),
            new Item(1, "stairs", "Some solid stairs")
        };
    }

    public Item GetItem(int id)
    {
        return items.Find(items => items.id == id);
    }

    public Item GetItem(string title)
    {
        return items.Find(items => items.title == title);
    }

    private void Awake()
    {
        Generate_Items();
    }

}
