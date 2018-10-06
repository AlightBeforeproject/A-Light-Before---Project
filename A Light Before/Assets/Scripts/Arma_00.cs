using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_00 : Armas
{
    Inimigo inimigo;
    Atributes atributes;

    public Arma_00()
   {
        Debug.Log("Arma_00 Construtor");
        atributes.damage = 1f;
        atributes.range = 100f;
        atributes.typeOfGun = GameObject.FindGameObjectWithTag("Arma_00");
    }

    public override void atirar()
    {
        //base.atirar();
		//Debug.Log("arma_00 atirou");
        RaycastHit hit;
        if (Physics.Raycast(
            atributes.typeOfGun.transform.position,
            atributes.typeOfGun.transform.forward,
            out hit, atributes.range))
        {
            //Debug.Log("Did hit!!! 2");
            //Debug.Log(hit.transform.name);

            inimigo = hit.transform.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                inimigo.TakeDamage(atributes.damage);
            }
        }
    }
    
    //public new void recarregar()
    //{
    //    Debug.Log("arma_00 recarregou");
    //}
}
