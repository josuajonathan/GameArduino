using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Move Component")]
    [SerializeField] int speed;

    [Header("Arduino")]
    SerialPort stream = new SerialPort("COM8", 115200);
    public string strReceived;

    public string[] strData = new string[4];
    public string[] strData_received = new string[4];

    public float arQ, arX, arY, arZ;

    private Rigidbody rigidBody;
    private Vector3 playerMovement;

    [Header("Player")]
    private Transform spawnPoint;

    void Start()
    {
        stream.Open();
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        spawnPoint = this.gameObject.transform;
    }

    void Update()
    {
        GetArduinoData();
        playerMovement.x = arX;
        playerMovement.z = arZ;
        //  playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Move();
    }

    public void GetArduinoData()
    {
        strReceived = stream.ReadLine();

        strData = strReceived.Split(',');
        if (strData[0] != "" && strData[1] != "" && strData[2] != "" && strData[3] != "")//make sure data are reday
        {
            strData_received[0] = strData[0];
            strData_received[1] = strData[1];
            strData_received[2] = strData[2];
            strData_received[3] = strData[3];

            arQ = float.Parse(strData_received[0]);
            arX = float.Parse(strData_received[1]);
            arY = float.Parse(strData_received[2]);
            arZ = float.Parse(strData_received[3]);
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Maze")
            transform.position = spawnPoint.position;
    }
}
