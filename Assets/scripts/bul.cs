using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bul : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
            //rb.AddForce(transform.forward * 200); 
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "bird")
        {          
            Destroy(col.gameObject);
            Destroy(this, 10.0f);
            Game1.sc += 1;
        }
    }
}
