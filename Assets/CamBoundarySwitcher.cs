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
    public CompositeCollider2D slugTempleCamBounds;
    public CompositeCollider2D jailCellCamBounds;
    void Start()
    {       
        camConfiner = GetComponent <CinemachineConfiner>();
        camConfiner.m_BoundingShape2D = outsideCamBounds;
    }
    
    void FixedUpdate()
    {
        if (interiorCheck.isOutside)
            camConfiner.m_BoundingShape2D = outsideCamBounds;

        if (interiorCheck.inHouse1)
            camConfiner.m_BoundingShape2D = house1CamBounds;

        if (interiorCheck.inHouse2)
            camConfiner.m_BoundingShape2D = house2CamBounds;

        if (interiorCheck.inHouse3)
            camConfiner.m_BoundingShape2D = house3CamBounds;

        if (interiorCheck.inSlugTemple)
            camConfiner.m_BoundingShape2D = slugTempleCamBounds;

        if (interiorCheck.inJailCell)
            camConfiner.m_BoundingShape2D = jailCellCamBounds;
    }
}
