using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	public Playermovement pmov;
	public Animator animator;
	public LedgeClimb ledgeClimb;
	public SlopeCheck slopeCheck;
	public PoleClimbController poleClimb;
	public MovingPlatformCheck movPlatCheck;

	public LayerMask whatIsGround;//-----------------------------A layermask that lets you determine what layers are considered ground to the character
	public LayerMask whatIsCeiling;//----------------------------A layermask that lets you determine what layers are considered ceiling to the character

	public Transform groundCheck;//------------------------------A position marking where to check if the player is grounded

	public float groundedRadius = .15f;//------------------------Radius of the overlap circle to determine if grounded
	public bool grounded;//--------------------------------------Whether or not the player is grounded

    private void Update()
    {
		if (!ledgeClimb.isTouchingWall && (slopeCheck.onSlope || movPlatCheck.onMovingPlatform))
			groundedRadius = .5f;

		if (ledgeClimb.isTouchingWall)//-----------------------------------------------If the wallcheck raycast detects a wall
			groundedRadius = .1f;//-----------------------------------------slightly decrease the grounded radius to make sure the character isn't declared as grounded when jumping next to a wall

		if (!ledgeClimb.isTouchingWall && !slopeCheck.onSlope && !movPlatCheck.onMovingPlatform)//-----------------------------------------If the wallcheck raycast doesn't detect a wall
			groundedRadius = .15f;//----------------------------------------Keep the grounded radius at this default size to make sure the character doesn't randomly get declared as not grounded while running
	}
    private void LateUpdate()
	{
		#region CHECKING IF GROUNDED
		///////////////////////////////////CHECKINGING IF GROUNDED//////////////////////////////////////
		grounded = false;
		if (grounded == false)
			animator.SetBool("IsGrounded", false);
		//The player is grounded if a circlecast on the groundcheck position hits anything designated as ground		
		//I'll be honest with you, my pudgy brain still doesn't quite understand how this for loop works and I dont want to give any false info. But when I know for sure what exactly it's doing I'll update this section
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				if (!(poleClimb.jumpedFromPole || ledgeClimb.ledgeHang))
				{
					grounded = true;
					animator.SetBool("IsGrounded", true);
				}
			}
			#endregion
		}
	}
}
