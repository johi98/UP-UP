using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInit : MonoBehaviour
{
    public GameObject thisCube;
    public GameObject initCube;
    CubeMove CM;
    bool isInit;
    private void Awake()
    {
        CM = thisCube.GetComponent<CubeMove>();
        isInit = false;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"&& isInit ==false)
        {
            CM.playerOn = true;
            float xRange = Random.Range(-8,8);
            float zRange = Random.Range(7, 12);
            Instantiate(initCube, new Vector3( xRange, GameManager.high +2, zRange), Quaternion.identity);

            GameManager.high += 1;

            isInit = true;

        }
        
    }
}
