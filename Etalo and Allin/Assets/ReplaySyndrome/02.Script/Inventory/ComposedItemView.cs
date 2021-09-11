using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComposedItemView : MonoBehaviour
{
    public Sprite originalImage;
    public Sprite showImage;
    public Item item;


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        item = null;
    }

    private void OnDisable()
    {
        if(item!=null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(item);
        }


        item = null;
        GetComponent<Image>().sprite = originalImage;
    }

    public void ReturnItem()
    {


        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(item);
       
        

        item = null;
        GetComponent<Image>().sprite = originalImage;


        GetComponentInParent<ItemComposeUI>().RecalculateItemCount();
    }
}
