using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureUI : MonoBehaviour
{
    // Start is called before the first frame update
    Image temperatureImage;
    Text temperatureText;
    EtaloController player;

    // Start is called before the first frame update
    void Start()
    {
        temperatureImage = GetComponent<Image>();
        temperatureText = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EtaloController>();
        //StartCoroutine("UpdateInfo");
    }

    // Update is called once per frame


    IEnumerator UpdateInfo()
    {
        while (true)
        {
            //double amount = (player.currTemperature - player.optimalTemperature) / player.dangerTemperatureAmount + 0.5;
            
           // temperatureImage.fillAmount = Mathf.Clamp((float)amount,0.0f,1.0f);

            temperatureText.text = System.Math.Round( player.currTemperature).ToString();
            

            yield return new WaitForSeconds(0.3f);
        }
    }
}
