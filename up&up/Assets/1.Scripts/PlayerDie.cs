using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
   
    bool isDie = false;

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(isDie == false)
        {
            if (gameObject.transform.eulerAngles.x < -50 ||
                (gameObject.transform.eulerAngles.x<310 && gameObject.transform.eulerAngles.x > 50) ||
                (gameObject.transform.eulerAngles.z  < 310 && gameObject.transform.eulerAngles.z > 50) ||
                gameObject.transform.eulerAngles.z < -50)
             {
                Debug.Log(gameObject.transform.eulerAngles);
                Debug.Log("Die");

                isDie = true;
             }
        }
           

        
        
    }
}
