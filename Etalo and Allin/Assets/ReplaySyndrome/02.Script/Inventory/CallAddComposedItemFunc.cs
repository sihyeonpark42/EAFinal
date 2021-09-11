using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallAddComposedItemFunc : MonoBehaviour
{
    public Item item = null;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(CallAddComposedItemInParent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        item = null;
    }

    public void CallAddComposedItemInParent()
    {
        var p = GameObject.FindGameObjectWithTag("Player");


        var itemlist = p.GetComponent<Inventory>().itemList;

        if (item != null)
        {
            for(int i=0;i<itemlist.Count;++i)
            {
                if (itemlist[i].item == item)
                {
                    if (itemlist[i].count > 0)
                    {
                        GetComponentInParent<ItemComposeUI>().AddItemInComposedItemView(item);
                    }
                    else
                    {
                        print("아이템 수량이 0입니다.");
                    }
                }
               
            }


           
        }
    }
}
