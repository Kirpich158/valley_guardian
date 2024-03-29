using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour {
    private Item _item;
    [SerializeField] private SpriteRenderer spriteRender;

    public static DroppedItem SpawnItem(Vector3 pos, Item item) {
        Transform trans = Instantiate(ItemsLibrary.Instance.itemPrefab, pos, Quaternion.identity);
        
        DroppedItem droppedItem = trans.GetComponent<DroppedItem>();
        droppedItem.AttachItem(item);

        return droppedItem;
    }

    public void AttachItem(Item item) {
        _item = item;
        spriteRender.sprite = item.GetSprite();
    }

    public void Kill() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerMain player = collision.gameObject.GetComponent<PlayerMain>();
            if (_item.type <= ItemType.FishingRod
                && player.Equipment.Equipments[(int)_item.type] == null) {
                player.Equipment.Equip(_item);
            } else {
                player.Backpack.AddItem(_item);
            }
            Kill();
        }
    }
}
