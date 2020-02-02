using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrotherScript : MonoBehaviour
{

    public bool isActive;


    [SerializeField] private ItemDB itemDB;

  public UIInventory inventoryUI;

     public CanvasGroup brotherCanvasGroup;

    public GameObject brother1;
    public GameObject brother2;
    public GameObject brother3;

    public Inventory playerInv;

   // public AudioClip hammer;

    AudioSource audio;

    void Start()
    {
        Debug.Log("Adding 3 items");
        AddItem("Cog");
        AddItem("Screw");    
        AddItem("NutsAndBolts");

        audio = GetComponent<AudioSource>();    
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

                Item newItem = playerInv.CheckForItem("Screw");
                Item newItem1 = playerInv.CheckForItem("Cog");
                Item newItem2 = playerInv.CheckForItem("NutsAndBolts");

                if (newItem != null)
                {
                    if (newItem.name == "Screw" && brother1.GetComponent<Image>().color != Color.green)
                    {
                        audio.Play();
                        brother1.GetComponent<Image>().color = Color.green;
                    }
                }
                if (newItem != null)
                {
                    if (newItem1.name == "Cog" && brother2.GetComponent<Image>().color != Color.green)
                    {
                            audio.Play();
                        brother2.GetComponent<Image>().color = Color.green;
                    }
                }
                if (newItem != null)
                {
                    if (newItem2.name == "NutsAndBolts" && brother3.GetComponent<Image>().color != Color.green)
                    {
                          audio.Play();
                        brother3.GetComponent<Image>().color = Color.green;
                    }
                }

                if (isActive)
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
