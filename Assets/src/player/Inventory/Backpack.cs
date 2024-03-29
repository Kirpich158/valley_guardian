using System;
using System.Collections;
using System.Collections.Generic;

public class Backpack {
    public event EventHandler OnItemsChange;

    public List<Item> Items { get; }

    public Backpack() {
        Items = new List<Item>();
    }

    public void AddItem(Item item) {
        if (item.IsStackable()) {
            for (int i = 0; i < Items.Count; i++) {
                if (Items[i].type == item.type) { // ==> TODO <== add check for max quantity per slot in the future
                    Items[i].quantity += item.quantity;
                    OnItemsChange?.Invoke(this, EventArgs.Empty); // TMP fix for quantity txt update, cause of return; usage
                    return;
                }
            }
        }
        Items.Add(item);
        
        OnItemsChange?.Invoke(this, EventArgs.Empty); // ==> TODO <== adapt this with return; logic from above to update txt quantity of items
    }
}
