using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject jellyfish;

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
            Vector3 newPosition = transform.position + (Vector3.up * Random.Range(-10f, 10f)) + (Vector3.right * 60);
            jellyfishInstance1.transform.position = newPosition;
            Destroy(gameObject);
        }
    }
}
