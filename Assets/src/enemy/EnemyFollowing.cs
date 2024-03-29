using UnityEngine;

public class EnemyFollowing : MonoBehaviour {
    private GameObject target;

    [SerializeField]
    private float _move_speed;

    private void Start() {
        target = PlayerMain.Instance.gameObject;
        // target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        // Follows player
        // transform.position = new Vector3(transform.position.x + Time.deltaTime * _move_speed, transform.position.y, transform.position.z);
        transform.position += _move_speed * Time.deltaTime * (target.transform.position - transform.position).normalized;
    }
}
