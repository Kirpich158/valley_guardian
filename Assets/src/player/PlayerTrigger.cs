using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    private void Start() {}

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("NPC")) {
            Debug.Log("npc is near");
        }

        DroppedItem enviroItem = collider.GetComponent<DroppedItem>();
        if (enviroItem != null) {
            gameObject.GetComponent<PlayerMain>().Inventory.AddItem(enviroItem.GetItem());
            enviroItem.Kill();
        }
    }
}
