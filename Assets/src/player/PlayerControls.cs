using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public float _moveSpeed;

    private bool _InventoryOpened = false;

    void Update()
    {
        InputMovement();
        InventoryControls();

        if (Input.GetKeyDown(KeyCode.H)) {
            UIManagerScript.Instance.AddHearts(1);
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
        if (Input.GetKeyDown(KeyCode.I) && !_InventoryOpened) {
            UIManagerScript.Instance.ShowInventoryPanel();
            _InventoryOpened = true;
        } else if (Input.GetKeyDown(KeyCode.I) && _InventoryOpened) {
            UIManagerScript.Instance.HideInventoryPanel();
            _InventoryOpened = false;
        }
    }
}