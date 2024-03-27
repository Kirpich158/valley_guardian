using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsLibrary : MonoBehaviour {
    public static ItemsLibrary Instance { get; private set; }

    public Transform itemPrefab;
    public Sprite currencyBag;
    public Sprite healthPotion;
    public Sprite helmet;
    public Sprite armor;
    public Sprite boots;
    public Sprite ring;
    public Sprite sword;
    public Sprite shield;
    public Sprite fishingRod;

    private void Awake() {
        Instance = this;
    }
}
