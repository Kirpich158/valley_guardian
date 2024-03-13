using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void FixedUpdate()
    {
        InputMovement();
    }

    private void InputMovement() {
        float xKeyboard = Input.GetAxis("Horizontal");
        float yKeyboard = Input.GetAxis("Vertical");

        transform.position += transform.right * xKeyboard * _movementSpeed;
        transform.position += transform.up * yKeyboard * _movementSpeed;
    }
}
