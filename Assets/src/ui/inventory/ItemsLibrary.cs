using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsLibrary : MonoBehaviour {
    public static ItemsLibrary Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public Sprite _currencyBag;
    public Sprite _healthPotion;
    public Sprite _sword;
}
