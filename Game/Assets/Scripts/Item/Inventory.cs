using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject panel;
    public int numColumns;
    public int numRows;

    private Item[] items;

    private ContextMenuItemAttribute[] contextMenuItems;

	// Use this for initialization
	void Start () {
        createItems();
	}
	
    private void createItems() {
        items = new Item[numColumns * numRows];

        int widthSpacer = 20;
        int width = 150;

        int heightSpacer = 20;
        int height = 1000;

        Vector2 size = new Vector2(width, height);

        for (int i = 0; i < numRows; i++) {
            int yPos = -1 * (heightSpacer + (height + heightSpacer) * i);

            for (int j = 0; j < numColumns; j++) {
                int xPos = widthSpacer + (width + widthSpacer) * j;
                Vector2 position = new Vector2(xPos, yPos);

                Item item = (Item)ScriptableObject.CreateInstance("Item");
                item.init(this.panel, null, "item_type", null, null, position, size);

                items[i] = item;
            }
        }
    }
}
