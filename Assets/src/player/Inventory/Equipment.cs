using System;
using System.Collections;
using System.Collections.Generic;

public class Equipment {
    public event EventHandler OnItemsChange;

    public Item[] Equipments { get; }

    public Equipment () {
        Equipments = new Item[7];
    }

    public void Equip(Item item) {
        switch (item.type) {
            case ItemType.Helmet:
                Equipments[0] = item;
                break;
            case ItemType.Armor:
                Equipments[1] = item;
                break;
            case ItemType.Boots:
                Equipments[2] = item;
                break;
            case ItemType.Ring:
                Equipments[3] = item;
                break;
            case ItemType.Sword:
                Equipments[4] = item;
                break;
            case ItemType.Shield:
                Equipments[5] = item;
                break;
            case ItemType.FishingRod:
                Equipments[6] = item;
                break;
        }

        OnItemsChange?.Invoke(this, EventArgs.Empty);
    }
}
