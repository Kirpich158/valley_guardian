using UnityEngine;
using TMPro;

public class DebugToolScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    private bool _isPanelShown = false;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.BackQuote) && !_isPanelShown) { // opening panel
            canvasGroup.alpha = 1;
            _isPanelShown = true;
        } else if (Input.GetKeyDown(KeyCode.BackQuote) && _isPanelShown) { // closing panel
            canvasGroup.alpha = 0;
            _isPanelShown = false;
        }
    }

    #region ItemSpawn
    [Space(20)]
    public TMP_Dropdown itemDropDown;
    public float itemSpawnDistance;

    private int _modificator = 1;

    public void SpawnItem() {
        if (itemDropDown.options[0].image == null) {
            itemDropDown.options.Remove(itemDropDown.options[0]);
            _modificator = 0;
        }

        Vector3 itemSpawnDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 itemPos = itemSpawnDir * itemSpawnDistance;
        DroppedItem.SpawnItem(itemPos, new Item((ItemType)itemDropDown.value - _modificator, 1));
    }
    #endregion

    #region GoldSection
    [Space(20)]
    public PlayerCurrency currency;

    public void AddGold(TMP_InputField input) {
        currency.Gold += int.Parse(input.text);
    }
    public void RemoveGold(TMP_InputField input) {
        currency.Gold -= int.Parse(input.text);
    }
    #endregion
}
