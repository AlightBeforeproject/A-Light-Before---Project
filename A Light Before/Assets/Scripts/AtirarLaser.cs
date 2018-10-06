using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirarLaser : MonoBehaviour
{

    RaycastHit pontoDeColisao;
    public string TagInimigo = "Inimigo";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            Debug.Log("Hitou");
            if (Physics.Raycast(transform.position, transform.forward, out pontoDeColisao))
            {
                if (pontoDeColisao.transform.gameObject.tag == TagInimigo)
                {
                    //gameObject.GetComponent<Inimigo>().vida -= 10;
                    //Debug.DrawLine(pontoDeColisao, pontoDeColisao, Color.green, 2);
                }
            }
        }

    }
}
