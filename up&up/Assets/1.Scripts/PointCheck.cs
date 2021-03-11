using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointCheck : MonoBehaviour
{
    bool pointCheck = false;
    Vector3 playerPosition;
    Vector3 EnemyPosition;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"&&pointCheck == false)
        {
            float distanceCheck;

            playerPosition = new Vector3(collision.gameObject.transform.position.x,0, collision.gameObject.transform.position.z);
            EnemyPosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);

            distanceCheck = Vector3.Distance(playerPosition, EnemyPosition);



            if(distanceCheck<0.1)
            {
                GameManager.score += 100;
                Debug.Log("Perfact");
            }
            else if(distanceCheck <0.3)
            {
                GameManager.score += 50;
                Debug.Log("Good");
            }
            else if(distanceCheck < 0.5)
            {
                GameManager.score += 30;
                Debug.Log("Nice");
            }
            else
            {
                GameManager.score += 10;
                Debug.Log("Bad");
            }

          

            pointCheck = true;
            
        }
    }
}
