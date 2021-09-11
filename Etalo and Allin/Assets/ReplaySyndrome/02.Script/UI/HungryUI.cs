using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryUI : MonoBehaviour
{
    Image hungryImage;

    EtaloController player;

    // Start is called before the first frame update
    void Start()
    {
        hungryImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EtaloController>();
        //StartCoroutine("UpdateInfo");
    }

    // Update is called once per frame
  

    IEnumerator UpdateInfo()
    {
        while (true)
        {
            float percentage = player.currHungry / player.maxHungry;
            hungryImage.fillAmount = percentage;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
