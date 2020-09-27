using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface Processor : IEventSystemHandler {
    // Acts for inbetween actions of player use and the Build action.
    void process(string built); //, GameObject worked);
    void finish(string built); // Use for actions that consume items and change data
}

public class BuildInterface : MonoBehaviour, Processor {

    public GameObject bestOption; // The likliest canidate for "contextual usage"
                                  // currently very dumb, choses whatever you entered latest.

    // Start is called before the first frame update
    void Start() {
        bestOption = null;
    }

    // Update is called once per frame
    void Update() {
        if (bestOption != null && Input.GetButtonDown("ContextUse")) {
            gameObject.GetComponent<Build>().process(bestOption.name);
        }
    }

    public void process(string built) {
        // Determine location
        gameObject.GetComponent<Build>().process(built);
    }

    public void finish(string built) {
        gameObject.GetComponent<Build>().finish(built);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Constructable") {
            Debug.Log("Viable option found");
            bestOption = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (bestOption == other.gameObject) {
            bestOption = null;
        }
    }
}
