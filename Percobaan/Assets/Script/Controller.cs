using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Move Component")]
    [SerializeField] int speed;

    private Rigidbody rigidBody;
    private Vector3 playerMovement;

    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Move();
    }

    public void Move()
    {
        rigidBody.velocity = new Vector3(playerMovement.x * speed, rigidBody.velocity.y, playerMovement.z * speed);
    }

    /*public bool isFlat = true;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rigid.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
    }*/
}
