using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class Playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GroundCheck groundCheck;
    public LedgeClimb ledgeClimb;
    public Pole pole;
    public NeuralGun neuralGun;
    public RecenterTriggerGround recenterTrigger;
    public SlopeCheck slopeCheck;
    public bool touchingCeiling;

    //MOVEMENT//////
    public bool facingRight;//-------------------Whether or not the character is facing right
    public bool facingLeft;//--------------------Whether or not the character is facing left 
   
    public float xdirection = 0f;//--------------Direction check used for animation and pogo stick acceleration
    public float xdirForTransitionToPogo = 0f;//Direction check used when activating the pogo stick while running      
    public float horizontalMove = 0f;//----------Velocity variable used for non pogo stick horizontal movement
    public float topSpeedR = 37.5f;//------------Set speed limit for horizontal movement to the right
    public float topSpeedL = -37.5f;//-----------Set speed limit for horizontal movement to the left

    //Pole Climbing//  
    public bool jumpedFromPole;//----------------Whether or not the character jumped off of a pole
    public bool onPole = false;//----------------Determine whether or not the character is on a pole
    
    public float climbingTopSpeed = 1.75f;//-----Set speed limit for vertical movement while on a pole
    public float verticalMove = 0f;//------------Velocity variable used for vertical movement while climbing a pole
    
    //JUMPING//
    public bool isJumping;//---------------------Whether or not the character is jumping
    public bool rising;//------------------------Whether or not the character is moving upward 
    public bool falling;
   
    public float jumpForce;//--------------------The amount of vertical force applied when the player presses the jump button   
    public float jumpTimer;//--------------------Counts down to 0, at which point the player can no longer jump
    private float jumpTimerStart = 0.31f;//------The starting point for the jumpTimeCounter


    //Pogo Stick//
    public bool pogo = false;//------------------Determine whether or not the character is on the pogo stick
    
    private float pogoTopSpeedR = 6.65f;//-------Set speed limit for horizontal movement to the right while on pogo stick
    private float pogoTopSpeedL = -6.65f;//------Set speed limit for horizontal movement to the left while on pogo stick
    public float bounceForce = 11f;//------------The amount of vertical force applied when the pogo stick bounces off of a surface    
    public float acceleration = .25f;//----------Acceleration variable used for horizontal movement while on pogo stick or transitioning from hanging to climbing a ledge
    public float pogoSpeed = 0;//----------------Velocity variable used for pogo stick horizontal movement
    public float impossiblePogoTimer;//----------A timer that determines the button press timing required to execute the impossible pogo trick
    public float impPogoTimerStart = .25f;//-----The starting point for the impossible pogo timer.
    
    //LOOKING//
    public bool lookDown = false;//--------------Whether or not the character is looking down
    public bool lookup = false;//----------------Whether or not the character is looking up
    public bool uncrouching;//-------------------Whether or not the character is looking back up from the crouching(lookingdown) position
    
    public const float ceilingRadius = .2f; //---Radius of the overlap circle to determine if the player can stand up
   
    public Transform ceilingCheck;//-------------A position marking where to check for ceilings
    public Collider2D lookDownDisableCollider;//-A collider that will be disabled when looking down




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("FacingLeft", true);//Make sure the animator registers the player as facing left when the game starts
        facingLeft = true;//Make sure the character is facing left when the game starts
    }

    #region COROUTINES
    #region UNCROUCHING COROUTINE
    IEnumerator UnCrouching()
    {
        if (!onPole){//------------------------------If the character is not on a pole        
            uncrouching = true;//--------------------Set the uncrouching variable to true
            topSpeedL = 0f;//------------------------Prevent the character from moving to the left
            topSpeedR = 0f;//------------------------Prevent the character from moving to the right
            animator.SetBool("UnCrouching", true);//-Play the uncrouching animation
            yield return new WaitForSeconds(.08f);//-Wait until the uncrouching animation finishes
            animator.SetBool("UnCrouching", false);//Prevent the uncrouching parameter from always being true
            lookDown = false;//----------------------Set the looking down variable back to false
            topSpeedL = -37.5f;//--------------------Allow the character to move to the left
            topSpeedR = 37.5f;//---------------------Allow the character to move to the right
            uncrouching = false;}//------------------Set the uncroucing variable to false
    }
    #endregion
    #endregion
    void Update()
    {
        #region JUMP CONTROLLER
        ///////////////////////////////////JUMPING//////////////////////////////////////


        if ((groundCheck.grounded || recenterTrigger.touchingDroppablePlatform) && (lookDown || lookup)){//If the chracter is on the ground or a droppable platform and is looking up or down            
            jumpForce = 0;//---------------------------------------------------Prevent the character from jumping
            isJumping = false;}//-----------------------------------------------Prevent isJumping from being true, this prevents the character from slowly falling if the jump button is held when dropping through a platform        
        else if (groundCheck.grounded && !lookDown && !lookup)//---------------If the character is grounded, not looking up, and not looking down
            jumpForce = 12f;//-------------------------------------------------Allow the character to jump

        if (!pogo && !ledgeClimb.ledgeClimb)//---------------------------------If the character is not on the pogo stick and not climbing a ledge
        {
            if (!neuralGun.shoot && (groundCheck.grounded == true) && Input.GetButtonDown("Jump")){//When the character is grounded and the player presses the jump button            
                rb.velocity = Vector2.up * jumpForce;//------------------------Create vertical force
                isJumping = true;//--------------------------------------------Set the isJumping variable to true
                jumpTimer = jumpTimerStart;}//----------------------------------Make sure the counter resets when the character is no longer airborne
            
            if (Input.GetButton("Jump") && isJumping == true){//----------------If the jump button is held down and the isJumping variable is true            
                if (jumpTimer > 0){//-------------------------------------------If the counter is greater than zero                
                    rb.velocity = Vector2.up * jumpForce;//---------------------Allow the character to jump
                    jumpTimer -= Time.deltaTime;}}//----------------------------Make the timer starts counting down                                
        }
        if (Input.GetButtonUp("Jump") || rb.velocity.y < 0 || touchingCeiling)//-----------------------------------When the player releases the jump button
            isJumping = false;//-------------------------------------------Set the isJumping variable to false 
        #endregion

        #region LOOKING DOWN CONTROLLER
        ///////////////////////////////////LOOKING DOWN//////////////////////////////////////      
        if (!onPole)
        {//-------------------------------------------------------------------------------------------------If the character is not on a pole                  
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundCheck.whatIsCeiling))//-----------If there is an object directly above the characters head
                touchingCeiling = true;
            else if (!Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundCheck.whatIsCeiling))
                touchingCeiling = false;
           
            if (lookDown && groundCheck.grounded && touchingCeiling)
                if (lookDownDisableCollider != null)//-------------------------------------------------------------------If there is one or more colliders set to disable when crouching
                        lookDownDisableCollider.enabled = false;}//----------------------------------------------------------Disable the collider(s)  

            if ((!lookDown && !ledgeClimb.ledgeClimb && !touchingCeiling) || !groundCheck.grounded)//If the chracter is not looking down and there is no cieling above the character's head
                if (lookDownDisableCollider != null)//-------------------------------------------------------------------If there is one or more colliders set to disable when crouching
                    lookDownDisableCollider.enabled = true;//------------------------------------------------------------Enable the collider when not crouching
             
            if (groundCheck.grounded && lookDown){//---------------------------------------------------------------------If the character is looking down             
                topSpeedL = 0;//-----------------------------------------------------------------------------------------Prevent the character from moving to the left
                topSpeedR = 0;}//----------------------------------------------------------------------------------------Prevent the character from moving to the right        
        #endregion

