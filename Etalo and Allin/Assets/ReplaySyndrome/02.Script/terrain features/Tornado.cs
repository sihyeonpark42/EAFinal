using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private Vector3[] positions;
    private int positionsCount = 20;
    private float speed = 20;
    private int currPosIndex = 0;
    public float tornadoRadius = 50.0f;

    void Awake()
    {
        positions = new Vector3[positionsCount];
        StartCoroutine("SpeedSetter");
        for (int i = 0; i < positionsCount; ++i)
        {
            positions[i] = new Vector3(Random.Range(-5000.0f, 5000.0f), 0, Random.Range(-5000.0f, 5000.0f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destDir = positions[currPosIndex] - transform.position;
        //transform.Translate(destDir.normalized * Time.deltaTime * speed);

        if(Vector3.Distance(positions[currPosIndex], transform.position) < 100.0f)
        {
            ++currPosIndex;
            currPosIndex = currPosIndex % positionsCount;
            print(currPosIndex);
        }
    }

    IEnumerator SpeedSetter()
    {
        while(true)
        {
            speed = Random.Range(10.0f, 50.0f);

            yield return new WaitForSeconds(5.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1f,1f);
        for (int i = 0; i < positions.Length; ++i)
        {
            Gizmos.DrawSphere(positions[i], 10);
        }


        Gizmos.DrawSphere(transform.position, 50);

    }
}
