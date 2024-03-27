using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private Transform _backpackSection;

    public void SetInventory(Inventory inventory) {
        _inventory = inventory;
        _inventory.OnItemsChange += Inventory_OnItemsChange;
        UpdateItems();
    }

    private void Inventory_OnItemsChange(object sender, EventArgs e) {
        UpdateItems();
    }

    private void UpdateItems() {
        for (int i = 0; i < _inventory.Items.Count; i++) {
            Transform itemIcon = _backpackSection.GetChild(i).transform.Find("ItemIcon");

            // updating item sprite
            Image itemImg = itemIcon.GetComponentInChildren<Image>();
            itemImg.sprite = _inventory.Items[i].GetSprite();
            
            // updating quantity text
            TextMeshProUGUI countTxt = itemIcon.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();
            countTxt.text = _inventory.Items[i].quantity.ToString();

            // showing sprite and quantity
            Color tmpColor = itemImg.color;
            tmpColor.a = 1;
            itemImg.color = tmpColor;
            if (_inventory.Items[i].quantity > 1) countTxt.color = tmpColor;
        }
    }
}
