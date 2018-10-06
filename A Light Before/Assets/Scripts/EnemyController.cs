using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    UnityEvent awakeListener;

    //Transform Player;
    
    EnemyAI enemyAI_ref;
    Inimigo inimigo;

    GameObject Player;
    int MoveSpeed = 3;
    int MaxDist = 3;
    int MinDist = 5;

    //public Transform target;
    private NavMeshHit hit;
    public bool blocked = false;
    public bool podeContornar = false;
    public bool needScape = false;

    public Transform targetObstacle;
    public Vector3 dir = new Vector3();

    RaycastHit hit2;

    //    public bool isAwake = false;
    //public bool isAwake = false;
    

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //awakeListener = Player.GetComponent<SphereCast>().awakeEnemies;
        //awakeListener.AddListener(WakeUp);
        enemyAI_ref = GetComponent<EnemyAI>();
        inimigo = GetComponent<Inimigo>();

    }

    void Update()
    {


        if (enemyAI_ref && !podeContornar)
        {
            transform.LookAt(enemyAI_ref.GetFurthestObstacle().transform);
        }

        print("dist inimigo obstaculo: " + enemyAI_ref.DistEnemyObstacle());
        //print("Distancia " + enemyAI_ref.RangeDistance());

        //isAwake = Player.GetComponent<SphereCast>().colidiu;
        if (enemyAI_ref.DistPlayerEnemy() <= 3.0f)
        {
            inimigo.atack = true;

            if (inimigo.health <= 40.0f)
            {
                needScape = true;
                inimigo.atack = false;
            }
        }
        else if(enemyAI_ref.DistEnemyObstacle() <= 5.0f)
        {
            if (inimigo.health >= 40.0f)
            {
                needScape = false;
            }
            
            //inimigo.run = false;
            podeContornar = true;
        }
        if (podeContornar)
        {
            evadeObstacle();
        }
        else
        {
            RunForest();
        }

        
        
    }
    void evadeObstacle()
    {
        dir = (targetObstacle.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(transform.position, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }

        Vector3 leftR = transform.position;
        Vector3 rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(leftR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }
        if (Physics.Raycast(rightR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(rightR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }


        Quaternion rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 4 * Time.deltaTime;
    }

    void evadeObstacle(Transform target)
    {
        dir = (target.position - transform.position).normalized;

        if (Physics.Raycast(transform.position, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(transform.position, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }

        Vector3 leftR = transform.position;
        Vector3 rightR = transform.position;

        leftR.x -= 2;
        rightR.x += 2;

        if (Physics.Raycast(leftR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(leftR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }
        if (Physics.Raycast(rightR, transform.forward, out hit2, 20))
        {
            if (hit2.transform != transform)
            {
                Debug.DrawLine(rightR, hit2.point, Color.red);
                dir += hit2.normal * 50;
            }
        }


        Quaternion rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 4 * Time.deltaTime;
    }

    void RunForest()
    {
       
            inimigo.run = true;
            if (Vector3.Distance(transform.position, Player.transform.position) >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
                {
                    // minhas funcoes
                }
            
        }
    }
}
