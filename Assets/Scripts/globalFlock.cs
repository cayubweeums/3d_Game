using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code based off of tutorial https://www.youtube.com/watch?v=eMpI1eCsIyM
public class globalFlock : MonoBehaviour
{

    public GameObject fishPrefab;
    public GameObject goalPrefab;
    public static int tankSize = 10;

    private static int numFish = 100;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity, this.transform);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, 1000) < 5)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
            goalPrefab.transform.position = goalPos;
        }


    }
}
