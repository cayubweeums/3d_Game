using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigidbody;
    public float viewDistance;
    public float moveSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool playerInSight = Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, viewDistance);
        Debug.Log("player in sight " + playerInSight);
        if (playerInSight)
        {
            rigidbody.velocity = moveSpeed * (player.transform.position - this.transform.position).normalized;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rigidbody.velocity);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit Something");
        if (collision.collider.name == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }
}
