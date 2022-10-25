using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class serialTest : MonoBehaviour
{

    SerialPort stream = new SerialPort("COM8", 115200);
    public string strReceived;

    public string[] strData = new string[4];
    public string[] strData_received = new string[4];
    public float qw, qx, qy, qz;

    //public bool isFlat = true;
    //private Rigidbody rigid;

    void Start()
    {
        stream.Open(); //Open the Serial Stream.
        //rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        strReceived = stream.ReadLine(); //Read the information  

        strData = strReceived.Split(',');
        if (strData[0] != "" && strData[1] != "" && strData[2] != "" && strData[3] != "")//make sure data are reday
        {
            strData_received[0] = strData[0];
            strData_received[1] = strData[1];
            strData_received[2] = strData[2];
            strData_received[3] = strData[3];

            qw = float.Parse(strData_received[0]);
            qx = float.Parse(strData_received[1]);
            qy = float.Parse(strData_received[2]);
            qz = float.Parse(strData_received[3]);

            //transform.rotation = new Quaternion(-qy, -qz, qx, qw);
        }

        /*Vector3 tilt = Input.acceleration;
        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;

        rigid.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt);*/
    }
}