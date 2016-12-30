using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    GameObject target;
    float viewAngle = 0.0f;

    // Use this for initialization
    void Start()
    {
        //target = transform;
        target = GameObject.Find("CodeGeneratedGrid");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0.0f, 0.0f, 0.0f));
        viewAngle = 100 * Time.deltaTime;
        transform.RotateAround(
            target.transform.position,
            Vector3.up,
            viewAngle);
    }
}
