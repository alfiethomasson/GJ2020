using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public GameObject Brother1;
      public GameObject Brother2;
        public GameObject Brother3;
        public Transform BrotherSlotPanel;
    public Transform slotPanel;
    public int numberofslots = 16;
    public TextMeshProUGUI text;

    bool isDupe;
     GameObject instance;

    int counter = 0;

    private void Awake() {
        for(int i = 0; i < numberofslots; i++)
        {
            Debug.Log("In number of slots thing");
            if(this.name == "BrotherBackPanel" )
            {
                if(i == 0)
                {
                    instance = Instantiate(Brother1);
                }
                else if(i == 1)
                {
                    instance = Instantiate(Brother2);
                }
                else if(i == 2)
                {
                    instance = Instantiate(Brother3);
                }
            instance.transform.SetParent(BrotherSlotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
            Debug.Log("Added a uiItem1");
            }
            else
            {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
                    Debug.Log("Added a uiItem2");
            }
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
        Debug.Log("UI items count: " + uiItems.Count);
        for(int i = 0; i < uiItems.Count; i++)
        {
            Debug.Log(uiItems[i].name);     
        }
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);

    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }

    public void ResetInv()
    {
        uiItems.Clear();
    }
}
