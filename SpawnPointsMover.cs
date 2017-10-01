using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsMover : MonoBehaviour
{


    // public GameObject PlayerCar;
    //public GameObject Track;

    public GameObject spawnpointmain;
    public GameObject[] spawnpoints = new GameObject[10];
    private float[] xValues = new float[6];
    private float[] xValuesRandomized = new float[6];

    public GameObject[] Traffic = new GameObject[7];

    // Use this for initialization
    void Start()
    {

        spawnpointmain = GameObject.FindGameObjectWithTag("SpawnPoints");
        
        spawnpoints[0] = GameObject.FindGameObjectWithTag("spawnPoint(0)");
        spawnpoints[1] = GameObject.FindGameObjectWithTag("spawnPoint(2)");
        spawnpoints[2] = GameObject.FindGameObjectWithTag("spawnPoint(3)");
        spawnpoints[3] = GameObject.FindGameObjectWithTag("spawnPoint(4)");
        spawnpoints[4] = GameObject.FindGameObjectWithTag("spawnPoint(5)");
        spawnpoints[5] = GameObject.FindGameObjectWithTag("spawnPoint(8)");
        spawnpoints[6] = GameObject.FindGameObjectWithTag("spawnPoint(10)");
        spawnpoints[7] = GameObject.FindGameObjectWithTag("spawnPoint(12)");
        spawnpoints[8] = GameObject.FindGameObjectWithTag("spawnPoint(13)");
        spawnpoints[9] = GameObject.FindGameObjectWithTag("spawnPoint(14)");

        xValues[0] = -2.97f;
        xValues[1] = -1.60f;
        xValues[2] = -0.55f;
        xValues[3] = 0.50f;
        xValues[4] = 21.5f;
        xValues[5] = 3.00f;

        //index = Random.Range(0, Traffic.Length);
        //Instantiate(Traffic[index], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    int func()
    {
        int i = Random.Range(0, xValues.Length);
        //Debug.Log("Random index" + i);
        if (xValues[i] == -99)
            return -99;
        else
            return i;

    }

    int k;
    public static int n1 = 1;
    private int index, index1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarCollider") && (n1 == 1))
        {
           // Debug.Log("hua bc enter n=" + n1);
            n1 = 0;
            //

            //
           // Debug.Log("hua bc change n=" + n1);
            spawnpointmain.transform.position = new Vector3(spawnpointmain.transform.position.x, spawnpointmain.transform.position.y + 13.68f, spawnpointmain.transform.position.z);
            spawnPointRandomiserfunc();

            for(int i=0;i<=9;i++)
            {
                index = Random.Range(0, Traffic.Length);
                Instantiate(Traffic[index], spawnpoints[i].transform.position, spawnpoints[i].transform.rotation);
            }
           

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarCollider"))
        {
            n1 = 1;
           // Debug.Log("hua bc exit n=" + n1);
            //
            
            //
        }
    }








    void spawnPointRandomiserfunc()
    {
        for (int i = 0; i< 3; i++)
             {

                 // choosing random x values
                 index = func();
                 while (index == -99)
                 {
                     index = func();
                 }
               //  Debug.Log("index=" + index);
                 float ind = xValues[index];  // keeping the xvalue at the index for interchanging later
                 xValues[index] = -99;

                 index1 = func();  // choosing random x values
                 while (index1 == -99)
                 {
                     index1 = func();

                 }
               //  Debug.Log("index1=" + index1);
               //  Debug.Log("-----------------------------------------------------------------------");
                 xValuesRandomized[index] = xValues[index1];
                 xValuesRandomized[index1] = ind;
                 xValues[index1] = -99;    //making used xvalues unusable
               }


                 spawnpoints[0].transform.position = new Vector3(xValuesRandomized[0], spawnpoints[0].transform.position.y, spawnpoints[0].transform.position.z);

                  spawnpoints[1].transform.position = new Vector3(xValuesRandomized[0], spawnpoints[1].transform.position.y, spawnpoints[1].transform.position.z);

                  spawnpoints[2].transform.position = new Vector3(xValuesRandomized[1], spawnpoints[2].transform.position.y, spawnpoints[2].transform.position.z);

                  spawnpoints[3].transform.position = new Vector3(xValuesRandomized[1], spawnpoints[3].transform.position.y, spawnpoints[3].transform.position.z);

                  spawnpoints[4].transform.position = new Vector3(xValuesRandomized[2], spawnpoints[4].transform.position.y, spawnpoints[4].transform.position.z);

                  spawnpoints[5].transform.position = new Vector3(xValuesRandomized[3], spawnpoints[5].transform.position.y, spawnpoints[5].transform.position.z);

                  spawnpoints[6].transform.position = new Vector3(xValuesRandomized[4], spawnpoints[6].transform.position.y, spawnpoints[6].transform.position.z);

                  spawnpoints[7].transform.position = new Vector3(xValuesRandomized[4], spawnpoints[7].transform.position.y, spawnpoints[7].transform.position.z);

                  spawnpoints[8].transform.position = new Vector3(xValuesRandomized[5], spawnpoints[8].transform.position.y, spawnpoints[8].transform.position.z);

                  spawnpoints[9].transform.position = new Vector3(xValuesRandomized[5], spawnpoints[9].transform.position.y, spawnpoints[9].transform.position.z);

              
              for(int i=0;i<6;i++)
              {
                  Debug.Log("Value in index" + i +"  "+ xValuesRandomized[i] + "\n");
              }  
    }
}