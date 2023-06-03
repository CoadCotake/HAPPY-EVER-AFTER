using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_spawnblock : MonoBehaviour {
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;
    private GameObject a;
    GameObject[] b = new GameObject[100];
    public GameObject player;
    private int randomzz;
    void Start()
    { 
        
        StartCoroutine("ObjectRandomGenerator");
    }
    private void Update()
    {
        if (player.transform.position.x > 5)
        {
            gameObject.SetActive(true);
        }

    }

    IEnumerator ObjectRandomGenerator()
    {
        GameObject[] tempGO = new GameObject[7];

        tempGO[0] = object1;
        tempGO[1] = object2;
        tempGO[2] = object3;
        tempGO[3] = object4;
        tempGO[4] = object5;
        tempGO[5] = object6;
        tempGO[6] = object7;

        while (true)
        {
            int i = 0;
            int randomx = Random.Range(-5, 5);
            float randomxx = randomx;
            int randomxblock = Random.Range(0, 7);
            int randomz = Random.Range(0, 4);
            
            if (randomz == 0) { randomzz = 90; }
            if (randomxblock == 0 ||randomxblock==4) { randomxx -= 0.5f; }
            a=Instantiate(tempGO[randomxblock], new Vector3(11, 13, 0f), Quaternion.identity);
            yield return new WaitForSeconds(3.5f);
            Destroy(a);
            b[i]=Instantiate(tempGO[randomxblock], new Vector3(randomxx, 15.7f, randomzz), Quaternion.identity);
            i++;
            if (Input.GetKeyDown(KeyCode.R))
            {
                for (int j = 0; j < b.Length; j++)
                {
                    Destroy(b[i]);
                }
            }
        }
    }
}
