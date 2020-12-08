using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamBoundarySwitcher : MonoBehaviour
{
    public CinemachineConfiner camConfiner;
    public InteriorCheck interiorCheck;
    
    public CompositeCollider2D outsideCamBounds;
    public CompositeCollider2D house1CamBounds;
    public CompositeCollider2D house2CamBounds;
    public CompositeCollider2D house3CamBounds;
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

        if (interiorCheck.inHouse2)
            camConfiner.m_BoundingShape2D = house2CamBounds;

        if (interiorCheck.inHouse3)
            camConfiner.m_BoundingShape2D = house3CamBounds;
    }
}
