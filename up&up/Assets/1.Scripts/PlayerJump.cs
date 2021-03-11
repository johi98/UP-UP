using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject player;
    public float jumpPower =20;
    public float distToGround = 0.6f;
    bool grounded = false;
    bool onEnemy = false;
    bool jumpT = false;
    Rigidbody rig;

    private void Start()
    {
        rig = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        Vector3 rayPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
        Debug.DrawRay(rayPosition, Vector3.down, Color.green, distToGround);
     
    }

    private void FixedUpdate()
    {
        if((grounded||onEnemy) && jumpT ==true )
        {
            rig.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
            jumpT = false;
         
        }

    }

    public void Jump()
    {
        jumpT = true;

    }

    private void CheckGround()
    {
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, distToGround))
        {
            grounded = true;
            return;
        }
        grounded = false;
    }


}
