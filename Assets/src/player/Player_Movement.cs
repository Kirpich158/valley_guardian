using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float _moveSpeed;

    void Update()
    {
        InputMovement();
    }

    private void InputMovement() {
        float xKeyboard = Input.GetAxisRaw("Horizontal");
        float yKeyboard = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(xKeyboard, yKeyboard).normalized;
        transform.position += dir * _moveSpeed * Time.deltaTime;
        
        // Work in progress
        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.position += dir * _moveSpeed * 100 * Time.deltaTime;
        }
    }
}