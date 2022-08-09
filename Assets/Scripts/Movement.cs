using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrust = 100f;

    [SerializeField] float left = 100;
    [SerializeField] float right = 100;


    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }

    void processThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            // myRigidbody.RelativeForce(x , y ,z);
            myRigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * thrust); //the above code is same

        }



    }
    void processRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-right);
        }


    }

    void ApplyRotation(float rotateFrame)
    {
        myRigidbody.freezeRotation = true; // freezing the rotation so that we can manually change the physics
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateFrame);
        myRigidbody.freezeRotation = false; // after we are done then enabling the physics
    }
}
