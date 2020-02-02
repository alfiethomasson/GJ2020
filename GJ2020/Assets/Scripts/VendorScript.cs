using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorScript : MonoBehaviour
{
    [SerializeField] private ItemDB itemDB;

  public UIInventory inventoryUI;

     public bool isActive;

     public CanvasGroup vendorCanvasGroup;

    void Start()
    {
        ResetShop();
    }

    public void AddItem(string name)
   {
       Item toAdd = itemDB.GetItem(name);
       Debug.Log("Adding item " + toAdd.name);
     //  characterItems.Add(toAdd);
       inventoryUI.AddNewItem(toAdd);
       Debug.Log("Added item: " + toAdd.name);
   }

   public void AddItem(int id)
   {
       Item toAdd = itemDB.GetItem(id);
       Debug.Log("Adding item " + toAdd.name);
     //  characterItems.Add(toAdd);
       inventoryUI.AddNewItem(toAdd);
       Debug.Log("Added item: " + toAdd.name);
   }

   int[] whatItems()
   {
       int item = Random.Range(0, 3);
       int item1 = Random.Range(0, 3);
       int item2 = Random.Range(0, 3);
       int[] items = {item, item1, item2};
       return items;
   }

   void ResetShop()
   {
       int[] items = whatItems();
       AddItem("SpeedPowerUp");
       AddItem(items[0]);
       AddItem("Health Increase");
       AddItem(items[1]);
       AddItem("Wings");
       AddItem(items[2]);

   }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            if(Input.GetButtonDown("Interact"))
            {
                isActive = !isActive;
                if(isActive)
                {
                    vendorCanvasGroup.alpha = 1.0f;
                }
                else if (!isActive)
                {
                    vendorCanvasGroup.alpha = 0.0f;
                }
               // vendorCanvas.SetActive(isActive);
            }
        }
    }
}