#region POLE CLIMB CONTROLLER
        ///////////////////////////////////Pole Climbing//////////////////////////////////////   
        
        if (jumpedFromPole)//---------------------------------------------If the character has jumped off a pole
            onPole = false;//---------------------------------------------Prevent the character from immediately grabbing the pole if the player is holding the up button
       
        if (onPole && (lookDown || lookup) && neuralGun.shoot)//----------If the character is on a pole, and the player is pressing the look up or look down buttons while shooting
            verticalMove = 0;//-------------------------------------------Prevent the character from moving up or down 
        else if (!neuralGun.shoot)//--------------------------------------Otherwise, if the character is not shooting
            verticalMove = Input.GetAxisRaw("Vertical") * climbingTopSpeed;//Allow the character to move up and down poles        

        if (verticalMove > 0)//------------------------------------------When the character is moving up the pole
            climbingTopSpeed = 2.65f;//----------------------------------Set the speed a little slower
        else if (verticalMove < 0)//-------------------------------------When the character is moving down the pole
            climbingTopSpeed = 7.5f;//-----------------------------------Set the speed a little faster      

        if (onPole)//----------------------------------------------------If the character is on a pole 
        {
            horizontalMove = 0;//----------------------------------------Prevent the character from moving horizontally
            transform.position = new Vector2(GameObject.FindWithTag("ClosestPole").transform.position.x, transform.position.y);//Align character sprite with the closest pole

            if ((pole.makeshiftGrounded && pole.makeshiftGrounded2) && xdirection != 0)//If the character's feet are touching the ground while on a pole and the player presses the left or right buttons
                onPole = false;//--------------------------------------------------------Allow the character to get off the pole and walk away

            animator.SetBool("IsOnPole", true);//----------------------------------------Play the idle pole animation
            rb.gravityScale = 0;//-------------------------------------------------------Set gravity to zero to prevent the character from sliding down the pole
            jumpForce = 10f;//-----------------------------------------------------------Decrease the jump force
            rb.velocity = new Vector2(0, verticalMove);//--------------------------------Only allow the character to move vertically
            
            if (Input.GetButtonDown("Jump"))//-------------------------------------------If the player presses the jump button
            {
                horizontalMove = 0;//----------------------------------------------------Prevent the character from moving forward without player input
                rb.velocity = Vector2.up * jumpForce;//----------------------------------Allow for a seperate jump height when jumping off of a pole
                jumpedFromPole = true;//-------------------------------------------------Recognize that the player has jumped off a pole
            }
        }
        else if (!onPole && !ledgeClimb.ledgeClimb && !slopeCheck.onSlope){//-----------------------------------When the character is no longer on a pole
            animator.SetBool("IsOnPole", false);//---------------------------------------Make sure to stop playing any pole climbing animations
            rb.gravityScale = 3.5f;//----------------------------------------------------Set gravity back to it's default value
            jumpForce = 12f;}//----------------------------------------------------------Set the jump force back to it's default value
       

        if (rb.velocity.y <= 0)//--------------------------------------------------------When the character is no longer jumping upward
            jumpedFromPole = false;//----------------------------------------------------Allow the character to once again grab the pole

        #endregion

