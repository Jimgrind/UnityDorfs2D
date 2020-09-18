using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;


public interface buildMessagee : IEventSystemHandler
{
    // It may be worth combining the two
    void build(string built); // Use for actions that consume items and change data
    void dig(string dig); // Use for actions that give items and change data
}
// Special cases to consider as NOT needing a build/dig: 
// (it is worth noting that a UI button does not need to be what calls these functions)
// mining stone, smoothing a wall
// EXTRA special: Mining ores, destroying stairs (will it be possible?)

public class Build : MonoBehaviour, buildMessagee
{

    public Tile complex; // Placed under objects like stairs, forge, stockpile, etc

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Will later need to access inventory and build requirements;
    // or require these before the button can be pressed.
    // For now I just want to work towards building stuff
    public void build(string built) {
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

                // Construct the stairs at the location with rotation and aligning
                // construct stairs at further location, setting the "goesUp" tag
                // Set the tile at both locations to "ComplexTile"

                break;

            case "forge":
                Debug.Log("frog being made");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles

                // Consume resources
                //replace tiles with "complex tile"
                // add instance of prefab
                break;

            case "stockpile":
                Debug.Log("Stockpile being built");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles

                // Consume resources
                //replace tiles with "complex tile"
                // add instance of prefab
                break;

            case "spikes": // Adding spikes to a pit. Make this only appear when a pit is targeted?
                // Find the relevant location
                // Ensure a pit is in the location
                // Find the pitcover object associated with the coordinates
                // Set the cover to have spikes
                // Consume materials
                break;

            default:
                Debug.Log("Unset case: "+built);
                break;
        }
    }

    public void dig(string dig) {
        switch (dig) {
            case "pit":
                // Determine location
                // Ensure it is diggable: floor
                // Set the tile to pit
                // Create a "pitcover" instance on the location
                Debug.Log("Digging a pit");
                break;

            default:
                Debug.Log("Unset case: "+dig);
                break;
        }
    }
}
