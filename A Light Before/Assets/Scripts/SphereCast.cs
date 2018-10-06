using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereCast : MonoBehaviour
{
    public Material matt;
    public float radius = 0f;
    public Renderer[] renders;
    public Collider[] coliders;
    public LayerMask mask;
    private Vector3 origin = Vector3.zero;

    public UnityEvent awakeEnemies;

    //[SerializeField]
    public bool colidiu = false;

    public Jogador jogador;

   

    //// Use this for initialization
    void Start()
    {
        jogador = GetComponent<Jogador>();
    }

    //// Update is called once per frame
    //void Update () {

    //}

    void LateUpdate() //void Update()
    {
        coliders = Physics.OverlapSphere(transform.position, radius, mask);
        foreach (Collider col in coliders) // para cada vez que colide, ele faz isso
        {
            if (col.tag == "Other")
            {
                colidiu = true;
                awakeEnemies.Invoke();
                col.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        if (Input.GetMouseButton(0))
        {
            radius += 0.5f;
        }
        else if (Input.GetMouseButton(1))
        {
            radius -= 0.5f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Debug.DrawLine(origin, radius);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
