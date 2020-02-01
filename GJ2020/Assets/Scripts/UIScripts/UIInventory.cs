using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberofslots = 16;
    public TextMeshProUGUI text;

    bool isDupe;

    int counter = 0;

    private void Awake() {
        for(int i = 0; i < numberofslots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    public void UpdateSlot(int slot, Item item)
    {
          Debug.Log("slot is " + slot);
        Debug.Log("item is " + item.name);
        uiItems[slot].UpdateItem(item);
        
    }

    public void AddNewItem(Item item)
    {
        Debug.Log("Item in Add new Item to UI = " + item.name);
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);

    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }
}
