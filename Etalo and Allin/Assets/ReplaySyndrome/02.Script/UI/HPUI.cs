using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    Image HPImage;

    EtaloController player;

    // Start is called before the first frame update
    void Start()
    {
        HPImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EtaloController>();
        StartCoroutine("UpdateInfo");
    }

    // Update is called once per frame


    IEnumerator UpdateInfo()
    {
        while (true)
        {
            float percentage = player.currHP / player.maxHP;
            HPImage.fillAmount = percentage;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
