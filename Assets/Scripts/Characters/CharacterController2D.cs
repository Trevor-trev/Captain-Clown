using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	/*public Playermovement pmov;
	public Animator animator;
	public LedgeClimb ledgeClimb;
	public LayerMask whatIsGround;//-----------------------------A mask determining what is ground to the character

	public Transform groundCheck;//------------------------------A position marking where to check if the player is grounded

	float groundedRadius = .15f;//-------------------------------Radius of the overlap circle to determine if grounded
	public bool grounded;//--------------------------------------Whether or not the player is grounded


	private void LateUpdate()
	{
		#region CHECKING IF GROUNDED
		///////////////////////////////////CHECKINGING IF GROUNDED//////////////////////////////////////
		//bool wasGrounded = grounded;
		grounded = false;
		if (grounded == false)
			animator.SetBool("IsGrounded", false);
		//The player is grounded if a circlecast on the groundcheck position hits anything designated as ground		
		//I'll be honest with you, my pudgy brain still doesn't quite understand how this for loop works and I dont want to give any false info. But when (if) I know for sure what exactly it's doing I'll update this section
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				if (!pmov.jumpedFromPole || !ledgeClimb.ledgeHang)
				{
					grounded = true;
					animator.SetBool("IsGrounded", true);
				}
				//if (!wasGrounded)
				//OnLandEvent.Invoke();}
			}
			#endregion
		}
	}*/
}