using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatScript : MonoBehaviour {
    [SerializeField] private InputActionReference _attackInput, _pointerPos;

    [SerializeField] private GameObject attackZonePrefab;
    [SerializeField] private float attackDistance;
    [SerializeField] private float initAttackDuration;
    private float attackDuration;
    private GameObject attackRef;

    private void Start() {
        attackDuration = initAttackDuration;
        attackRef = null;
    }

    void Update() {
        if (PlayerMain.Instance.State != PlayerStates.Moving && PlayerMain.Instance.State != PlayerStates.Dashing && PlayerMain.Instance.State != PlayerStates.Attacking) {
            if (_attackInput.action.WasPressedThisFrame()) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(_pointerPos.action.ReadValue<Vector2>());
                mousePos.z = 0;
                Vector3 newDir = (mousePos - transform.localPosition).normalized;
                Vector3 attackZonePos = newDir * attackDistance;

                // angle between click and player
                float hyp = Vector3.Distance(mousePos, transform.localPosition);
                float opp = Mathf.Abs(mousePos.y - transform.localPosition.y);
                float adj = (mousePos.x - transform.localPosition.x);
                float rads = Mathf.Asin(opp / hyp);
                Debug.Log("rads: " + rads);
                float angle = rads * (180 / Mathf.PI);
                float finAngle = 0;
                // if ( )
                //Debug.Log("angle: " + angle);
                //Debug.Log("fin: " + (90 - angle));


                attackZonePos.y -= 0.2f;
                attackRef = Instantiate(attackZonePrefab, attackZonePos, Quaternion.Euler(0, 0, 90 - angle));
                //Vector3 lookAtPos = mousePos;
                //lookAtPos.z = transform.position.z;
                //attackRef.transform.LookAt(lookAtPos);

                PlayerMain.Instance.State = PlayerStates.Attacking;
                PlayerMain.Instance.gameObject.GetComponent<PlayerControls>().IsMovementBlocked = true;
            }
        }

        if (PlayerMain.Instance.State == PlayerStates.Attacking && attackRef != null) {
            if (attackDuration > 0) {
                attackDuration -= Time.deltaTime;
            } else {
                attackDuration = initAttackDuration;
                PlayerMain.Instance.State = PlayerStates.Idle;
                PlayerMain.Instance.gameObject.GetComponent<PlayerControls>().IsMovementBlocked = false;
                Destroy(attackRef);
                attackRef = null;
            }
        }
    }
}
