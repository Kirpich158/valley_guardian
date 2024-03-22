using TMPro;
using UnityEngine;

public class Player_Currency : MonoBehaviour {
    public TextMeshProUGUI textObj;

    private int _gold = 0;
    public int Gold { get; set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)) {
            _gold += 10;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            _gold -= 10;
        }

        if (_gold < 0) _gold = 0;
        textObj.text = "Gold: " + _gold;
    }
}
