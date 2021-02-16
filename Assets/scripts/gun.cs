using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {
    float y = 90f;
    float z = 0f;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(Vector3.up * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(Vector3.down * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Rotate(Vector3.back * 10);
        }
        if (Input.GetKey(KeyCode.V))
        {
            rb.transform.Rotate(Vector3.forward * 10);
        }
    }
}
