using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {
    [SerializeField] private float _moveSpeed, _dashSpeed, _dashDecayMultiplier;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [Header("Input actions")]
    [SerializeField] private InputActionReference _movementInput;
    [SerializeField] private InputActionReference _inventoryInput, _dashInput;

    public bool IsMovementBlocked {  get; set; }

    private Vector2 _dir, _dashDir;
    private float _dashSpeedVal;

    private void Start() {
        IsMovementBlocked = false;
        _dashSpeedVal = _dashSpeed;
    }

    void Update() {
        if (!IsMovementBlocked) {
            InputMovement();
            InventoryControls();
        }
    }

    private void FixedUpdate() {
        switch (PlayerMain.Instance.State) {
            case PlayerStates.Moving:
                _rigidBody2D.velocity = _dir * _moveSpeed;
                break;
            case PlayerStates.Idle:
                _rigidBody2D.velocity = Vector2.zero;
                break;
            case PlayerStates.Dashing:
                _rigidBody2D.velocity = _dashDir * _dashSpeedVal;
                break;
        }
    }

    private void InputMovement() {
        // normal movement
        if (PlayerMain.Instance.State != PlayerStates.Dashing && !UIManagerScript.Instance.InventoryOpened) {
            _dir = _movementInput.action.ReadValue<Vector2>().normalized;

            // swapping states based on player input
            if (_dir != Vector2.zero) PlayerMain.Instance.State = PlayerStates.Moving;
            else if (PlayerMain.Instance.State != PlayerStates.Attacking) PlayerMain.Instance.State = PlayerStates.Idle;

            SetAnimationParams();
        }

        // player's dash on space press
        if (_dashInput.action.WasPressedThisFrame() && PlayerMain.Instance.State == PlayerStates.Moving) {
            _dashDir = _dir;
            PlayerMain.Instance.State = PlayerStates.Dashing;
        }

        if (PlayerMain.Instance.State == PlayerStates.Dashing) {
            _dashSpeedVal -= _dashSpeedVal * _dashDecayMultiplier * Time.deltaTime;
            if (_dashSpeedVal <= _moveSpeed) {
                // checking for the input during dash to know if player should move after dash or be idle
                if (_movementInput.action.ReadValue<Vector2>().x != 0 || _movementInput.action.ReadValue<Vector2>().y != 0)
                    PlayerMain.Instance.State = PlayerStates.Moving;
                else PlayerMain.Instance.State = PlayerStates.Idle;
                _dashSpeedVal = _dashSpeed;
            }
        }
    }

    private void InventoryControls() {
        if (_inventoryInput.action.WasPressedThisFrame() && !UIManagerScript.Instance.InventoryOpened) { // opening inventory
            UIManagerScript.Instance.ShowInventoryPanel();
        } else if (_inventoryInput.action.WasPressedThisFrame() && UIManagerScript.Instance.InventoryOpened) { // closing inventory
            UIManagerScript.Instance.HideInventoryPanel();
        }
    }

    private void SetAnimationParams() {
        _animator.SetFloat("Horizontal", _dir.x);
        _animator.SetFloat("Vertical", _dir.y);
        _animator.SetBool("IsMoving", PlayerMain.Instance.State == PlayerStates.Moving);
    }
}