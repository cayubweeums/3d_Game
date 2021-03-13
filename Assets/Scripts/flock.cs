using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code based off of tutorial https://www.youtube.com/watch?v=eMpI1eCsIyM
public class flock : MonoBehaviour
{

    public float speedMultiplier;
    private float speed;
    private float rotationSpeed = 2f;
    private float neighborDistance = 100f;
    public float avoidFactor = 100f;
    private int spentFrames;
    private int framesTilBored = 400;
    private Vector3 target;
    private globalFlock globalHook;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(speedMultiplier, 2 * speedMultiplier);
        spentFrames = Random.Range(0, framesTilBored);
    }

    public void setGlobalHook(globalFlock g)
    {
        globalHook = g;
    }

    
    void FixedUpdate()
    {
        if (spentFrames++ > framesTilBored)
        {
            spentFrames = 0;
            target = globalHook.getGoal();
        }

        bool turning = (Vector3.Distance(transform.position, target) >= globalFlock.tankSize.magnitude);

        if (turning)
        {
            Vector3 direction = target - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed * Time.deltaTime);
            speed = Random.Range(speedMultiplier, 2 * speedMultiplier);
        } else if (Random.Range(0, 5) < 1)
        {
            ApplyRules();
        }

        transform.Translate(0,0,Time.deltaTime*speed);

    }

    void ApplyRules()
    {
        GameObject[] gos = globalFlock.allFish;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = .1f;

        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                float dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighborDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if (dist < 1f)
                    {
                        vavoid = vavoid + avoidFactor * (this.transform.position - go.transform.position);
                    }

                    flock otherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + otherFlock.speed;

                }
            }
        }

        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (target - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != target)
                this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation,
                    Quaternion.LookRotation(direction),
                    rotationSpeed * Time.deltaTime
                );

        }


    }
}
