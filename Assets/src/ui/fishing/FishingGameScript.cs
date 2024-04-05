using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGameScript : MonoBehaviour {
    public GameObject zonePrefab;
    public Transform pointerTransform;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _pointerSpeed;
    [SerializeField] private float _progressReward;
    [SerializeField] private float _progressPenalty;

    private float _progress = 0;
    private int _pointerDir = 1;
    private GameObject _zoneRef;

    // parameters to control fishing minigame
    // [SerializeField] private Vector2 zoneSpanwLimit;

    private void Start() {
        _zoneRef = SpawnNewZone();
    }

    private void Update() {
        MovePointer();
        CheckPointerHit();

        // closing minigame if Esc was pressed during minigame
        if (UIManagerScript.Instance.Fishing && Input.GetKeyDown(KeyCode.Escape)) {
            UIManagerScript.Instance.HideFishingGame();
        }
    }

    public void ShowGame() {
        _canvasGroup.alpha = 1; // ==> TODO change for animation clip <==
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
    public void HideGame() {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0; // ==> TODO change for animation clip <==
    }

    private void MovePointer() {
        if (pointerTransform.localPosition.y >= 245) _pointerDir = -1;
        if (pointerTransform.localPosition.y <= -245) _pointerDir = 1;

        pointerTransform.localPosition = new Vector2(pointerTransform.localPosition.x, pointerTransform.localPosition.y + _pointerSpeed * Time.deltaTime * _pointerDir);
    }

    private GameObject SpawnNewZone() {
        int nextY = Random.Range(-200, 200);

        GameObject instance = Instantiate(zonePrefab, gameObject.transform);
        instance.transform.localPosition = new Vector2(0, nextY);
        instance.transform.SetSiblingIndex(pointerTransform.GetSiblingIndex());

        return instance;
    }

    private void CheckPointerHit() {
        if (UIManagerScript.Instance.Fishing && Input.GetKeyDown(KeyCode.Space)) {
            if (_zoneRef == null) return;
            float zoneBot = _zoneRef.transform.localPosition.y - _zoneRef.GetComponent<RectTransform>().rect.height / 2;
            float zoneTop = _zoneRef.transform.localPosition.y + _zoneRef.GetComponent<RectTransform>().rect.height / 2;
            if (pointerTransform.localPosition.y < zoneTop && pointerTransform.localPosition.y > zoneBot) {
                // progress reward

                // deletion of old hit zone
                if (_zoneRef != null) {
                    Destroy(_zoneRef);
                    _zoneRef = null;
                    _zoneRef = SpawnNewZone();
                }
            }
            else {
                // progress penalty
            }
        }
    }

    private void IncreaseTheProgress() {

    }

    private void DecreaseTheProgress() {

    }
}
