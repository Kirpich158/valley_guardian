using System;
using Unity.VisualScripting;
using UnityEngine;

enum Enemies {
    Goblin,
    Archer,
    Elemental,
}

public class PlayerCollision : MonoBehaviour {


    private void OnCollisionEnter2D(Collision2D collision) {
        //switch (collision.gameObject.tag) {
        //    case Enemies.Goblin.ToString():
        //        Debug.Log("abc");
        //        break;
        //}

        if (collision.gameObject.CompareTag(Enemies.Goblin.ToString())) {
            UIManagerScript.Instance.RemoveHearts(1);
        }
    }
}
