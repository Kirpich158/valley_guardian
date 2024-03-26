using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private List<Item> _items;
    public List<Item> Items { get; }

    public Inventory() {
        Items = new List<Item>();

        AddItem(new Item(ItemType.HealthPotion, 3));
        AddItem(new Item(ItemType.CurrencyBag, 10));
        AddItem(new Item(ItemType.Sword, 1));
    }

    public void AddItem(Item item) {
        Items.Add(item);
    }
}
