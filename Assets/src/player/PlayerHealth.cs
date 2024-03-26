using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthVal = 3;
    public TextMeshProUGUI gameOverTxt;

    private void Update() {
        if (healthVal <= 0) {
            gameOverTxt.alpha = 1;
            Time.timeScale = 0;
        }
    }
}
