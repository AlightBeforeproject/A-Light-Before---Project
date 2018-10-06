using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas
{
    // cada arma possui:
    // numBalas()
    // atirar()
    // recarregar()
    // velocidadeDeReload


    //public Armas()
    //{
    //    Debug.Log("Armas Construtor");
    //}

    

    public struct Atributes
    {
        public float damage;
        public float range;
        public GameObject typeOfGun;
    }

    Atributes atributes;

    public virtual void atirar()
    {
        Debug.Log("tipo");
    }
    public virtual void recarregar()
    {       
    }
}
