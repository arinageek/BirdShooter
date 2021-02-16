using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;
using Valve.VR.InteractionSystem;

public class Game1 : MonoBehaviour {
    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;
    public GameObject bul;
    public GameObject BulletEmitter;
    GameObject newBird;
    public Animator animator;
    private float t = 0.0f;
    public float interpolationPeriod = 4f;
    public static int sc = 0;
    TextMesh textObject;
    public Hand hand;

    // Use this for initialization
    void Start () {
        textObject = GameObject.Find("Score").GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        textObject.text = sc.ToString();
        t += Time.deltaTime;
        if (t >= interpolationPeriod)
        {
            t = 0.0f;
            int r = Random.Range(0, 3);

            Vector3 spawnPoint = new Vector3();
            spawnPoint.x = Random.Range(5.0f, 20.0f) * (Random.Range(0.0f, 1.0f) > 0.5 ? 1.0f : -1.0f);
            spawnPoint.y = Random.Range(0.4f, 5.0f);
            spawnPoint.z = Random.Range(5.0f, 20.0f) * (Random.Range(0.0f, 1.0f) > 0.5 ? 1.0f : -1.0f);
            if (r == 0)
            {
                newBird = Instantiate(bird1, spawnPoint, Quaternion.Euler(0f, 90f, 0f));
            }else if (r == 1)
            {
                newBird = Instantiate(bird2, spawnPoint, Quaternion.Euler(0f, 90f, 0f));
            }
            else
            {
                newBird = Instantiate(bird3, spawnPoint, Quaternion.Euler(0f, 90f, 0f));
            }
            
            newBird.GetComponent<birdMoving>().target = transform;
            newBird.GetComponent<birdMoving>().reversedDirection = Random.Range(0.0f, 1.0f) > 0.5;
        }
        Debug.Log(SteamVR_Input.__actions_default_in_GrabGrip);
        if (Input.GetKeyDown(KeyCode.Space) || SteamVR_Input.__actions_default_in_GrabPinch.GetStateDown(hand.handType)) {
            animator.SetTrigger("shoot");
            GameObject bullet = Instantiate(bul, BulletEmitter.transform.position, BulletEmitter.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 2000.0f);
        }
        
    }
}
