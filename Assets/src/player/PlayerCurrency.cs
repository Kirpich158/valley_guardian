using TMPro;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour {
    public TextMeshProUGUI textObj;

    public int Gold { get; set; }

    void Start() {
        Gold = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals)) {
            Gold += 10;
        }
        if (Input.GetKeyDown(KeyCode.Minus)) {
            Gold -= 10;
        }

        if (Gold < 0) Gold = 0;
        textObj.text = "GOLD: " + Gold;
    }
}
