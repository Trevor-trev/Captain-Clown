using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamBoundarySwitcher : MonoBehaviour
{
    public DoorwayCheck doorwayCheck;
    public CinemachineConfiner camConfiner;
    public InteriorCheck interiorCheck;

    public CompositeCollider2D outsideCamBounds;
    public CompositeCollider2D house1CamBounds;
    void Start()
    {       
        camConfiner = GetComponent <CinemachineConfiner>();
        camConfiner.m_BoundingShape2D = outsideCamBounds;
    }

    void Update()
    {
        if (interiorCheck.isOutside)
            camConfiner.m_BoundingShape2D = outsideCamBounds;

        if (interiorCheck.inHouse1)
            camConfiner.m_BoundingShape2D = house1CamBounds;
    }
}
