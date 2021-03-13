using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject jellyfish;
    public GameObject allPearls;
    public GameObject submarine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            GameObject jellyfishInstance1 = Instantiate(jellyfish);
            Vector3 newPosition = transform.position + (Vector3.forward * Random.Range(-40f, 40f)) + (Vector3.right * Random.Range(-40f, 40f)) + Vector3.up * 5;
            jellyfishInstance1.transform.position = newPosition;
            GameManager.Instance.CollectPearl();

            // Activate the sub if all pearls are collected
            if (allPearls.transform.childCount == 1)
            {
                submarine.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
