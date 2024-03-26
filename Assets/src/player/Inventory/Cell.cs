using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {
    public Item _item;
    private int _amount;
    public bool _isEmpty { get; set; }

    // struct for full item info OR maybe add it in item itself GetInfo() method?

    public Cell () {
        _item = null;
        _amount = 0;
        _isEmpty = true;
    }

    public void AttachItem(Item newItem) {
        if (_isEmpty) {
            _item = newItem;
            _amount++;
            _isEmpty = false;
        }
    }
}
