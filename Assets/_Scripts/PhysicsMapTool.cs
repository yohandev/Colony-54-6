﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMapTool : MonoBehaviour
{
    public GameObject[] rocks;
    public GameObject[] trees;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * 5, Input.GetAxis("Mouse X") * 5, 0);

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Up"), Input.GetAxis("Vertical")), Space.Self);
    
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject g = Instantiate(rocks[(int)Random.Range(0, rocks.Length - 1)], this.transform.position, Quaternion.identity);

            PhysicsDrop p = g.AddComponent<PhysicsDrop>();

            p.deleteRigidbody = true;
            p.sproutMode = false;
            p.minSize = 0.9f;
            p.maxSize = 1.2f;

            Rigidbody rb = g.AddComponent<Rigidbody>();

            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}