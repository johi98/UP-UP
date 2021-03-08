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
            
            Instantiate(initCube, new Vector3( -4, GameManager.high , 11), Quaternion.identity);

            GameManager.high += 1;

            isInit = true;

        }
        
    }
}
