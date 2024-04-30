using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
    private Image _img;

    private void Awake() {
        _img = GetComponent<Image>();
    }

    public IEnumerator FadeIt(float time) {
        while (_img.color.a < 1f) {
            _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a + Time.deltaTime / time);
            yield return null;
        }
    }
    public IEnumerator FadeOut(float time) {
        while (_img.color.a > 0f) {
            _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a - Time.deltaTime / time);
            yield return null;
        }
    }
}
