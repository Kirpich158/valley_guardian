using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float _moveSpeed;
    public CanvasGroup inventory;

    private bool _isInInventory = false;

    void Update()
    {
        InputMovement();
        InventoryToggle();
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

    private void InventoryToggle() {
        if (Input.GetKeyDown(KeyCode.I) && !_isInInventory) {
            _isInInventory = true;
            inventory.alpha = 1;
            Time.timeScale = 0;
        } else if (Input.GetKeyDown(KeyCode.I) && _isInInventory) {
            _isInInventory = false;
            inventory.alpha = 0;
            Time.timeScale = 1;
        }
    }
}