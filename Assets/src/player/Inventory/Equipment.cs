using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment {


    public Item[] equipments;

    public Equipment () {
        equipments = new Item[7];
    }

    public void Equip(Item item) {
        switch (item.type) {
            case ItemType.Helmet:
                equipments[0] = item;
                break;
            case ItemType.Armor:
                equipments[1] = item;
                break;
            case ItemType.Boots:
                equipments[2] = item;
                break;
            case ItemType.Ring:
                equipments[3] = item;
                break;
            case ItemType.Sword:
                equipments[4] = item;
                break;
            case ItemType.Shield:
                equipments[5] = item;
                break;
            case ItemType.FishingRod:
                equipments[6] = item;
                break;
        }
    }
}
