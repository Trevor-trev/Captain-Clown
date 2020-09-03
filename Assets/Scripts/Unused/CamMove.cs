using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamMove : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform camTransform;
    public float camSpeed;
    Vector3 camPos;
    Transform character;
        


    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        camTransform = vcam.transform;
        camPos = camTransform.position;
        character = GameObject.Find("Keen").transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if (Input.GetButton("LookDown"))
        {
            vcam.m_Follow = null;
            camPos.y = transform.position.y;
            camPos.x = transform.position.x;
            camPos.y -= Time.deltaTime * camSpeed;
            transform.position = camPos;
        }

        if (Input.GetButton("LookUp"))
        {
            vcam.m_Follow = null;
            camPos.y = transform.position.y;
            camPos.x = transform.position.x;
            camPos.y += Time.deltaTime * camSpeed;
            transform.position = camPos;
        }

        if (!(Input.GetButton("LookUp") || Input.GetButton("LookDown")))
        {
            vcam.m_Follow = character;
            camPos.x = transform.position.x;
            camPos.y = transform.position.y;
            transform.position = camPos;
        }

    }
}
