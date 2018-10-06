using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour {

    // Use this for initialization
    Jogador jogador;

    GameObject _jogador;

    bool inGame = true;

	void Start ()
    {
        _jogador = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	//Update is called once per frame
	//void Update () 
    //{		
	//}

    public void StartGame()
    {
        //while (inGame != true)
        //{

        //}
        //print("funcionou");
    }
}
