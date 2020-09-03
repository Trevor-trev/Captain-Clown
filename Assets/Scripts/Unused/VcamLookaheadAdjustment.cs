using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VcamLookaheadAdjustment : MonoBehaviour
{
    public Playermovement pmov;
    public GroundCheck groundCheck;
    public CinemachineVirtualCamera vcam;
    //public float lookAheadTime;
   // public float lookAheadSmoothing;


    private void Awake()
    {
        //lookAheadTime = ;
        //lookAheadSmoothing = 
    }
    private void Update()
    {

        if (Input.GetButton("LookUp") || Input.GetButton("LookDown"))
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = 0;
        }
        if (!(Input.GetButton("LookUp") || Input.GetButton("LookDown")))
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = .78f;

        }
        /*if (!groundCheck.grounded)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadTime = .3f;
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadSmoothing = 10f;
        }
        
        if (groundCheck.grounded)
        {
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadTime = .0f;
            vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_LookaheadSmoothing = 3f;
        }*/
    }
}
