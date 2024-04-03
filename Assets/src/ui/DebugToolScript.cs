using System.Collections;
using System.Collections.Generic;
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

    #region GoldSection
    public PlayerCurrency currency;

    public void AddGold(TMP_InputField input) {
        currency.Gold += int.Parse(input.text);
    }
    public void RemoveGold(TMP_InputField input) {
        currency.Gold -= int.Parse(input.text);
    }
    #endregion

    public void SpawnItem() {

    }
}
