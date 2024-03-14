using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Health : MonoBehaviour {
    public GameObject healthPrefab;
    public Player_Health playerHealth;

    private GameObject[] _uiHearts = new GameObject[3];
    private Vector2 _nextPos;

    void Start() {
        _nextPos = healthPrefab.GetComponent<RectTransform>().anchoredPosition;
        for (int i = 0; i < playerHealth.healthVal; i++) {
            GameObject instance = Instantiate(healthPrefab, transform);
            instance.GetComponent<RectTransform>().anchoredPosition = _nextPos;
            _uiHearts[i] = instance;

            var rect = healthPrefab.GetComponent<RectTransform>().rect;
            _nextPos.x += rect.width + rect.width / 6;
        }
    }
}
