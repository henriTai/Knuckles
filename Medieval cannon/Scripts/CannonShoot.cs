using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public GameObject barrel;
    public GameObject spawnPoint;
    public GameObject cannonBall;
    public GameObject platform;
    public float force;
    public float rotationSpeed;
    public float barrelSpeed;
    public float maxBarrelTilt;
    public float minBarrelTilt;
    private float currentTilt;
    public float shotInterval;
    private float untilNextShot;
    private float currentDirection; //kierto y-akselin ympäri

	void Start () {
        currentTilt = 0f;
        untilNextShot = 0f;
        currentDirection = 0f;
	}

	void Update () {

        if (currentDirection >= 360f)
        {
            currentDirection -= 360f;
        } else if (currentDirection < 0f)
        {
            currentDirection = 360f - currentDirection;
        }

        if (untilNextShot >= 0)
        {
            untilNextShot -= Time.deltaTime;
        }
		
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //käänny oikeaan
            float rot = rotationSpeed * Time.deltaTime;
            currentDirection -= rot;
            platform.transform.Rotate(0f, -rot, 0f);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float rot = rotationSpeed * Time.deltaTime;
            currentDirection += rot;
            platform.transform.Rotate(0f, rot, 0f);
            //käänny vasempaan
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (currentTilt < maxBarrelTilt)
            {
                float rot = barrelSpeed * Time.deltaTime;
                currentTilt += rot;
                barrel.transform.Rotate(Vector3.right * rot);
            }
            //tykki ylös
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentTilt > minBarrelTilt)
            {
                float rot = barrelSpeed * Time.deltaTime;
                currentTilt -= rot;
                barrel.transform.Rotate(Vector3.left * rot);
            }
            //tykki alas
        }
        if (Input.GetKeyDown(KeyCode.Space) && untilNextShot<= 0)
        {
            GameObject cb = Instantiate(cannonBall, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Rigidbody rb = cb.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.transform.forward * force, ForceMode.Impulse);
            untilNextShot = 1f;
            Debug.Log(currentDirection);
        }

	}
}