#region POGO STICK CONTROLLER    

        ///////////////////////////////////POGO STICK//////////////////////////////////////        
        
        
        if (!ledgeClimb.ledgeHang && !ledgeClimb.ledgeClimb && !onPole && Input.GetButtonDown("Pogo"))//If the character is not on a pole and the player presses the pogo button  
            pogo = !pogo;//---------------------------------------------Activate and deactivate the pogo stick

        if (!pogo){//----------------------------------------------------If the character is not on the pogo stick
            impossiblePogoTimer = impPogoTimerStart;
            xdirForTransitionToPogo = Input.GetAxisRaw("Horizontal");}//-Set an independent horizontal variable for use with activating the pogo stick

        if (pogo)//-----------------------------------------------------If the character is on the pogo stick
        {
            if (xdirForTransitionToPogo != 0)//-------------------------If the character is moving when the pogo stick is activated
                acceleration = 600;//----------------------------------Increase acceleration to keep the horizontal velocity constant
            else//------------------------------------------------------If the character is not moving when the pogo stick is activated
                acceleration = 9.75f;//-----------------------------------Create slow acceleration

            pogoSpeed += acceleration * xdirection * Time.deltaTime;//--accelerate the character in the appropriate direction

            jumpTimer = 0;//--------------------------------------------Set the jump timer equal to zero

            rb.gravityScale = 3f;//-------------------------------------Set a specific gravity scale for the pogo stick

            rb.velocity = new Vector2(pogoSpeed, rb.velocity.y);//------Move the character according to the pogoSpeed variable            

            xdirForTransitionToPogo = 0;//------------------------------Reset this variable after it is used

            if (groundCheck.grounded)//---------------------------------When the pogo stick hits the ground
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);//Create a vertical force to bouce the character upward

            if (Input.GetButton("Jump")){//-----------------------------If the player presses or holds the jump button while the character is on the pogo stick
                if (impossiblePogoTimer <= 0)//-------------------------If the impossible pogo trick timer is not greater than zero
                    bounceForce = 22.5f;}//-----------------------------Increase the bounce force 
            else//------------------------------------------------------If the player is not pressing the jump button while on the pogo stick
                bounceForce = 12.5f;//----------------------------------Set the bounce force to default value

            if (pogoSpeed > pogoTopSpeedR)//----------------------------If the horizontal speed to the right is about to go over the speed limit
                pogoSpeed = pogoTopSpeedR;//----------------------------Keep the speed at the limit

            if (pogoSpeed < pogoTopSpeedL)//----------------------------If the horizontal speed to the left is about to go over the speed limit
                pogoSpeed = pogoTopSpeedL;//----------------------------Keep the speed at the limit

            horizontalMove = pogoSpeed * 5.64f;//-----------------------Maintain horizontal speed when transitioning off the pogo stick
        }
        #endregion

