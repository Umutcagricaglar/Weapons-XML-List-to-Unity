using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static XMLParser;

public class UIHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    private XMLParser xmlParser;
    public TMP_Text itemNameText;
    public TMP_Text itemDamageText;
    public TMP_Text itemTypeText;
    public TMP_Text itemReachText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemHandText;
    public TMP_Text itemAttackSpeedText;
    public TMP_Text itemUpgradeText;
    public GameObject panel;
    

    void Start()
    {
        xmlParser = FindObjectOfType<XMLParser>();
        if (xmlParser == null)
        {
            Debug.LogError("XMLParser script not found in the scene.");
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)

    {
        // Retrieve the ID of the UI element
        int objectId = GetObjectIdFromThisObject();
        panel.SetActive(true);
        // Move the panel close to the cursor with an offset
        RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
        Vector3 cursorPosition = Input.mousePosition;

        // Set the offset value
        float offsetX = 130f; // Adjust this value as needed
        float offsetY = -110f; // Adjust this value as needed

        // Set the panel's position relative to the cursor with the offset
        Vector3 panelPosition = new Vector3(cursorPosition.x + offsetX, cursorPosition.y - offsetY, 0f);

        // Set the panel's position
        panelRectTransform.position = panelPosition;

        // Check if the ID exists in the itemDataDictionary
        if (xmlParser != null && xmlParser.itemDataDictionary.ContainsKey(objectId))
        {
            // Retrieve the data associated with the ID
            XMLParser.ItemData itemData = xmlParser.itemDataDictionary[objectId];

            // Display the data on UI Text components
            itemNameText.text = "" + itemData.name;
            itemDamageText.text = "Damage: " + itemData.damage;
            itemReachText.text = "Reach: " + itemData.reach;
            itemAttackSpeedText.text = "Attack Speed: " + itemData.attackspeed;
            itemHandText.text = "" + itemData.hand;
            itemUpgradeText.text = "" + itemData.upgrade;
            itemTypeText.text = "" + itemData.type;
            itemDescriptionText.text = "" + itemData.description;
            // Add other data fields as needed
        }
        else
        {
            Debug.LogWarning("Object with ID " + objectId + " not found in the itemDataDictionary.");
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        // Clear the UI Text components when the mouse pointer exits the UI element
        itemNameText.text = "";
        itemDamageText.text = "";
        itemReachText.text = "";
        itemAttackSpeedText.text = "";
        itemHandText.text = "";
        itemUpgradeText.text = "";
        itemTypeText.text = "";
        itemDescriptionText.text = "";
        panel.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
    int GetObjectIdFromThisObject()
    {
        // Replace this method with your own logic to get the ID of the UI element
        // For example, you can use tags, names, or custom components to store IDs
        return int.Parse(gameObject.name.Replace("Item", "")); // Assuming object name is the ID
    }
}