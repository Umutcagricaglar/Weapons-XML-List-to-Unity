using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine.XR;

public class XMLParser : MonoBehaviour
{
    // Dictionary to hold parsed data
    public Dictionary<int, ItemData> itemDataDictionary = new Dictionary<int, ItemData>();

    // Define the ItemData class
    public class ItemData
    {
        public int id;
        public string name;
        public int damage;
        public string type;
		public string description;
        public string upgrade;
        public string reach;
        public string attackspeed;
        public string hand;
		
		
		

        // Constructor that takes three arguments
        public ItemData(int id, string name, int damage, string type, string description, string upgrade, string reach, string attackspeed, string hand)
        {
            this.id = id;
            this.name = name;
            this.damage = damage;
            this.type = type;
            this.description = description;
            this.upgrade = upgrade;
            this.reach = reach;
            this.attackspeed = attackspeed;
            this.hand = hand;
        }
    }

    void Start()
    {
        Debug.Log("XMLParser script started.");

        // Parse XML data and populate itemDataDictionary
        ParseXML();
    }

    public void ParseXML()
    {
        Debug.Log("Parsing XML...");

        // Load the XML file
        string filePath = Application.dataPath + "/XmlFiles/weapons.xml";
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        // Traverse the XML structure and extract data
        XmlNodeList itemNodes = xmlDoc.SelectNodes("/root/item");
        foreach (XmlNode itemNode in itemNodes)
        {
            int id = int.Parse(itemNode.SelectSingleNode("id").InnerText);
            string name = itemNode.SelectSingleNode("name").InnerText;
            int damage = int.Parse(itemNode.SelectSingleNode("damage").InnerText);
            string type = itemNode.SelectSingleNode("type").InnerText;
            string description = itemNode.SelectSingleNode("description").InnerText;
            string upgrade = itemNode.SelectSingleNode("upgrade").InnerText;
            string reach = itemNode.SelectSingleNode("reach").InnerText;
            string attackspeed = itemNode.SelectSingleNode("attackspeed").InnerText;
            string hand = itemNode.SelectSingleNode("hand").InnerText;

            // Create an ItemData object and add it to the dictionary
            ItemData itemData = new ItemData(id, name, damage, type, description, upgrade, reach, attackspeed, hand);
            itemDataDictionary.Add(id, itemData);
        }

        Debug.Log("XML parsing completed.");

        // Log the contents of the dictionary
        LogDictionaryContents();
    }

    void LogDictionaryContents()
    {
        Debug.Log("Contents of the itemDataDictionary:");
        foreach (KeyValuePair<int, ItemData> kvp in itemDataDictionary)
        {
            Debug.Log("ID: " + kvp.Key +
              ", Type: " + kvp.Value.type +
              ", Name: " + kvp.Value.name +
              ", Upgrade: " + kvp.Value.upgrade +
              ", Damage: " + kvp.Value.damage +
              ", AttackSpeed: " + kvp.Value.attackspeed +
              ", Reach: " + kvp.Value.reach +
              ", Hand: " + kvp.Value.hand +
              ", Description: " + kvp.Value.description);
        }
    }
}