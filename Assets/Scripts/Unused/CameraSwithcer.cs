using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwithcer : MonoBehaviour
{
    public CinemachineMixingCamera mixingCam;
    public GroundCheck groundCheck;
    public Playermovement pmov;

    public void Awake()
    {
        mixingCam = GetComponent<CinemachineMixingCamera>();
    }
    void Update()
    {
        if (groundCheck.grounded && !pmov.pogo)
        {
            mixingCam.m_Weight0 = 1;
            mixingCam.m_Weight1 = 0;
        }
        if (!groundCheck.grounded)
        {
            mixingCam.m_Weight0 = 0;
            mixingCam.m_Weight1 = 1;
        }
    }
}
