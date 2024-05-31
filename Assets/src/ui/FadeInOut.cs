using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {
    [SerializeField] private Image _img;

    public IEnumerator FadeIn(float duration = 1f, float opacity = 1f) {
        float counter = 0f;
        Color targetCol = Color.black;
        targetCol.a = opacity;

        while (counter < duration) {
            counter += Time.unscaledDeltaTime / duration;
            _img.color = Color.Lerp(_img.color, targetCol, counter);
            yield return null;
        }

        // OLD VERSION
        //while (_img.color.a < 1f) {
        //    _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a + Time.deltaTime / duration);
        //    yield return null;
        //}
    }
    public IEnumerator FadeOut(float duration = 1f) {
        float counter = 0f;
        Color targetCol = Color.clear;

        while (counter < duration) {
            counter += Time.unscaledDeltaTime / duration;
            _img.color = Color.Lerp(_img.color, targetCol, counter);
            yield return null;
        }

        // OLD VERSION
        //while (_img.color.a > 0f) {
        //    _img.color = new Color(_img.color.r, _img.color.g, _img.color.b, _img.color.a - Time.deltaTime / duration);
        //    yield return null;
        //}
    }
}
