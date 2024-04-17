using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatScript : MonoBehaviour {
    [SerializeField] InputActionReference _attackInput, _pointerPos;
    
    void Update() {
        if (PlayerMain.Instance.State != PlayerStates.Moving && PlayerMain.Instance.State != PlayerStates.Dashing) {
            if (_attackInput.action.WasPressedThisFrame()) {
                Debug.Log("Player attacked");
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(_pointerPos.action.ReadValue<Vector2>());
                mousePos.z = 0;
                Vector3 newDir = (mousePos - transform.position).normalized;

                Debug.Log(newDir);
            }
        }
    }
}
