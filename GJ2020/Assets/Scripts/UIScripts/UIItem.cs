using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    private Image spriteImage;

    //public Sprite player;

   private void Awake() 
   {

       spriteImage = GetComponent<Image>();
      // UpdateItem(null, false);

    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
            {
            Debug.Log("SHOULD UPDATE PICTURE");
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
            }
        else 
        {
            spriteImage.color = Color.clear;
        }
    }

}
