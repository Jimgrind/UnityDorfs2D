using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEngine.Serializable;

// Special cases to consider as NOT needing a build/dig: 
// (it is worth noting that a UI button does not need to be what calls these functions)
// mining stone, smoothing a wall
// EXTRA special: Mining ores, destroying stairs (will it be possible?)


public class Build : MonoBehaviour
{

    public Tile complex; // Placed under objects like stairs, forge, stockpile, etc
    public GameObject builder; // The building prefab

    //private GameObject worked;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(builder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void process(string built) { //, GameObject worked) {  Can't have more than one argument for some reason
        Debug.Log(builder);
        GameObject t;
        GameObject worked;

        //Tell the other clients / server where, and how big the thing being built is.

        Debug.Log(gameObject.transform);
        switch (built) {
            case "stairs":
                //Stairs will need some additional way to determine which direction to build them
                // or simply only allow them to go down
                Debug.Log("Stairs being built");
                // Determine location

                // Ensure capability:
                // check to make sure this target location and the other side
                // are both tiles that may be replaced: Stone, Floor
                // Alternitively, we could ensure they are NOT things that should not be replaced.
                
                break;

            case "forge":
                Debug.Log("frog being made");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles
                break;

            case "stockpile":
                Debug.Log("Stockpile being built");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles

                break;

            case "spikes": // Adding spikes to a pit. Make this only appear when a pit is targeted?
                // Find the relevant location
                // Ensure a pit is in the location
                break;

            case "pit":
                // Determine location
                // Ensure it is diggable: floor
                // Set the tile to pit
                // Create a "pitcover" instance on the location
                //t = Instantiate(builder, worked.transform);
                //t.GetComponent<BuildBar>().connect(built, this, worked, 100); // The last number is the time taken to build this.
                Debug.Log("Digging a pit");
                break;

            case "tree":
                //Get the tree
                worked = GameObject.Find("tree");
                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                //t = Instantiate(gameObject.GetComponent<Build>().builder, worked.transform);
                t.GetComponent<BuildBar>().connect(built, gameObject, worked, 100); // The last number is the time taken to build this.
                break;

            default:
                break;
        }
    }

    // Will later need to access inventory and build requirements;
    // or require these before the button can be pressed.
    // For now I just want to work towards building stuff
    
    public void finish(string built) {

        // Grid layout changes are already sent.
        // Tell the server / clients where to add what prefab.

        switch (built) {
            case "stairs":
                // Construct the stairs at the location with rotation and aligning
                // construct stairs at further location, setting the "goesUp" tag
                // Set the tile at both locations to "ComplexTile"

                break;

            case "forge":
                // Consume resources
                //replace tiles with "complex tile"
                // add instance of prefab
                break;

            case "stockpile":
                // Consume resources
                //replace tiles with "complex tile"
                // add instance of prefab
                break;

            case "spikes":
                // Set the cover to have spikes
                // Consume materials
                break;

            case "pit":
                // Ensure it is diggable: floor
                // Set the tile to pit
                // Create a "pitcover" instance on the location
                Debug.Log("Digging a pit");
                break;

            case "tree":
                //Give the player wood
                Debug.Log("Wood gained.");
                break;

            default:
                Debug.Log("Unset case: "+built);
                break;
        }
    }
}
