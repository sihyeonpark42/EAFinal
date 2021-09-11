using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstUI : MonoBehaviour
{
    Image thirstImage;

    EtaloController player;

    // Start is called before the first frame update
    void Start()
    {
        thirstImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EtaloController>();
        StartCoroutine("UpdateInfo");
    }

    // Update is called once per frame


    IEnumerator UpdateInfo()
    {
        while (true)
        {
            float percentage = player.currThirst / player.maxThirst;
            thirstImage.fillAmount = percentage;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
