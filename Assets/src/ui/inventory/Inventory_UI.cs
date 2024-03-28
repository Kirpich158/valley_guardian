using Mono.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    private Backpack _backpack;
    private Equipment _equipment;

    [SerializeField] private Transform _backpackSection;
    [SerializeField] private Transform _equipmentCells;

    public void SetupInventory(Backpack backpack, Equipment equipment) {
        _backpack = backpack;
        _equipment = equipment;
        _backpack.OnItemsChange += Inventory_OnItemsChange;
        _equipment.OnItemsChange += Inventory_OnItemsChange;
        UpdateItems();
    }

    private void Inventory_OnItemsChange(object sender, EventArgs e) {
        UpdateItems();
    }

    // ==> TODO optimize usage of 2 for() loops <==
    private void UpdateItems() {
        // backpack loop
        for (int i = 0; i < _backpack.Items.Count; i++) {
            Transform itemIcon = _backpackSection.GetChild(i).transform.Find("ItemIcon");

            // updating item sprite
            Image itemImg = itemIcon.GetComponent<Image>();
            itemImg.sprite = _backpack.Items[i].GetSprite();
            
            // updating quantity text
            TextMeshProUGUI countTxt = itemIcon.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();
            countTxt.text = _backpack.Items[i].quantity.ToString();

            // showing sprite and quantity
            Color tmpColor = itemImg.color;
            tmpColor.a = 1;
            itemImg.color = tmpColor;
            if (_backpack.Items[i].quantity > 1) countTxt.color = tmpColor;
        }

        // equipment loop
        for (int i = 0; i < _equipment.Equipments.Length; i++) {
            if (_equipment.Equipments[i] == null) {
                continue;
            }
            Transform itemIcon = _equipmentCells.GetChild(i).transform.Find("ItemIcon");

            // updating item sprite
            Image itemImg = itemIcon.GetComponent<Image>();
            itemImg.sprite = _equipment.Equipments[i].GetSprite();

            // updating level text
            TextMeshProUGUI lvlTxt = itemIcon.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();
            lvlTxt.text = _equipment.Equipments[i].quantity.ToString();
            // lvlTxt.text = _equipment.Equipments[i].level.ToString();

            // showing sprite (and level later)
            Color tmpColor = itemImg.color;
            tmpColor.a = 1;
            itemImg.color = tmpColor;
            lvlTxt.color = tmpColor;
        }

        // ==> TODO finish <==
        // LoopThrough(_backpack.Items.ToArray(), _backpackSection);
        // LoopThrough(_equipment.Equipments, _equipmentCells);
    }

    private void LoopThrough(Item[] items, Transform parentObj, Backpack inventoryClass, Equipment eqClass) {
        for (int i = 0; i < items.Length; i++) {
            Transform itemIcon = parentObj.GetChild(i).transform.Find("ItemIcon");

            // updating item sprite
            Image itemImg = itemIcon.GetComponentInChildren<Image>();
            itemImg.sprite = inventoryClass.Items[i].GetSprite();
            itemImg.sprite = eqClass.Equipments[i].GetSprite();

            // updating quantity text
            TextMeshProUGUI countTxt = itemIcon.transform.Find("CountTxt").GetComponent<TextMeshProUGUI>();
            countTxt.text = inventoryClass.Items[i].quantity.ToString();
            countTxt.text = eqClass.Equipments[i].quantity.ToString();

            // showing sprite and quantity
            Color tmpColor = itemImg.color;
            tmpColor.a = 1;
            itemImg.color = tmpColor;
            if (_backpack.Items[i].quantity > 1) countTxt.color = tmpColor;
        }
    }
}