#region ANIMATION CONTROLLER
        ///////////////////////////////////ANIMATION//////////////////////////////////////

#region RUNNING ANIMATION
        ///////////////////RUNNING ANIMATION///////////////////

        if (!ledgeClimb.ledgeClimb)//--------------------------------------------------If the character is not hanging onto or climbing a ledge
            xdirection = Input.GetAxisRaw("Horizontal");//-----------------------------Check which direction input is being pressed
        else if (ledgeClimb.ledgeClimb)//----------------------------------------------Otherwise if the character is climbing a ledge
            xdirection = 0;//----------------------------------------------------------Dont acknowledge any horizontal input

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));//------------------------Set the speed parameter for animations to be equal to the absolute value of the character's horizontal velocity

        if (!ledgeClimb.isTouchingWall && groundCheck.grounded && horizontalMove != 0)//If the chaaracter is not touching a wall, is grounded, and is moving horizontally
            animator.SetBool("IsRunning", true);//-------------------------------------Allow the running animation to play
        else if (ledgeClimb.isTouchingWall || horizontalMove == 0)//-------------------If the character is touching a wall or not moving horizontally
            animator.SetBool("IsRunning", false);//------------------------------------Prevent the running animation from playing

        if (!pogo && !ledgeClimb.ledgeHang && !neuralGun.shoot && !ledgeClimb.ledgeDetected)//If the character is not on the pogo stick, not hanging from a ledge, not shooting, and there is no ledge detected
        {
            if (xdirection > 0){//-----------------------------------------------------If the the player presses the right button      
                facingRight = true;//--------------------------------------------------The character is facing right
                facingLeft = false;//--------------------------------------------------The character is not facing left
                animator.SetBool("FacingRight", true);//-------------------------------Only play right facing animations
                animator.SetBool("FacingLeft", false);}//------------------------------Do not play left facing animations

            if (xdirection < 0){//-----------------------------------------------------If the player presses the left button
                facingRight = false;//-------------------------------------------------The character is not facing right
                facingLeft = true;//---------------------------------------------------The character is facing left
                animator.SetBool("FacingLeft", true);//--------------------------------Only play left facing animations
                animator.SetBool("FacingRight", false);}//-----------------------------Do not play right facing animations
        }

        if (pogo)//--------------------------------------------------------------------If the character is on the pogo stick
        {
            if (pogoSpeed > 0)//-------------------------------------------------------If the character is moving to the right 
            {
                facingRight = true;//--------------------------------------------------The character is facing right
                facingLeft = false;//--------------------------------------------------The character is not facing left
                animator.SetBool("FacingRight", true);//-------------------------------Only play right facing animations
                animator.SetBool("FacingLeft", false);//-------------------------------Do not play the left facing animations
            }

            if (pogoSpeed < 0)//-------------------------------------------------------If the character is moving to the left
            {       
                facingRight = false;//-------------------------------------------------The character is not facing right
                facingLeft = true;//---------------------------------------------------The character is facing left
                animator.SetBool("FacingLeft", true);//--------------------------------Only play left facing animations
                animator.SetBool("FacingRight", false);//------------------------------Do not play right facing animations
            }
        }
        #endregion

