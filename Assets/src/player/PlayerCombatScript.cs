using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour {

    
    void Update() {
        if (PlayerMain.Instance.State != PlayerStates.Moving) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Player attacked");
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newDir = (mousePos - transform.position).normalized;


            }
        }
    }
}
