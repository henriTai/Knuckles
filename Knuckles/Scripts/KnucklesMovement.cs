using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnucklesMovement: MonoBehaviour { // Liitä Knucklesiin

    public GameObject mainCamera; // Scripti laittaa gameObjectin liikkumaan kameraa päin
    public Rigidbody ukRB;
    public bool hasRb;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main.gameObject;
        ukRB = GetComponent<Rigidbody>();
        if (ukRB != null) // Jos Rigidbodya ei loydy, niin gameObjecti liikkuu translatella, AddForcen sijaan.
        {
            hasRb = true;
        }
        else hasRb = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (hasRb)
        {
            Vector3 dir = (mainCamera.transform.position - gameObject.transform.position).normalized;

            ukRB.AddForce(dir * 50, ForceMode.Acceleration);
        } else
        {
            Vector3 dir = (gameObject.transform.position - mainCamera.transform.position).normalized;

            Vector3 targetDir = mainCamera.transform.position - transform.position;
            float step = 50 * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.Translate(Vector3.forward);
        }
    }
}
