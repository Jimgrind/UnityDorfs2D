using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    List<StockPile> piles;

    public GameObject inventory;
    // Start is called before the first frame update
    void Start() {
        piles = new List<StockPile>();
    }

    public void AddStockPile(StockPile pile) {
        Debug.Log("Adding Pile");
        piles.Add(pile);
    }

    public void RemoveStockPile(StockPile pile) {
        Debug.Log("Removing Pile");
        piles.Remove(pile);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Something Happened");
        if (other.gameObject.tag == "stockpile") {
            Debug.Log("Collision with Player");
            AddStockPile(other.gameObject.GetComponent<StockPile>());
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Something Happened");

        if (other.gameObject.tag == "stockpile") {
            Debug.Log("Player Left");
            RemoveStockPile(other.gameObject.GetComponent<StockPile>());
        }
    }

    // Update is called once per frame
    void Update() {
        if (piles != null) {
            foreach (StockPile pile in piles) {
                Debug.Log(pile.title);
            }
        }
    }

}
