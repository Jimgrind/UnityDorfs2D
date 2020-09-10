using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPile : MonoBehaviour
{

    public string title;
    Dictionary<string, ItemStack> items;
    public ItemStack.ItemType type;
    Collider2D accessZone;


    // Start is called before the first frame update
    void Start()
    {
        
        items = new Dictionary<string, ItemStack>();
    }

    void Init(ItemStack.ItemType type) {
        this.type = type;
    }

    bool AddItem(ItemStack item) {
        if(item.type == this.type || this.type == ItemStack.ItemType.Main) {
            if(items[item.name] != null) {
                items[item.name].amount += item.amount;
            } else {
                items.Add(item.name, item);
            }
            return true;
        } else {
            return false;
        }
    }

    bool RemoveItem(ItemStack item, int amount) {
        if(items[item.name] != null && items[item.name].amount >= amount) {
            items[item.name].amount -= amount;
            return true;
        } else {
            return false;
        }
    }
}