#region POGO ANIMATION
        ///////////////////POGO ANIMATION/////////////////
        if (pogo && !ledgeClimb.ledgeClimb)//-----------If the character is on the pogo stick and not climbing a ledge
        {
            animator.SetBool("IsOnPogo", true);//-------Play the pogo stick animation

            if (groundCheck.grounded)//------------------If the character hits the ground
                animator.SetBool("IsBouncing", true);//-Play the bouncing animation
            else if (!groundCheck.grounded)//------------If the characcter is not touching ground
                animator.SetBool("IsBouncing", false);//Do not play the bouncing animation
        }
        else if (!pogo)//-------------------------------Otherwise, if the character is not on the pogostick
            animator.SetBool("IsOnPogo", false);//------Don't play the pogo stick animation
        #endregion

#region RISING AND FALLING ANIMATION

        ///////////////////RISING AND FALLING ANIMATION/////////////////        
        if ((!groundCheck.grounded && rb.velocity.y > 0) || Input.GetButtonDown("Jump")){//If the character is not grounded and is moving upward or if the player presses the jump button
            rising = true;//---------------------------------------------------------The character is rising
            falling = false;
            animator.SetBool("IsRising", true);//------------------------------------Set the IsRising animation parameter to true
            animator.SetBool("IsFalling", false);}//---------------------------------Set the IsFalling animation parameter false
        else if (!groundCheck.grounded && rb.velocity.y < 0){//-----------------------If the character is not grounded and is moving downward
            rising = false;//--------------------------------------------------------The character is not rising
            falling = true; 
            animator.SetBool("IsRising", false);//-----------------------------------Set the IsRising animation parameter to false
            animator.SetBool("IsFalling", true);}//----------------------------------Set the IsFalling animation parameter to true
        else if (groundCheck.grounded || !isJumping || rb.velocity.y == 0 && !(lookup || lookDown)){//If the character is grounded, or not jumping, or has a vertical velocity of 0, and not looking up or down
            rising = false;//--------------------------------------------------------The character is not rising
            falling = false;//-------------------------------------------------------The character is not falling
            animator.SetBool("IsRising", false);//-----------------------------------Set the IsRising animation parameter to false
            animator.SetBool("IsFalling", false);}//---------------------------------Set the IsFalling animation parameter to false

        //if ((isJumping || jumpedFromPole) && !falling)
        #endregion

#region LOOK DOWN ANIMATION

        ///////////////////LOOK DOWN ANIMAITON////////////////      

        if (!pogo)//-----------------------------------If the character is not on the pogo stick
        {
            if (!uncrouching && Input.GetButton("LookDown"))//----------If the player presses the down button
            {
                lookDown = true;//------------------The character is looking down
                if (!onPole)//----------------------If the character is not on a pole
                    animator.SetBool("LookingDown", true);//Play the looking down (crouching) animation
            }

            if (Input.GetButtonUp("LookDown")){//-------If the player releases the look down button          
                lookDown = false;//---------------------The lookdown bool becomes false
                StartCoroutine("UnCrouching");//--------Start the uncrouching coroutine
                animator.SetBool("LookingDown", false);}//Stop playing the looking down animation
        }

        if (onPole){//------------------------------------If the character is on a pole           
            animator.SetBool("LookingDown", false);}//----Prevent the looking down animation from playing
        #endregion

