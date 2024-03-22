using UnityEngine;
using UnityEngine.UI;

public class UI_Inv_Backpack_Cell : MonoBehaviour {
    public Image item_icon;

    private GameObject item;
    private bool _is_empty;

    #region Properties

    public bool IsEmpty { get; set; }

    #endregion

    public UI_Inv_Backpack_Cell()
    {
        item = null;
        _is_empty = true;
    }

    public void SetItem(GameObject newItem) {
        if (_is_empty) {
            item = newItem;
            _is_empty = false;
            item_icon.sprite = newItem.GetComponent<SpriteRenderer>().sprite;
        }

        // swap in the future
    }
}
