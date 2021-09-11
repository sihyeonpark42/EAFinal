using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct InventoryBox
{
    public Item item;
    public int count;
    public int Count { get { return count; } set { count = value; } }
    public InventoryBox(Item i,int c)
    {
        item = i;
        count = 1;
    }

    public void AddCount()
    {
        
        count += 1;

    }

    public void MiusCount()
    {
        count -= 1;
    }
}


public class Inventory : MonoBehaviour
{
    
    public List<InventoryBox> itemList;
   // public Image inventoryBoxPrefab;
    private GameObject ContentScreen;
    
    private ItemCollection itemCollection;


    private void Awake()
    {
        itemList = new List<InventoryBox>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        itemCollection = GameObject.FindGameObjectWithTag("ItemCollection").GetComponent<ItemCollection>();
        ContentScreen = GameObject.FindObjectOfType<Canvas>().transform.GetChild(0).GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < 100; ++i)
        {
            AddItem(itemCollection.bone);
            AddItem(itemCollection.bonfire);
            AddItem(itemCollection.branch);
            AddItem(itemCollection.bullet);
            AddItem(itemCollection.cactus);
            AddItem(itemCollection.cactusfruit);
            AddItem(itemCollection.candy);
            AddItem(itemCollection.fruit);
            AddItem(itemCollection.grilledmeat);
            AddItem(itemCollection.hatchet);
            AddItem(itemCollection.log);
            AddItem(itemCollection.meat);
            AddItem(itemCollection.pebble);
            AddItem(itemCollection.petal);
            AddItem(itemCollection.pickax);
            AddItem(itemCollection.poionjelly);
            AddItem(itemCollection.poisonsac);
            AddItem(itemCollection.rock);
            AddItem(itemCollection.rope);
            AddItem(itemCollection.sand);
            AddItem(itemCollection.shovel);
            AddItem(itemCollection.skin);
            AddItem(itemCollection.slime);
            AddItem(itemCollection.slingshot);
            AddItem(itemCollection.soup);
            AddItem(itemCollection.tent);
            AddItem(itemCollection.thread);
            AddItem(itemCollection.water);
            AddItem(itemCollection.waterbag);
            AddItem(itemCollection.roastedcactusfruit);
            AddItem(itemCollection.palmleaf);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {

        int findedindex = itemList.FindIndex(x => x.item.ItemName == item.ItemName);

        if (findedindex != -1) // 찾기 성공 --- 찾기 실패시 -1을 리턴합니다. 근데왜이렇게해야값이증가하지
        {
            InventoryBox temp = itemList[findedindex];
            temp.AddCount();
            itemList[findedindex] = temp;
        }
        else
        {
            InventoryBox temp = new InventoryBox(item, 1);
            itemList.Add(temp);
        }
    }

    public void MiusItem(Item item)
    {
        int findedindex = itemList.FindIndex(x => x.item.ItemName == item.ItemName);

        if (findedindex != -1) // 찾기 성공 --- 찾기 실패시 -1을 리턴합니다. 근데왜이렇게해야값이증가하지
        {
            if(itemList[findedindex].Count == 0)
            {
                return;
            }


            InventoryBox temp = itemList[findedindex];
            temp.MiusCount();
            itemList[findedindex] = temp;
        }
        else
        {
            print("잘못된 아이템 정보입니다.");
        }

       
        
    }




}
