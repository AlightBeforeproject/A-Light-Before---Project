using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    //Variaveis
    [SerializeField]
    float life = 100.0f;
    float vel = 6.0F;
    float velTurn = 50F;
    float velJump = 8.0F;
    float gravity = 20.0F;

    bool canJump = false;

    public Vector3 moveDirection = Vector3.zero;

    //Objetos e classes
    Animator animator;
    CharacterController controller;

    Armas[] armas = new Armas[3];

    //Arma_00[] armas = new Arma_00[3];

    void Start ()
    {
        //Armas myArmas = new Arma_00();

        //Arma_00 myArma_00 = (Arma_00)myArmas;

        Arma_00 myArma_00 = new Arma_00();

        armas[0] = myArma_00;

       
       
        //Fruit myFruit = new Apple();

        //myFruit.SayHello();
        //myFruit.Chop();

        //Fruit myApple = (Apple)myFruit;

        //myApple.SayHello();
        //myApple.Chop();


        
    }
	
	void Update ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (controller.isGrounded)
        {
            moveInDirections();
            inputControllers();
            setAnimations();
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void moveInDirections()
    {
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        transform.Rotate(Vector3.up, velTurn * Input.GetAxis("Horizontal") * Time.deltaTime);
        moveDirection *= vel;
    }

    void inputControllers()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, velTurn * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -velTurn * Time.deltaTime);
        }
        if (Input.GetKey("f") || Input.GetButton("R1_Button"))
        {
            armas[0].atirar();
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump2"))
        {
            moveDirection.y = velJump;
            canJump = true;
        }
        else
            canJump = false;
    }

    void setAnimations()
    {
        if (canJump == true)
            animator.SetBool("Jump", true);
        else
            animator.SetBool("Jump", false);
    }
}
