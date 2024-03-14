using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Health : MonoBehaviour {
    public GameObject healthPrefab;
    public Player_Health playerHealth;
    public Stack<GameObject> uiHearts = new Stack<GameObject>();

    private Vector2 _nextPos;

    void Start() {
        _nextPos = healthPrefab.GetComponent<RectTransform>().anchoredPosition;
        for (int i = 0; i < playerHealth.healthVal; i++) {
            GameObject instance = Instantiate(healthPrefab, transform);
            instance.GetComponent<RectTransform>().anchoredPosition = _nextPos;
            uiHearts.Push(instance);

            var rect = healthPrefab.GetComponent<RectTransform>().rect;
            _nextPos.x += rect.width + rect.width / 6;
        }
    }
}
