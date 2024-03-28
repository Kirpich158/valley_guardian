using Unity.VisualScripting;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    private void Start() {}

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("NPC")) {
            Debug.Log("npc is near");
        }

        DroppedItem enviroItem = collider.GetComponent<DroppedItem>();
        PlayerMain player = gameObject.GetComponent<PlayerMain>();
        if (enviroItem != null) {
            if (enviroItem.GetItem().type <= ItemType.FishingRod 
                && player.Equipment.Equipments[(int)enviroItem.GetItem().type] == null) {
                player.Equipment.Equip(enviroItem.GetItem()); // ==> TODO Change later to equip if the slot is empty otherwise add to backpack, so player can equip it manually
            } else {
                player.Backpack.AddItem(enviroItem.GetItem());
            }
            enviroItem.Kill();
        }
    }
}
