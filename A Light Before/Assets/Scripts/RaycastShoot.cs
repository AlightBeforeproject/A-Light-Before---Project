using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

    RaycastHit hitInfo;
    float raycastWidth = 10f;

    void Start()
    {
    }

        void Update()
    {
        //// Bit shift the index of the layer (8) to get a bit mask
        //int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
        Debug.DrawRay(transform.position, transform.forward * 50, Color.yellow);

        Ray ray = new Ray(this.transform.position, this.transform.forward);
       

        if (Physics.Raycast(ray,out hitInfo, 50f /*raycastWidth*/))
        {
            if (hitInfo.collider.tag == "Inimigo")
            {
                //Debug.DrawRay(transform.position, transform.forward * raycastWidth, Color.yellow);
                //Debug.DrawRay(transform.position, 
                //    transform.TransformDirection(Vector3.forward) * hitInfo.distance, 
                //    Color.yellow);
                Debug.Log("Did hit!!!");
            }
        }

        // Does the ray intersect any objects excluding the player layer

        //if (Physics.Raycast(this.transform.position, transform.forward))
        //{

        //}

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
        //    out hit, Mathf.Infinity, layerMask))
        //{
        //    //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //    Debug.Log("Did Hit");
           

        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}
    }
}
