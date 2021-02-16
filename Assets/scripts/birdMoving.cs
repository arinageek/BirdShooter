using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMoving : MonoBehaviour {
    public Transform target;
    public bool reversedDirection;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = transform.position - target.position;

        Quaternion deltaRotation = Quaternion.AngleAxis(Time.deltaTime * 10.0f * (reversedDirection ? -1.0f : 1.0f), Vector3.up);
        direction = deltaRotation * direction;

        transform.position = target.position + direction;

        transform.forward = Vector3.Cross(Vector3.up, direction) * (reversedDirection ? -1.0f : 1.0f);
	}
}
