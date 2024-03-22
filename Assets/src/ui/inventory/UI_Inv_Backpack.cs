using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Inv_Backpack : MonoBehaviour
{
    private UI_Inv_Backpack_Cell[] cells;

    public UI_Inv_Backpack(int slot_num)
    {
         cells = new UI_Inv_Backpack_Cell[slot_num];
    }

    public void AddItem(GameObject item) {
        for (int i = 0; i < cells.Length; i++) {
            if (cells[i].IsEmpty) {
                cells[i].SetItem(item);
                return;
            }
        }
    }
}
