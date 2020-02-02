using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{

    public List<Item> items;

    // Start is called before the first frame update
   void BuildDB()
   {
       items = new List<Item>(){ new Item(0, "Spare Part", "A rusty old part from a long forgotten era."), new Item(1, "Cog", "You know what really grinds my gears?"), new Item(2, "Screw", "Ah, Screw it."), new Item(3, "NutsAndBolts", "You'd be nuts not too."), new Item(4, "SpeedPowerUp", "Zoom!"), new Item(5, "Health Increase", "The first rule of fight clu-"), new Item(6, "Wings", "Mine."), new Item(7, "CarBattery", "Maybe I could hook these up to my nipples?")};
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
