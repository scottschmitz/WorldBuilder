using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : ScriptableObject {

    private GameObject panel;
    private GameObject uiObject;
    private Transform wearableLocation;

    private GameObject prefab;

    private Color color;

	public void init(
        GameObject panel,
        Sprite sprite,
        GameObject prefab,
        Transform wearableLocation,
        Vector2 position,
        Vector2 size
    ) {
        this.panel = panel;
        this.wearableLocation = wearableLocation;
        this.prefab = prefab;

        // Create the visual that will be shown when this is owned
        this.uiObject = new GameObject();
        Button button = this.uiObject.AddComponent<Button>();
        button.onClick.AddListener(useItem);

        // Add the image component so we have a sprite (this also adds the RectTransform so we can size)
        Image image = uiObject.AddComponent<Image>();
        image.sprite = sprite;
        //image.color = this.color;
        RectTransform rectTransform = uiObject.GetComponent<RectTransform>();

        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        rectTransform.pivot = new Vector2(0, 1);
        rectTransform.position = position;
        rectTransform.sizeDelta = size;

        this.uiObject.transform.SetParent(this.panel.transform, false);
    }

    private void useItem() {
        Camera.main.backgroundColor = this.color;

        if (this.wearableLocation != null) {
            // Clear out the location
            List<GameObject> children = new List<GameObject>();
            foreach (Transform child in wearableLocation) {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));

            // Add this object to the location
            GameObject equipItem = (GameObject)Instantiate(
                this.prefab,
                this.wearableLocation.position,
                this.wearableLocation.rotation
            );
            equipItem.transform.SetParent(this.wearableLocation.transform);
        }
    }
}
