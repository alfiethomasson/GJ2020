using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{

    public List<Item> items;

    // Start is called before the first frame update
   void BuildDB()
   {
       items = new List<Item>(){ new Item(0, "Spare Part", "A rusty old part from a long forgotten era.")};
    //   Debug.Log(items.Find(item => item.id == 0).name);
   }

  private void Awake() {
       {
           BuildDB();
       }
   }

   public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }

}
