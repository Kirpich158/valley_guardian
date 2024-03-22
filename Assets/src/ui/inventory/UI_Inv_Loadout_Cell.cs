using UnityEngine;

enum Slot_Type {
    Head,
    Body,
    Foot,
    Ring,
    Weapon1,
    Weapon2
}

abstract class UI_Inv_Loadout_Cell {
    public Slot_Type type;
    public GameObject item;
    public bool isOccupied;


    public void SetItem(GameObject newItem) {
        if (!isOccupied) {
            item = newItem;
            isOccupied = true;
        }

        // swap in the future
    }
}
