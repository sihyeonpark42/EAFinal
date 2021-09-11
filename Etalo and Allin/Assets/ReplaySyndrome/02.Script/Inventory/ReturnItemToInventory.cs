using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnItemToInventory : MonoBehaviour
{

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        ComposedItemView composedItemView = GetComponentInParent<ComposedItemView>();
        button.onClick.AddListener(composedItemView.ReturnItem);
    }

  

   
}
