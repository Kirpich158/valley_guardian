using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_UI : MonoBehaviour {
    public GameObject healthPrefab;
    public PlayerHealth playerHealth;
    public Stack<GameObject> uiHearts = new Stack<GameObject>();

    void Start() {
        Vector2 _nextPos = healthPrefab.GetComponent<RectTransform>().anchoredPosition;
        for (int i = 0; i < playerHealth.healthVal; i++) {
            GameObject instance = Instantiate(healthPrefab, transform);
            instance.GetComponent<RectTransform>().anchoredPosition = _nextPos;
            uiHearts.Push(instance);

            var rect = healthPrefab.GetComponent<RectTransform>().rect;
            _nextPos.x += rect.width + rect.width / 6;
        }
    }
}
