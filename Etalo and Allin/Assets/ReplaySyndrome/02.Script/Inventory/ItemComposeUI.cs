using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.EventSystems;
using System.Linq;

public class ItemComposeUI : MonoBehaviour
{
    public GameObject composedView;
    public ItemCollection itemCollection;
    public GameObject inventoryView;
    public GameObject resultView;
  
    private GameObject player;
    private bool[] composedArayyIsEquiped;
    private Button[] inventoryItemList;

    private ComposedItemView[] composedItemView;


    private void Awake()
    {
        composedItemView = composedView.GetComponentsInChildren<ComposedItemView>();
        inventoryItemList = inventoryView.GetComponentsInChildren<Button>();
        itemCollection = GameObject.FindGameObjectWithTag("ItemCollection").GetComponent<ItemCollection>();
        if(itemCollection == null)
        {
            print("널먀ㅕㄷㅈ려ㅗㅑㅁ");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        var items = p.GetComponent<Inventory>().itemList;

        for (int i = 0; i < items.Count; ++i) // 아이템보이기
        {
            inventoryItemList[i].GetComponent<Image>().sprite = items[i].item.originalImage;
            inventoryItemList[i].GetComponentInChildren<Text>().text = items[i].Count.ToString();
            inventoryItemList[i].GetComponent<CallAddComposedItemFunc>().item = items[i].item;
        }

        for(int i=inventoryItemList.Length -1 ;i>items.Count -1 ;--i)
        {
            inventoryItemList[i].GetComponentInChildren<Text>().text = string.Empty;
        }  
    }


    public void AddItemInComposedItemView(Item item)
    {

        var p = GameObject.FindGameObjectWithTag("Player");

        
        p.GetComponent<Inventory>().MiusItem(item);
        RecalculateItemCount();
        for (int i=0;i<composedItemView.Length;++i)
        {
            if(composedItemView[i].item == null)
            {
                composedItemView[i].item = item;               
                composedItemView[i].GetComponent<Image>().sprite = item.originalImage;
                break ;
            }
        }

        CalculateComposeItem();



    }

    public void ItemCompose()
    {

        List<string> itemComposeFomulaList = new List<string>();
        for (int i = 0; i < composedItemView.Length; ++i)
        {
            if (composedItemView[i].item != null)
            {
                itemComposeFomulaList.Add(composedItemView[i].item.itemName);
            }
        }

        itemComposeFomulaList.Sort();
        string finalResult = string.Join(string.Empty, itemComposeFomulaList.ToArray());
        print(finalResult);

        var resultItem = itemCollection.ReturnComposedItem(finalResult);

        if (resultItem != null)
        {
            var inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            inven.AddItem(resultItem);

            for(int i=0;i<composedItemView.Length;++i)
            {
                composedItemView[i].item = null;
                composedItemView[i].GetComponent<Image>().sprite = composedItemView[i].originalImage;
            }

            resultView.GetComponent<Image>().sprite = composedItemView[0].originalImage;
        }

        RecalculateItemCount();
    }

    public void CalculateComposeItem()
    {
        List<string> itemComposeFomulaList = new List<string>();
        for (int i = 0; i < composedItemView.Length; ++i)
        {
            if (composedItemView[i].item != null)
            {
                itemComposeFomulaList.Add(composedItemView[i].item.itemName);
            }
        }

        itemComposeFomulaList.Sort();
        string finalResult = string.Join(string.Empty, itemComposeFomulaList.ToArray());
        print(finalResult);

        var resultItem = itemCollection.ReturnComposedItem(finalResult);

        if (resultItem != null)
        {
            resultView.GetComponent<Image>().sprite = resultItem.originalImage;
        }
        else
        {
            resultView.GetComponent<Image>().sprite = composedItemView[0].originalImage;
        }
    }
   

    public void RecalculateItemCount()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        var items = p.GetComponent<Inventory>().itemList;

        for (int i = 0; i < items.Count; ++i) // 아이템보이기
        {

            inventoryItemList[i].GetComponent<Image>().sprite = items[i].item.originalImage;
            inventoryItemList[i].GetComponentInChildren<Text>().text = items[i].Count.ToString();
            inventoryItemList[i].GetComponent<CallAddComposedItemFunc>().item = items[i].item;
        }

        CalculateComposeItem();
    }

    void OnDisable()
    {
        resultView.GetComponent<Image>().sprite = composedItemView[0].originalImage;
    }

}
