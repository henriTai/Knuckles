﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds1 : MonoBehaviour {

    public float speed;
	
	void Update () {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
	}
}
