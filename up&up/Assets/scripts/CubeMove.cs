using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    Transform playerTr;
    public GameObject player;
    private Vector3 MPosition;
    private Vector3 termP;
    public bool playerOn;



    private void Start()
    {
        playerTr = player.GetComponent<Transform>();

        MPosition = playerTr.position - transform.position;
        termP = MPosition;
        MPosition = new Vector3(termP.x, transform.position.y, termP.z);
        playerOn = false;
}

    // Update is called once per frame
    void Update()
    {
        CMove();
    }

    public void CMove()
    {
        if (playerOn == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, MPosition, 3 * Time.deltaTime);
        }

    }


}
