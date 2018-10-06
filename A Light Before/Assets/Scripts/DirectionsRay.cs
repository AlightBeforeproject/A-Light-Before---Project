using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionsRay : MonoBehaviour
{

    RaycastHit lemonHits;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DirectionHits();
    }

    public void DirectionHits()
    {
        if (Physics.Raycast(transform.position, transform.forward, out lemonHits, 100f))
        {
            //print("There is something in front of the object!");
            if (lemonHits.collider.gameObject.name != this.name)
            {
                print(lemonHits.collider.gameObject.name);
            }
        }
    }
}
