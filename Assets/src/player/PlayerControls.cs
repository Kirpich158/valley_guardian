using UnityEngine;

public class PlayerControls : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashDecayMultiplier;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidBody2D;

    public bool IsMovementBlocked {  get; set; }

    private Vector3 _dir;
    private Vector3 _dashDir;
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
            case PlayerStates.Dashing:
                _rigidBody2D.velocity = _dashDir * _dashSpeedVal;
                break;
        }
        
    }

    private void InputMovement() {
        if (PlayerMain.Instance.State != PlayerStates.Dashing) {
            float xKeyboard = Input.GetAxisRaw("Horizontal");
            float yKeyboard = Input.GetAxisRaw("Vertical");
            _dir = new Vector3(xKeyboard, yKeyboard).normalized;

            // swapping states based on player input
            if (_dir != Vector3.zero) PlayerMain.Instance.State = PlayerStates.Moving;
            else PlayerMain.Instance.State = PlayerStates.Idle;

            SetAnimationParams();
        }

        // player's dash on space press
        if (Input.GetKeyDown(KeyCode.Space)) {
            _dashDir = _dir;
            PlayerMain.Instance.State = PlayerStates.Dashing;
        }

        if (PlayerMain.Instance.State == PlayerStates.Dashing) {
            _dashSpeedVal -= _dashSpeedVal * _dashDecayMultiplier * Time.deltaTime;
            if (_dashSpeedVal <= _moveSpeed) {
                PlayerMain.Instance.State = PlayerStates.Moving;
                _dashSpeedVal = _dashSpeed;
            }
        }
    }

    private void InventoryControls() {
        if (Input.GetKeyDown(KeyCode.I) && !UIManagerScript.Instance.InventoryOpened) { // opening inventory
            UIManagerScript.Instance.ShowInventoryPanel();
        } else if (Input.GetKeyDown(KeyCode.I) && UIManagerScript.Instance.InventoryOpened) { // closing inventory
            UIManagerScript.Instance.HideInventoryPanel();
        }
    }

    private void SetAnimationParams() {
        _animator.SetFloat("Horizontal", _dir.x);
        _animator.SetFloat("Vertical", _dir.y);
        _animator.SetBool("IsMoving", PlayerMain.Instance.State == PlayerStates.Moving);
    }
}