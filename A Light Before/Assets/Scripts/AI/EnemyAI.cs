using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    public GameObject obstacles;
    //public GameObject RayDirections;
    
    List<GameObject> obsList;

    int sizeList = 5;
    private Transform t;

    private Transform obsPos;
    

    private Transform playerPos;

    private float range = 10.0f;

    public bool getCloset = false;

    //RaycastHit lemonHits;

    // Use this for initialization
    void Start ()
    {
        //obstacles = GameObject.FindGameObjectWithTag("Obstacles");
        //obstacles = Resources.Load("0bstacles") as GameObject;

        obsList = new List<GameObject>();
        

        Vector3 rndPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
        Vector3 objPos = new Vector3(0, 0, 0);

        //GameObject myObstacles = Instantiate(obstacles, rndPos, Quaternion.identity) as GameObject;
        //GameObject myObstacles2 = Instantiate(obstacles, rndPos, Quaternion.identity) as GameObject;

        //obsList.Add(myObstacles);
        //obsList.Add(myObstacles2);

        t = this.transform;
        obsList = GameObject.FindGameObjectsWithTag("Obstacles").ToList();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        //RayDirections = GameObject.FindGameObjectWithTag("Directions");
        //obsList.Add(obstacles);v

    }

    // Update is called once per frame
    void Update()
    {
        //AddList();
        locateObstacles();
        //DirectionHits();

        //print(t + " is " + Distance().ToString() + " units from " + playerPos.name);

        //if (obsList.Count > 0)
        //    print(GetFurthestObstacle().name + " is " + Distance().ToString() + " units from " + playerPos.name);
        //else
        //    print("Player not found!");
    }

    //void AddList()
    //{
    //    //if (Input.GetKeyDown(KeyCode.I))
    //    //{
    //        //Vector3 rndPos = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
    //        //obsList.Add((GameObject)Instantiate(obstacles, rndPos, Quaternion.identity) as GameObject);
    //    //}
    //}

    public GameObject GetFurthestObstacle()
    {
        float maxDistance = Vector3.Distance(obsList.First().transform.position, playerPos.position);
        GameObject furthest = obsList.First();

        foreach (GameObject t in obsList)
        {
            if (Vector3.Distance(t.transform.position,playerPos.position) > maxDistance)
            {
                maxDistance = Vector3.Distance(t.transform.position, playerPos.position);
                furthest = t.gameObject;
            }
        }
        return furthest;
    }

    void locateObstacles()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Debug.Log("tamanho lista: " + sizeList);
            Debug.Log("tamanho lista: " + obsList.Count);
        }
    }

    private float Distance()
    {
        return Vector3.Distance(playerPos.position, GetFurthestObstacle().transform.position);
    }

    public float DistPlayerEnemy()
    {
        return Vector3.Distance(playerPos.position, t.position);
    }

    public float DistEnemyObstacle()
    {
        return Vector3.Distance(t.position, GetFurthestObstacle().transform.position);
    }

    //public void DirectionHits()
    //{
    //    if (Physics.Raycast(RayDirections.transform.position, RayDirections.transform.forward, out lemonHits, 100f))
    //    {
    //        //print("There is something in front of the object!");
    //        //if (lemonHits.collider.gameObject.name != this.name)
    //        //{
    //        //    print(lemonHits.collider.gameObject.name);
    //        //}
    //    }
    //}
}
