using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGameScript : MonoBehaviour {
    [SerializeField] private float _pointerSpeed;
    [Header("References")]
    [SerializeField] private GameObject _zonePrefab;
    [SerializeField] private RectTransform _pointerTrans;
    [SerializeField] private RectTransform _progressBarTrans;
    [SerializeField] private CanvasGroup _canvasGroup;
    [Header("Values in %s")]
    [SerializeField] private float _progressDecay;
    [SerializeField] private float _progressReward;
    [SerializeField] private float _progressPenalty;

    private float _progress;
    private int _pointerDir;
    private GameObject _zoneObj;

    // parameters to control fishing minigame
    // [SerializeField] private Vector2 zoneSpanwLimit;

    private void Start() {
        _zoneObj = SpawnNewZone();

        _progress = 0;
        ResetPointer();
    }

    private void Update() {
        UpdateProgressBar();
        MovePointer();
        CheckPointerHit();

        // closing minigame if Esc was pressed during minigame
        if (UIManagerScript.Instance.Fishing && Input.GetKeyDown(KeyCode.Escape)) {
            UIManagerScript.Instance.HideFishingGame();
        }
    }

    private void MovePointer() {
        if (_pointerTrans.localPosition.y >= 245) _pointerDir = -1;
        if (_pointerTrans.localPosition.y <= -245) _pointerDir = 1;

        _pointerTrans.localPosition = new Vector2(_pointerTrans.localPosition.x, _pointerTrans.localPosition.y + _pointerSpeed * Time.deltaTime * _pointerDir);
    }

    private void ResetPointer() {
        _pointerDir = 0;
        _pointerTrans.localPosition = new Vector2(_pointerTrans.localPosition.x, 0);
    }

    private GameObject SpawnNewZone() {
        int nextY = Random.Range(-200, 200);

        GameObject instance = Instantiate(_zonePrefab, gameObject.transform);
        instance.transform.localPosition = new Vector2(0, nextY);
        instance.transform.SetSiblingIndex(_pointerTrans.GetSiblingIndex());

        return instance;
    }

    private void CheckPointerHit() {
        if (UIManagerScript.Instance.Fishing && Input.GetKeyDown(KeyCode.Space)) {
            if (_zoneObj == null) return;
            float zoneBot = _zoneObj.transform.localPosition.y - _zoneObj.GetComponent<RectTransform>().rect.height / 2;
            float zoneTop = _zoneObj.transform.localPosition.y + _zoneObj.GetComponent<RectTransform>().rect.height / 2;
            if (_pointerTrans.localPosition.y < zoneTop && _pointerTrans.localPosition.y > zoneBot) {
                AddToProgress(_progressReward); // progress reward
                //IncreaseTheProgress();

                // deletion of old hit zone
                if (_zoneObj != null) {
                    Destroy(_zoneObj);
                    _zoneObj = null;
                    _zoneObj = SpawnNewZone();
                }
            } else {
                AddToProgress(-_progressPenalty); // progress penalty
                // DecreaseTheProgress(); 
            }
        }
    }

    private void UpdateProgressBar() {
        if (_progress >= 100) {
            _progress = 100;
            _progressBarTrans.sizeDelta = new Vector2(_progressBarTrans.sizeDelta.x, Mathf.Lerp(40, 490, _progress / 100));
            UIManagerScript.Instance.HideFishingGame();
        }

        if (_progress > 0 && _progress < 100 && _pointerDir != 0) AddToProgress(-Time.deltaTime * _progressDecay);
        else if (_progress <= 0) _progress = 0;

        _progressBarTrans.sizeDelta = new Vector2(_progressBarTrans.sizeDelta.x, Mathf.Lerp(40, 490, _progress / 100));
    }

    private void AddToProgress(float value) {
        _progress += value;
    }

    #region Old handmade linear interpolation try // COMEBACK TO IT
    //private void UpdateProgressBar() {
    //    if (_progressBarTrans.rect.height >= 490) {
    //        Debug.Log("fishing succeed");
    //        _progressBarTrans.sizeDelta = new Vector2(_progressBarTrans.sizeDelta.x, 490);
    //        UIManagerScript.Instance.HideFishingGame();
    //    }

    //    if (_progressBarTrans.rect.height > 40 && _progressBarTrans.rect.height < 490 && _pointerDir != 0) {
    //        AddToProgressVal(-Time.deltaTime * _progressDecaySpd);
    //    } else {
    //        _progressBarTrans.sizeDelta = new Vector2(
    //            _progressBarTrans.sizeDelta.x,
    //            40
    //        );
    //    }
    //}

    //private void IncreaseTheProgress() {
    //    if (490 - _progressBarTrans.rect.height >= _progressReward) {
    //        AddToProgressVal(_progressReward);
    //        return;
    //    }
    //    AddToProgressVal(490 - _progressBarTrans.rect.height);
    //}

    //private void DecreaseTheProgress() {
    //    if (_progressBarTrans.rect.height - 40 >= _progressPenalty) {
    //        AddToProgressVal(-_progressPenalty);
    //        return;
    //    }
    //    AddToProgressVal(-(_progressBarTrans.rect.height - 40));
    //}

    //private void AddToProgressVal(float value) {
    //    _progressBarTrans.sizeDelta = new Vector2(
    //        _progressBarTrans.sizeDelta.x,
    //        _progressBarTrans.sizeDelta.y + value
    //    );
    //}
    #endregion

    public void ShowGame() {
        // _progress = PlayerMain.Instance.Equipment.(ItemType.FishingRod)Equipments[6].fishingBoost;
        
        _canvasGroup.alpha = 1; // ==> TODO change for animation clip <==
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        
        // start pointer after animation clip [^^^] ended
        _pointerDir = 1;
    }
    public void HideGame() {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0; // ==> TODO change for animation clip <==

        // reset these after animation clip [^^^] ended
        _progress = 0;
        ResetPointer();
    }
}