#region LOOK UP ANIMATION
        ///////////////////LOOKING UP ANIMATION////////////////       

            if (Input.GetButton("LookUp")){//-------------If the player is pressing the look up button                   
                lookup = true;//--------------------------The character looks up
                if (!onPole)
                    animator.SetBool("LookingUp", true);}//---Play the looking up animation
            
            if (Input.GetButtonUp("LookUp")){//-----------If the player releases the up button
                lookup = false;//-------------------------The character is no longer looking up
                animator.SetBool("LookingUp", false);}//--Stop the looking up animation       

        if (onPole){//----------------------------------------------If the character is on a pole          
            animator.SetBool("LookingUp", false);}//----------------Prevent the looking up animation from playing
        #endregion
        #endregion
    }
    void FixedUpdate()
    {
        #region MOVEMENT CONTROLLER
        ///////////////////////////////////Movement//////////////////////////////////////               

        if (!pogo && !onPole && !ledgeClimb.ledgeHang && !ledgeClimb.ledgeClimb)//----If the character is not on a pogo stick, not on a pole, not hanging from or climbing a ledge
        {
            if (groundCheck.grounded && (neuralGun.shoot || lookDown))//--------------If the character is grounded and is shooting or looking down
                rb.velocity = new Vector2(0, 0);//------------------------------------Prevent the character from moving
            else//--------------------------------------------------------------------Otherwise
                rb.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime * 10f, rb.velocity.y);//Set the characters horizontal movement according to the horizontal move variable, and vertical movement according to the vertical forces applied to their rigidbody
           
            acceleration = 2f;//-------------------------------------------------------------------Set the acceleration variable           
            pogoSpeed = 0;//-----------------------------------------------------------------------Make sure the pogo stick speed is reset to zero

            if (groundCheck.grounded){//------------------------------------------------------------if the character is grounded                                                     
                horizontalMove = Input.GetAxisRaw("Horizontal") * topSpeedR;//---------------------Make snappy movement controls
                topSpeedR = 35f;//---------------------------------------------------------------Set the top speed when moving right
                topSpeedL = -35f;}//-------------------------------------------------------------Set the top speed when moving left

            if (!groundCheck.grounded)//------------------------------------------------------------When the character is not grounded                                                                            
            {
                topSpeedR = 35f;//-----------------------------------------------------------------Slightly decrease the top speed when moving right
                topSpeedL = -35f;//----------------------------------------------------------------Slightly decrease the top speed when moving left
                if (xdirection != 0)//-------------------------------------------------------------When the player is pressing the left or right buttons
                    horizontalMove += acceleration * xdirection;//---------------------------------Make horizontal movement less snappy by incorporating the acceleration variable

                if (horizontalMove > topSpeedR)//--------------------------------------------------Prevent the player from exceeding the top speed in the right direction
                    horizontalMove = topSpeedR;

                if (horizontalMove < topSpeedL)//--------------------------------------------------Prevent the player from exceeding the top speed in the left direction
                    horizontalMove = topSpeedL;

                if (xdirection == 0)//-------------------------------------------------------------If the player is not inputting a left or right direction
                {
                    if (horizontalMove < 0)//------------------------------------------------------If the character was moving to the left  
                        horizontalMove += acceleration * .7f;//------------------------------------decelerate the character's movement back to zero by incrementing the horizontal move variable to the right
                    if (horizontalMove > 0)//------------------------------------------------------If the character was moving to the right
                        horizontalMove -= acceleration * .7f;//------------------------------------decelerate the character's movement back to zero by incrementing the horizontal move variable to the left
                }
            }
        }
        #endregion

        #region IMPOSSIBLE POGO TRICK
        if (pogo)//--------------------------------------If the character is on the pogo stick
        {
            impossiblePogoTimer -= Time.fixedDeltaTime;//Make the impossible pogo trick timer count down

            if (impossiblePogoTimer < 0)//---------------If the timer is less than 0
                impossiblePogoTimer = 0;//---------------Keep the timer at zero

            if (Input.GetButton("Jump"))//---------------If the player presses the jump button
                if (impossiblePogoTimer > 0f && impossiblePogoTimer < .5f)//if the timer is greater than 0 but less than 0.5
                    bounceForce = 23.75f;//---------------------------------increase the bounce force
        }
        #endregion
    }
}