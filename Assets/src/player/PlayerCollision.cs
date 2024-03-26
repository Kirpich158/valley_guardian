using Unity.VisualScripting;
using UnityEngine;

enum Enemies {
    Goblin,
    Archer,
    Elemental,
}

public class PlayerCollision : MonoBehaviour {
    public Health_UI ui_script;

    private void OnCollisionEnter2D(Collision2D collision) {
        //switch (collision.gameObject.tag) {
        //    case Enemies.Goblin.ToString():
        //        Debug.Log("abc");
        //        break;
        //}

        if (collision.gameObject.CompareTag(Enemies.Goblin.ToString())) {
            gameObject.GetComponent<PlayerHealth>().healthVal--;
            Destroy(ui_script.uiHearts.Peek());
            ui_script.uiHearts.Pop();
        }
    }
}
