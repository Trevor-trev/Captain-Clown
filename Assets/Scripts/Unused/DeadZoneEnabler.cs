using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeadZoneEnabler : MonoBehaviour
{
    public RecenterTriggerGround recenterTrigger;
    public CameraMovement camMovement;
    public GroundCheck groundCheck;
    public CinemachineVirtualCamera vcam;
    Transform character;
    public Transform camController;

    private void Start()
    {
        character = GameObject.Find("Keen").transform;
        vcam.m_Follow = character;
    }

    private void Update()
    {


        if (Input.GetButton("LookUp") || Input.GetButton("LookDown"))
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 0;

        if (!(Input.GetButton("LookUp") || Input.GetButton("LookDown")))   
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = .44f;

       // if (camMovement.lookUpRecenter || recenterTrigger.setDeadZone)
           // vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 0;

        if (!groundCheck.grounded)
        {
            vcam.m_Follow = character;
        }
       
        if (groundCheck.grounded)
            vcam.m_Follow = camController;
    }
}
