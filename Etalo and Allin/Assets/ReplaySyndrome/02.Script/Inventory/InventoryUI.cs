using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    private GameObject player;
    private Inventory playerInventory;
    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            print("NULL");
        }
    }
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        playerInventory = player.GetComponent<Inventory>();
        var playerInventoryList = playerInventory.itemList;
        var inventoryBoxes = GetComponentsInChildren<MousePointerOnImage>();

        foreach(var i in inventoryBoxes)
        {
            i.IsAssigned = false;
        }

        print(playerInventoryList.Count);

        
        for(int i=0;i<playerInventoryList.Count;++i)
        {
            
            //inventoryBoxes[i].detailImagePrefab.sprite = playerInventoryList[i].item.detailImage; // 이게 프리팹이라 같은 이미지가나온다....
            inventoryBoxes[i].itemImage.sprite = playerInventoryList[i].item.originalImage;
            //inventoryBoxes[i].detailImage.sprite = playerInventoryList[i].item.detailImage;
            inventoryBoxes[i].itemCountText.text = playerInventoryList[i].Count.ToString();
            inventoryBoxes[i].IsAssigned = true;
        }
    }
}
