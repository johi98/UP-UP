using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject player;
    public float jumpPower =20;
    public float distToGround = 0.6f;
    bool grounded = false;
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
    }

    private void FixedUpdate()
    {
        if(grounded == true && jumpT ==true )
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
