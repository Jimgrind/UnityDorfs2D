using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Miner : MonoBehaviour
{
    // Special cases to consider as NOT needing a build/dig: 
    // (it is worth noting that a UI button does not need to be what calls these functions)
    // mining stone, smoothing a wall
    // EXTRA special: Mining ores, destroying stairs (will it be possible?)


    public GameObject gridGameObject;
    public GameObject tileMapGameObject;

    //We will likely want to move this to a list in another object
    public Tile flooring; // placed after mining stone
    public Tile complex; // Placed under objects like stairs, forge, stockpile, etc
    public Tile pit; // the Pit tile
    public GameObject pitCover; // the pit cover prefab
    public GameObject builder; // The building prefab

    public Camera cam;
    

    Rigidbody2D playerRigid;
    Tilemap tilemap;
    Grid grid;



    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        if (gridGameObject != null)
        {
            grid = gridGameObject.GetComponent<Grid>();
            tilemap = tileMapGameObject.GetComponent<Tilemap>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && tilemap != null && !EventSystem.current.IsPointerOverGameObject()) {
            Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int mp = new Vector3Int((int) Mathf.Floor(mouse.x), (int) Mathf.Floor(mouse.y), 0);
            TileBase targ = tilemap.GetTile(mp);
            //Debug.Log(mp);
            //Debug.Log(tilemap.GetTile(mp).name);
            process(targ.name, mp);
        }
    }

    // Non-objects
    public void process(string built, Vector3Int pos) {
        GameObject t;
        switch (built) {
            case "Wal":
                t = Instantiate(builder, new Vector3(pos.x + (float) 0.5, pos.y + (float) 0.5, 0), Quaternion.identity);
                t.GetComponent<BuildBar>().connect(gameObject, "stone", 150, 1.5);
                break;
            case "ground":
                t = Instantiate(builder, new Vector3(pos.x + (float) 0.5, pos.y + (float) 0.5, 0), Quaternion.identity);
                t.GetComponent<BuildBar>().connect(gameObject, "pit", 400, 1.2);
                break;

            case null:
                Debug.Log("No Tile Found at " + pos);
                break;

            default:
                Debug.Log("Non-Interactable: " + built + pos);
                break;
        }
    }

    public void process(GameObject worked) {
        GameObject t;

        //Tell the other clients / server where, and how big the thing being built is.

        // Currently requires the target's name to be the same as what they are here. 
        // All instances MUST have same name, unless the string is passed seperately.
        switch (worked.name) {
            case "stairs":
                //Stairs will need some additional way to determine which direction to build them
                // or simply only allow them to go down
                Debug.Log("Stairs being built");
                // Determine location

                // Ensure capability:
                // check to make sure this target location and the other side
                // are both tiles that may be replaced: Stone, Floor
                // Alternitively, we could ensure they are NOT things that should not be replaced.

                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                t.GetComponent<BuildBar>().connect(gameObject, worked, 200, 3);
                break;

            case "forge":
                Debug.Log("frog being made");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles

                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                t.GetComponent<BuildBar>().connect(gameObject, worked, 200, 3);
                break;

            case "stockpile":
                Debug.Log("Stockpile being built");
                // Find the relevant location AND 
                // ensure enough space is available with valid placable tiles

                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                t.GetComponent<BuildBar>().connect(gameObject, worked, 200, 3);

                break;

            case "pitCover": // Adding spikes to a pit. Make this only appear when a pit is targeted?
                // Find the relevant location
                // Ensure a pit is in the location

                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                t.GetComponent<BuildBar>().connect(gameObject, worked, 200, 3);
                break;

            case "tree":
                t = Instantiate(builder, worked.transform.position, Quaternion.identity, worked.transform);
                t.GetComponent<BuildBar>().connect(gameObject, worked, 200, 3);
                break;

            default:
                break;
        }
    }

    // Will later need to access inventory and build requirements;
    // or require these before the button can be pressed.
    // For now I just want to work towards building stuff

    public void finish(GameObject built) {

        // Grid layout changes are already sent.
        // Tell the server / clients where to add what prefab.

        switch (built.name) {
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

            case "pitCover":
                // Set the cover to have spikes
                built.GetComponent<Pit>().setSpikes();
                // Consume materials
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
    // A take-over function from <Build>
    public void finish(string tile, Vector3 pos) {
        switch (tile) {
            case "stone":
                tilemap.SetTile(tilemap.WorldToCell(pos), flooring);
                // gain stone
                break;
            case "pit":
                tilemap.SetTile(tilemap.WorldToCell(pos), pit);
                Instantiate(pitCover, pos, Quaternion.identity);
                // gain stone
                break;
        }
    }
}
