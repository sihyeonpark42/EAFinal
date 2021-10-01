using ExitGames.Client.Photon.StructWrapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MousePointerOnImage : MonoBehaviour , IPointerClickHandler
{
    private EventTrigger eventTrigger;
    public Image itemImage;
    //public Image detailImagePrefab;
    public Text itemCountText;
    //public Image detailImage;

    //private bool isShowDetailImage = false;
    private Image instantinatedObject = null;
    private bool isAssigned = false;
    

    public bool IsAssigned
    {
        get { return isAssigned; }
        set { isAssigned = value; }
    }

    
    

    private void Awake()
    {
        itemCountText = GetComponentInChildren<Text>();
        itemImage = GetComponent<Image>();
        //detailImage = transform.Find("DetailImage").GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        eventTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry mousePointerEnter = new EventTrigger.Entry();
        mousePointerEnter.eventID = EventTriggerType.PointerEnter;
        mousePointerEnter.callback.AddListener((data) => MousePointerEnter((PointerEventData)data, gameObject));
        eventTrigger.triggers.Add(mousePointerEnter);

        EventTrigger.Entry mousePointerExit = new EventTrigger.Entry();
        mousePointerExit.eventID = EventTriggerType.PointerExit;
        mousePointerExit.callback.AddListener((data) => MousePointerExit((PointerEventData)data, gameObject));
        eventTrigger.triggers.Add(mousePointerExit);
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsAssigned)
        {
            itemCountText.gameObject.SetActive(false);
        }
        else
        {
            itemCountText.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (instantinatedObject != null)
        {
            Destroy(instantinatedObject.gameObject);
            //isShowDetailImage = false;
        }
    }



    private void MousePointerEnter(PointerEventData data,GameObject g)
    {

        if (isAssigned)
        {
            //instantinatedObject = Instantiate(detailImagePrefab, transform.parent.parent);
            //instantinatedObject.GetComponent<RectTransform>().position = gameObject.transform.position;
            //instantinatedObject.GetComponent<RectTransform>().position = gameObject.transform.position;
            //instantinatedObject.GetComponent<Image>().sprite = detailImage.sprite;
            //isShowDetailImage = true;
        }
        else
        {
            print("ISAssigned False");
        }
       
    }

    private void MousePointerExit(PointerEventData data, GameObject g)
    {
        if (isAssigned)
        {
            Destroy(instantinatedObject.gameObject);
            //isShowDetailImage = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAssigned)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            var itemlist = player.GetComponent<Inventory>().itemList;
            int pivot = itemlist.FindIndex(x => x.item.itemName == itemImage.sprite.name);
            print(itemlist[pivot].item.itemName);


            
            GameObject.FindGameObjectWithTag("ItemCollection").
                GetComponent<ItemCollection>().MakePlayerItemPlaceState((itemlist[pivot].item.itemName));
        }
        else
        {
            print("할당되지 않았습니다.");
        }
    }
}
