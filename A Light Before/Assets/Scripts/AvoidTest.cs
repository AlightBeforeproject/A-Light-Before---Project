using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidTest : MonoBehaviour {

    public Transform target;

    public Vector3 dir = new Vector3();
    RaycastHit hit2;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        dir = (target.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, transform.forward, out hit2, 20))        
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(transform.position, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }

       Vector3 leftR = transform.position;
       Vector3 rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(leftR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }
        if (Physics.Raycast(rightR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(rightR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }


        Quaternion rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime);
        transform.position += transform.forward * 4 * Time.deltaTime;

    }
    
}
