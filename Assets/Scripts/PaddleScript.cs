﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    private float     yPos;
    public float      paddleSpeed = .05f;
    public float      topWall, bottomWall;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= paddleSpeed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += paddleSpeed;
            }
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }
}

