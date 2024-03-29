using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    private void Start() {}

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("NPC")) {
            Debug.Log("npc in range");
        }
    }
}
