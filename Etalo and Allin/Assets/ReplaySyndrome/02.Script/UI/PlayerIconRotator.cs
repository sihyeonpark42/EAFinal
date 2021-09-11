using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIconRotator : MonoBehaviour
{

    private RectTransform playerIconRT;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerIconRT = GetComponent<RectTransform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerIconRT.rotation = Quaternion.Euler(0,0, -playerTransform.eulerAngles.y);
    }
}
