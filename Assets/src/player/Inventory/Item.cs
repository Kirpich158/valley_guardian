using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    CurrencyBag,
    HealthPotion,
    Sword,
}

public class Item {
    public ItemType type;
    public int quantity;

    public Item(ItemType type, int quantity) {
        this.type = type;
        this.quantity = quantity;
    }

    public Sprite GetSprite() {
        switch (type) {
            case ItemType.CurrencyBag:
                return ItemsLibrary.Instance._currencyBag;
            case ItemType.HealthPotion:
                return ItemsLibrary.Instance._healthPotion;
            case ItemType.Sword:
                return ItemsLibrary.Instance._sword;
            default:
                return null;
        }
    }
}
