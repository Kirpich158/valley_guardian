using UnityEditor.Animations;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;

    public bool IsMovementBlocked {  get; set; }

    private void Start() {
        IsMovementBlocked = false;
    }

    void Update() {
        if (!IsMovementBlocked) {
            InputMovement();
            InventoryControls();
        }
    }

    private void InputMovement() {
        float xKeyboard = Input.GetAxisRaw("Horizontal");
        float yKeyboard = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(xKeyboard, yKeyboard).normalized;

        // swapping states based on player input
        if (dir != Vector3.zero) PlayerMain.Instance.State = PlayerStates.Moving;
        else PlayerMain.Instance.State = PlayerStates.Idle;

        // setting right animation based on movement dir
        _animator.SetFloat("Horizontal", dir.x);
        _animator.SetFloat("Vertical", dir.y);
        _animator.SetBool("IsMoving", PlayerMain.Instance.State == PlayerStates.Moving);

        transform.position += _moveSpeed * Time.deltaTime * dir;

        // Work in progress
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.position += _moveSpeed * 100 * Time.deltaTime * dir;
        }
    }

    private void InventoryControls() {
        if (Input.GetKeyDown(KeyCode.I) && !UIManagerScript.Instance.InventoryOpened) { // opening inventory
            UIManagerScript.Instance.ShowInventoryPanel();
        } else if (Input.GetKeyDown(KeyCode.I) && UIManagerScript.Instance.InventoryOpened) { // closing inventory
            UIManagerScript.Instance.HideInventoryPanel();
        }
    }
}