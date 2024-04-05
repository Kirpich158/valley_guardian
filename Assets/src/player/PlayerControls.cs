using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public float _moveSpeed;

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