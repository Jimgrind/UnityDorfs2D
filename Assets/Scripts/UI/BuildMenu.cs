using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Material {
    STONE,
    WOOD,
    IRON
}

public struct BuildItem {
    public uint id;
    public string name;
    public string assetPath;
    public Dictionary<Material, int> creqs; // Crafting Requirement
}

public class BuildMenu : MonoBehaviour
{
    
    int slotHeight;
    int slotPadding;

    List<BuildItem> blueprints;
    //List<Text> textFields;
    //Text panelText;

    public GameObject slotPrefab;
    GameObject tempSlot;

    // Start is called before the first frame update
    void Start()
    {

        AddBuildItems();

        int i = 0;
        foreach(BuildItem bp in blueprints) {
            //textFields.Add(inventory.AddComponent<Text>());
            tempSlot = Instantiate(slotPrefab, transform.position + Vector3.up*i*1.2f, Quaternion.identity);
            Debug.Log("Creating Slot at " + (transform.position + Vector3.up * i));
            tempSlot.GetComponent<BuildMenuSlot>().Init(bp.name, 0);
            tempSlot.transform.SetParent(transform);

            i++;
        }
    }

    void AddBuildItems() {
        //Material and Corresponding amount
        blueprints = new List<BuildItem>();
        Dictionary<Material, int> tmpreqs = new Dictionary<Material, int>();

        tmpreqs.Add(Material.STONE, 0);
        tmpreqs.Add(Material.IRON, 0);
        tmpreqs.Add(Material.WOOD, 0);


        tmpreqs[Material.STONE] = 4;
        tmpreqs[Material.IRON] = 5;
        tmpreqs[Material.WOOD] = 4;

        blueprints.Add(new BuildItem() { id = 1, name = "forge", assetPath = "Assets/Prefabs/forge", creqs = tmpreqs });
        blueprints.Add(new BuildItem() { id = 1, name = "stockpile", assetPath = "Assets/Prefabs/stockpile", creqs = tmpreqs });
        blueprints.Add(new BuildItem() { id = 1, name = "stairs", assetPath = "Assets/Prefabs/stairs", creqs = tmpreqs });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
