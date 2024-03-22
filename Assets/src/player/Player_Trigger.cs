using Unity.VisualScripting;
using UnityEngine;

public class Player_Trigger : MonoBehaviour {
    private UI_Inventory inventory;

    private void Start() {
        inventory = GetComponent<Player_Controls>().inventory;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("NPC")) {
            Debug.Log("npc is near");
        }

        if (collider.gameObject.CompareTag("item")) {
            Debug.Log("item");
            GameObject clone = collider.gameObject;
            inventory.PutIntoBackpack(clone);
        }
    }
}
