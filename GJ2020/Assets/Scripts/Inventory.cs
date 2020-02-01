using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public List<Item> characterItems = new List<Item>();

   [SerializeField] private ItemDB itemDB;

   public UIInventory inventoryUI;

    private void Start()
    {
        GiveItem("Spare Part");
     //   RemoveItem("Spare Part");
    }

   public void GiveItem(int id)
   {
       Item toAdd = itemDB.GetItem(id);
       characterItems.Add(toAdd);
       inventoryUI.AddNewItem(toAdd);
       Debug.Log("Added item: " + toAdd.name);
   }

    public void GiveItem(string name)
   {
       Item toAdd = itemDB.GetItem(name);
       characterItems.Add(toAdd);
    inventoryUI.AddNewItem(toAdd);
       Debug.Log("Added item: " + toAdd.name);
   }

   public Item CheckForItem(int id)
   {
       return characterItems.Find(item => item.id == id);
   }

    public Item CheckForItem(string name)
   {
       return characterItems.Find(item => item.name == name);
   }

   public void RemoveItem(int id)
   {
       Item item = CheckForItem(id);
       if(item != null)
       {
           characterItems.Remove(item);
           inventoryUI.RemoveItem(item);
           Debug.Log("Removed item: " + item.name);
       }
   }

     public void RemoveItem(string name)
   {
       Item item = CheckForItem(name);
       if(item != null)
       {
           characterItems.Remove(item);
         inventoryUI.RemoveItem(item);
           Debug.Log("Removed item: " + item.name);
       }
   }
}
