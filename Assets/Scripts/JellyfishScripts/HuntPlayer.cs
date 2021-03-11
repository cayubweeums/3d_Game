using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rigidbody;
    private AudioSource source;
    public float viewDistance;
    public float moveSpeed;
    public float soundDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool playerInSight = Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, viewDistance);
        Debug.Log("player in sight " + playerInSight);
        if (playerInSight)
        {
            rigidbody.velocity = moveSpeed * (player.transform.position - this.transform.position).normalized;
            if (Physics.Raycast(this.transform.position, player.transform.position - this.transform.position, soundDistance))
            {
                if (!source.isPlaying)
                {
                    source.Play();
                }
            } else
            {
                source.Stop();
            }
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
