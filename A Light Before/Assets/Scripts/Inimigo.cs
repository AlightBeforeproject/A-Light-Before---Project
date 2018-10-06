using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour
{
    public Renderer render;

    public float health = 100f;

    public GameObject player;
    public GameObject spawm;

    public SphereCast sphereCast;

    public HandleTextFile handleTextFile;

    Animator animator;

    //states
    public bool run = false;
    public bool idle = false;
    public bool death = false;
    public bool atack = false;

    void start()
    {
        sphereCast = new SphereCast();
        handleTextFile = new HandleTextFile();
        render = GetComponent<Renderer>();
    }

    public void init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawm = GameObject.FindGameObjectWithTag("Spawner");
        sphereCast = player.GetComponent<SphereCast>();
        handleTextFile = spawm.GetComponent<HandleTextFile>();
    }

    void Update()
    {
        //if (sphereCast && sphereCast.colidiu == true)
        //{
        //    //print("entrou aqui");
        //    render.enabled = true;
        //}
        animator = GetComponent<Animator>();
        setAnimations();

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            handleTextFile.numInimigos -= 1;

        }

    }

    public void Die()
    {
        Destroy(gameObject);

    }

    public void setAnimations()
    {
        if (run == true)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);

        if (idle == true)
            animator.SetBool("Idle", true);
        else
            animator.SetBool("Idle", false);

        if (death == true)
            animator.SetBool("Death", true);
        else
            animator.SetBool("Death", false);

        if (atack == true)
            animator.SetBool("Atack", true);
        else
            animator.SetBool("Atack", false);
    }
}