using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    CurrencyBag,
    HealthPotion,
    Helmet,
    Armor,
    Boots,
    Ring,
    Sword,
    Shield,
    FishingRod
}

[Serializable]
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
                return ItemsLibrary.Instance.currencyBag;
            case ItemType.HealthPotion:
                return ItemsLibrary.Instance.healthPotion;
            case ItemType.Helmet:
                return ItemsLibrary.Instance.helmet;
            case ItemType.Armor:
                return ItemsLibrary.Instance.armor;
            case ItemType.Boots:
                return ItemsLibrary.Instance.boots;
            case ItemType.Ring:
                return ItemsLibrary.Instance.ring;
            case ItemType.Sword:
                return ItemsLibrary.Instance.sword;
            case ItemType.Shield:
                return ItemsLibrary.Instance.shield;
            case ItemType.FishingRod:
                return ItemsLibrary.Instance.fishingRod;
            default:
                return null;
        }
    }

    public bool IsStackable() {
        switch (type) {
            case ItemType.CurrencyBag:
                return true;
            case ItemType.HealthPotion:
                return true;
            case ItemType.Helmet:
                return false;
            case ItemType.Armor:
                return false;
            case ItemType.Boots:
                return false;
            case ItemType.Ring:
                return false;
            case ItemType.Sword:
                return false;
            case ItemType.Shield:
                return false;
            case ItemType.FishingRod:
                return false;
            default:
                return false;
        }
    }
}
