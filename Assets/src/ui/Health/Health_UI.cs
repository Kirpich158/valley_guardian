using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Health_UI : MonoBehaviour {
    public GameObject healthPrefab;
    public Stack<GameObject> uiHearts = new Stack<GameObject>();

    void Start() {
        Vector2 _nextPos = healthPrefab.GetComponent<RectTransform>().anchoredPosition;
        for (int i = 0; i < PlayerMain.Instance.HealthVal; i++) {
            GameObject instance = Instantiate(healthPrefab, transform);
            instance.GetComponent<RectTransform>().anchoredPosition = _nextPos;
            uiHearts.Push(instance);

            var rect = healthPrefab.GetComponent<RectTransform>().rect;
            _nextPos.x += rect.width + rect.width / 6;
        }
    }

    public void AddHearts(int heartAmount) {
        for (int i = 0; i < heartAmount; i++) {
            PlayerMain.Instance.HealthVal++;

            float lastHeartWidth = uiHearts.Peek().GetComponent<RectTransform>().rect.width;
            float newHeartPosX = lastHeartWidth + lastHeartWidth / 6;

            GameObject instance = Instantiate(healthPrefab, transform);
            instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(newHeartPosX, transform.position.y);
            uiHearts.Push(instance);
        }
    }

    public void RemoveHearts(int heartAmount) {
        for (int i = 0; i < heartAmount; i++) {
            PlayerMain.Instance.HealthVal--;
            Destroy(uiHearts.Peek());
            uiHearts.Pop();
        }
    }
}
