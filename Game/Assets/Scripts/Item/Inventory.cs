using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int SIZE = 16;
    private const int COLUMNS = 4;

    public GameObject panel;

    private List<InventoryItem> items;
    private ContextMenuItemAttribute[] contextMenuItems;

	void Start () {
        items = new List<InventoryItem>();
	}

    public bool addItem(Item item) {
        if (items.Count >= SIZE) {
            return false;
        }

        int index = items.Count;

        int widthSpacer = 20;
        int width = 150;
        int column = index % COLUMNS;
        int xPos = widthSpacer + (width + widthSpacer) * column;

        int heightSpacer = 20;
        int height = 1000;
        int row = index / COLUMNS;
        int yPos = heightSpacer + (height + heightSpacer) * row;

        Vector2 position = new Vector2(xPos, yPos);
        Vector2 size = new Vector2(width, height);

        InventoryItem inventoryItem = (InventoryItem)ScriptableObject.CreateInstance("InventoryItem");
        inventoryItem.init(
            this.panel,
            item.icon,
            item.gameObject,
            item.transform.parent,
            position,
            size
        );
        return true;
    }

    public void togglePanel() {
        panel.SetActive(!panel.activeSelf);
    }
}
