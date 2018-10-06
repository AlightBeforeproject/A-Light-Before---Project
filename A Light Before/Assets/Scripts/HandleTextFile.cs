using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class HandleTextFile : MonoBehaviour
{
    //CharacterGenerator thisCharacter;

    #region grid prefabs
    [SerializeField]
    private GameObject gridTile;

    [SerializeField]
    private GameObject enemyObj;
    #endregion

    [SerializeField]
    private int xOffset = 1;

    [SerializeField]
    private int zOffset = 1;

    [SerializeField]
    private int _mapWidth = 0;
    public int mapWidth
    {
        get
        {
            return _mapWidth;
        }
        private set
        {
            _mapWidth = value;
        }
    }
    [SerializeField]
    private int _mapHeight = 0;
    public int mapHeight
    {
        get
        {
            return _mapHeight;
        }
        private set
        {
            _mapHeight = value;
        }
    }

    //TextAsset temp = Resources.Load("map.txt") as TextAsset;

    //TextAsset _text = new

    // maneira a ser lida pelo editor da unity
    string filePath = "Assets\\StreamingAssets\\";
    //string filePath = "Assets\\Resources\\";
    
    // maneira para enviar para a build
    //string filePath = "A Light Before - Prototype_Data\\Resources\\";
    //string filePath = "A Light Before - Prototype_Data\\StreamingAssets\\";

    //Random rnd = new Random();
    [SerializeField]
    int testeRand = 0;
    public int numInimigos = 0;

    string filename;
    string txtContents;
    string text;

    string[] map = new string[5];
    string[] recebeMap = new string[5];
    string s;
    int[] linha = new int[3];
    int[] coluna = new int[5];

    #region leituraInimigos

    FileInfo theSourceFile = null;
    StreamReader reader = null;
    string text2 /*= " "*/; // assigned to allow first line to be read below
    char[] delimiter2 = { ':' };
    string[] fields2 = null;

    #endregion

    void Start()
    {
        WriteText("test");
        createMap("test");

        // maneira a ser lida pelo editor da unity
        //theSourceFile = new FileInfo("Assets\\Resources\\test.txt");
        theSourceFile = new FileInfo("Assets\\StreamingAssets\\test.txt");

        //maneira para enviar para build
        //theSourceFile = new FileInfo("A Light Before - Prototype_Data\\StreamingAssets\\test.txt");
        
        reader = theSourceFile.OpenText();


        //createEnemies("map");
        //print("passou aqui");
        //LoadText("map");
        //createEnemies();

        
    }

    void Update()
    {

        //print(numInimigos);
        //createMap("map");
        //WriteText("test");
        //LoadText("test");
    }

    //MemoryStream stream = new MemoryStream(byteArray);

    public void WriteText(string writeTxt)
    {
        filename = filePath + writeTxt + ".txt";
        StreamWriter myStrWriter = new StreamWriter(filename);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                randomFunc();
                myStrWriter.Write(testeRand + ":");
                //coluna[i] = testeRand;
                //linha[j] = testeRand;

            }
            myStrWriter.Write(myStrWriter.NewLine);
        }


        //myStrWriter.WriteLine("Done");

        myStrWriter.Flush();
        myStrWriter.Close();
    }

    public void createMap(string mapType)
    {
        filename = filePath + mapType + ".txt";
        StreamReader myMapCreator = new StreamReader(filename);

        //string s = myMapCreator.ReadLine();
        string s = myMapCreator.ReadToEnd();
        char[] delimiter = { ':' };
        string[] fields = s.Split(delimiter);

        //for (int x = 0; x < map.Length; x++)
        //{
        //recebeMap[x] = myMapCreator.ToString();
        //Debug.Log("YEAH 2");

        //map[x] = recebeMap[x];

        //if (fields[4] == "0")
        //{
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                //if (fields[y] == "1")
                //{
                //    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //    //cube.AddComponent<Rigidbody>();
                //    cube.transform.position = new Vector3(0, 5, 0);
                //}
                //if (fields[y] == "0")
                //{
                //    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //    //sphere.AddComponent<Rigidbody>();
                //    sphere.transform.position = new Vector3(0, 10 + 5, 0);
                //}

                GameObject TilePrefab = Instantiate
                (gridTile, new Vector3(xOffset * j - mapWidth * xOffset, 0, zOffset * mapHeight - i * zOffset),
                Quaternion.identity) as GameObject;

                //TilePrefab.transform.parent = transform.
                //if (fields[i] == "1")
                //{
                //    GameObject enemyPrefab = Instantiate
                //        (enemyObj, new Vector3(xOffset * j - mapWidth /** xOffset*/, 0, zOffset * mapHeight - i /** zOffset*/),
                //        Quaternion.identity) as GameObject;
                //}
            }
            Debug.Log("YEAH");
            myMapCreator.Close();
        }
    }

    public void createEnemies(/*string mapType*/)
    {
        text2 = reader.ReadLine();
        int i = 0;

        while (text2 != null)
        {
            fields2 = text2.Split(delimiter2);
            for (int j = 0; j < 5; j++)
            {
                if (fields2[j] == "1")
                {
                    numInimigos += 1;
                    print(fields2[j]);
                    GameObject enemyPrefab = Instantiate
                        (enemyObj, new Vector3(xOffset * j - mapWidth * xOffset,
                        0, zOffset * mapHeight - i * zOffset),
                        Quaternion.identity) as GameObject;

                    
                    enemyPrefab.GetComponent<Inimigo>().init();

                }
            }
            text2 = reader.ReadLine();
            i++;
        }
    }
    //filename = filePath + mapType + ".txt";
    //StreamReader myMapCreator2 = new StreamReader(filename);
    //myMapCreator2.Read();

    //theSourceFile = new FileInfo(filename);
    //reader = theSourceFile.OpenText();

    //string s = myMapCreator2.ReadLine();
    //string s = myMapCreator2.ReadToEnd();
    //char[] delimiter = { ':' };
    //string[] fields = s.Split(delimiter);

    //text2 = reader.ReadLine();
    //if (text2 != null)
    //{
    //    fields2 = text2.Split(delimiter2);
    //    print(fields2[0]);
    //    //for (int i = 0; i < 5; i++)
    //    //{
    //    //    if (fields2[0] == "1")
    //    //    {
    //    //        GameObject enemyPrefab = Instantiate
    //    //                (enemyObj, new Vector3(xOffset /*+ i*/ /** j*/ - mapWidth * xOffset,
    //    //                0, zOffset * mapHeight /*- i*/ * zOffset),
    //    //                Quaternion.identity) as GameObject;

    //    //    }
    //    //}
    //    //for (int i = 0; i < 5; i++)
    //    //{
    //    //    print(fields2[i]);
    //    //}





    //for (int i = 0; i < 3; i++)
    //{
    //    for (int j = 0; j < 5; j++)
    //    {
    //        if (fields[i][j] == "1")
    //        {
    //            GameObject enemyPrefab = Instantiate
    //                    (enemyObj, new Vector3(xOffset /** j*/ - mapWidth * xOffset,
    //                    0, zOffset * mapHeight - i * zOffset),
    //                    Quaternion.identity) as GameObject;

    //        }
    //        Debug.Log(fields[i]);
    //        myMapCreator2.Close();
    //    }
    //}

    public void LoadText(string loadTxt)
    {
        filename = filePath + loadTxt + ".txt";
        StreamReader myStrReader = new StreamReader(filename);
        text = myStrReader.ReadToEnd();

        //txtContents = myStrReader

        myStrReader.Read();
        //Debug.Log(text);

        myStrReader.Close();
    }



    void OnGUI()
    {
        GUILayout.Label(text);
    }

    public void randomFunc()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            testeRand = Random.Range(0, 2);
        //}
    }
}