using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    Vector3 originPos;
    float shakeAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.localPosition;   
    }

    public void StartShake()
    {
        StartCoroutine("Shake");
        print("StartShake");
    }

    public IEnumerator Shake()
    {

        while (true)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle + originPos;


            yield return null;
        }
    }

    public void StopShake()
    {
        StopCoroutine("Shake");
        print("StopShake");
        transform.localPosition = originPos;
    }


}
