using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherScript : MonoBehaviour
{

    public bool isActive;


    [SerializeField] private ItemDB itemDB;

  public UIInventory inventoryUI;

     public CanvasGroup brotherCanvasGroup;

    void Start()
    {
        Debug.Log("Adding 3 items");
        AddItem("Cog");
        AddItem("Screw");    
        AddItem("NutsAndBolts");
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

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            if(Input.GetButtonDown("Interact"))
            {
                isActive = !isActive;
               // brotherCanvas.SetActive(isActive);
               if(isActive)
               {
                   brotherCanvasGroup.alpha = 1.0f;
               }
               else if(!isActive)
               {
                   brotherCanvasGroup.alpha = 0.0f;
               }
            }
        }
    }
}
