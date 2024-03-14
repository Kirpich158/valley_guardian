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
        transform.position += (player.transform.position - transform.position) * Time.deltaTime * _move_speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) { 
            var pHP = player.GetComponent<Player_Health>();
            if (pHP) pHP.healthVal--;
        }
    }
}
