using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void FixedUpdate()
    {
        KeyboardMovement();
    }

    private void KeyboardMovement() {
        float xKeyboard = Input.GetAxis("Horizontal");
        float yKeyboard = Input.GetAxis("Vertical");

        transform.position += transform.right * xKeyboard * _movementSpeed;
        transform.position += transform.up * yKeyboard * _movementSpeed;
    }
}
