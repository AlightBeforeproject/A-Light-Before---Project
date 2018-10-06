using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject cameraTarget;
    EnemyController enemyController;
    HandleTextFile handleTextFile;

    public GameObject spawm;

    public Transform target;
    public Transform target2;
    public float smoothSpeed = 0.125f;

    public float rotateSpeed = 5;

    Vector3 offset;
    Vector3 offset2;
    Vector3 lastPosition;

    float rotate = 0;
    public float offsetDistance;
    public float offsetHeight;
    public float smoothing;
    public float turnSpeed = 50F;

    bool following = true;
    public bool inCombat = false;

    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 10.0f;

    public float currentX = 0.0f;
    public float currentY = 45.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;


    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player");
        lastPosition = new Vector3(cameraTarget.transform.position.x,
                                   cameraTarget.transform.position.y + Input.GetAxis("Horizontal") + offsetHeight,
                                   cameraTarget.transform.position.z - offsetDistance);

        offset = new Vector3(cameraTarget.transform.position.x,
                             cameraTarget.transform.position.y + offsetHeight,
                             cameraTarget.transform.position.z - offsetDistance);

        camTransform = transform;

        handleTextFile = new HandleTextFile();
        spawm = GameObject.FindGameObjectWithTag("Spawner");
        handleTextFile = spawm.GetComponent<HandleTextFile>();
    }

    //public void init()
    //{
        

    //}

    void Update()
    {
        //if(Input.GetKey(KeyCode.F))
        //{
        //	if(following)
        //	{
        //		following = false;
        //	} 
        //	else
        //	{
        //		following = true;
        //	}
        //} 

        //if (enemyController.isAwake == true)
        //    inCombat = true;
        //else
        //    inCombat = false;

        inCombat = cameraTarget.GetComponent<SphereCast>().colidiu;


        if (inCombat == true)
        {
            #region inCombat

            if (Input.GetKey(KeyCode.Q) || Input.GetAxis("R_Y_Button") < 0)

            {
                rotate = -2f;
                //Debug.Log(Input.GetAxis("R_X_Button"));
            }
            else if (Input.GetKey(KeyCode.E) || Input.GetAxis("R_Y_Button") > 0)
            {
                rotate = 2f;
            }
            else
            {
                rotate = 0;
            }
            if (following)
            {
                offset = Quaternion.AngleAxis(rotate * rotateSpeed, Vector3.up) * offset;
                transform.position = cameraTarget.transform.position + offset;
                transform.position = new Vector3(Mathf.Lerp(lastPosition.x, cameraTarget.transform.position.x + offset.x, smoothing * Time.deltaTime),
                    Mathf.Lerp(lastPosition.y, cameraTarget.transform.position.y + offset.y, smoothing * Time.deltaTime),
                    Mathf.Lerp(lastPosition.z, cameraTarget.transform.position.z + offset.z, smoothing * Time.deltaTime));
            }
            else
            {
                transform.position = lastPosition;
            }
            transform.LookAt(cameraTarget.transform.position);

            

            #endregion
        }

        else
        {
            #region outCombat

            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");

            if (Input.GetAxis("R_X_Button") < 0)
            {
                currentY -= Input.GetAxis("R_X_Button");
            }
            
            if (Input.GetAxis("R_X_Button") > 0)
            {
                currentY -= Input.GetAxis("R_X_Button");
            }
            if (Input.GetAxis("R_Y_Button") < 0)
            {
                currentX += Input.GetAxis("R_Y_Button");
            }
            if (Input.GetAxis("R_Y_Button") > 0)
            {
                currentX += Input.GetAxis("R_Y_Button");
            }
            //print(Input.GetAxis("R_X_Button"));
            //print(Input.GetAxis("R_Y_Button"));

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
            
            #endregion
        }

        verificarInimigos();
    }

    void LateUpdate()
    {
        if (inCombat)
        {
            lastPosition = transform.position;
        }
        else
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
        
    }

    void verificarInimigos()
    {
        if (handleTextFile.numInimigos == 0)
        {
            inCombat = false;
            cameraTarget.GetComponent<SphereCast>().colidiu = false;
        }

    }
}