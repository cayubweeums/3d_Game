using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code based off of tutorial https://www.youtube.com/watch?v=eMpI1eCsIyM
public class globalFlock : MonoBehaviour
{

    public GameObject fishPrefab;
    public GameObject goalPrefab;
    public static Vector3 tankSize = new Vector3(300f,40f,200f);

    public static int numFish = 100;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;
    public int goalLife;
    public int groups = 5;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-tankSize.x, tankSize.x),
                Random.Range(-tankSize.y, tankSize.y),
                Random.Range(-tankSize.z, tankSize.z));
            allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity, this.transform);
            allFish[i].GetComponent<flock>().setGlobalHook(this);
        }

    }
    
    public Vector3 getGoal()
    {
        Debug.Log("fish asking for goal");
        if (goalLife-- != 0) return goalPos;
        //otherwise calculate a new one
        goalLife = numFish / groups;
        goalPos = transform.position + new Vector3(Random.Range(-tankSize.x, tankSize.x),
            Random.Range(-tankSize.y, tankSize.y),
            Random.Range(-tankSize.z, tankSize.z));
        goalPrefab.transform.position = goalPos;

        return goalPos;
    }


}
