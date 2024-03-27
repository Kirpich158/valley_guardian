using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour {
    private Item _item;
    private SpriteRenderer spriteRender;

    public static DroppedItem SpawnItem(Vector3 pos, Item item) {
        Transform trans = Instantiate(ItemsLibrary.Instance.itemPrefab, pos, Quaternion.identity);
        
        DroppedItem droppedItem = trans.GetComponent<DroppedItem>();
        droppedItem.AttachItem(item);

        return droppedItem;
    }

    public void Awake() {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void AttachItem(Item item) {
        _item = item;
        spriteRender.sprite = item.GetSprite();
    }

    public Item GetItem() {
        return _item;
    }

    public void Kill() {
        Destroy(gameObject);
    }
}
