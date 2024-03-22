using UnityEngine;

public class Enemy_Following : MonoBehaviour {
    public GameObject player;

    [SerializeField]
    private float _move_speed;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        // Follows player
        // transform.position = new Vector3(transform.position.x + Time.deltaTime * _move_speed, transform.position.y, transform.position.z);
        transform.position += _move_speed * Time.deltaTime * (player.transform.position - transform.position).normalized;
    }
}
