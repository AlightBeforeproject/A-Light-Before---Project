using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    Inimigo inimigo;
    
    void Update ()
    {
        if (Input.GetKey("f") || Input.GetButton("R1_Button"))
        {
            Shoot();
        }	
	}

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("Did hit!!!");
            Debug.Log(hit.transform.name);

            inimigo = hit.transform.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                inimigo.TakeDamage(damage);
            }
        }        
    }
}
