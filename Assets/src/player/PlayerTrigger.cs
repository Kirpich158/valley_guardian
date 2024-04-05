using UnityEngine;

public class PlayerTrigger : MonoBehaviour {
    public bool OnFishingSpot {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("FishingSpot")) {
            OnFishingSpot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("FishingSpot")) {
            OnFishingSpot = false;
        }
    }
}
