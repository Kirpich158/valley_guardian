using TMPro;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour {
    public TextMeshProUGUI textObj;

    private int _gold { get; set; }

    void Start() {
        _gold = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)) {
            _gold += 10;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            _gold -= 10;
        }

        if (_gold < 0) _gold = 0;
        textObj.text = "GOLD: " + _gold;
    }
}
