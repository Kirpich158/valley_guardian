using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public int backpack_slot_count;

    [SerializeField]
    private CanvasGroup inventory_group;

    //private LoadOut _loadOut;
    private UI_Inv_Backpack backpack_section;

    public void PutIntoBackpack(GameObject item) {
        backpack_section.AddItem(item);
    }

    public void Show() {
        inventory_group.alpha = 1;
    }

    public void Hide() {
        inventory_group.alpha = 0;
    }
}
