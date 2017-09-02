using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private const float FloatTolerance = 0.0f;
	
    public uint HorizontalSpeed;
    public uint JumpThrust;

    public Animator Animator;
    public Rigidbody2D RigidBody;
	public SpriteRenderer SpriteRenderer;

	private Vector2 _vectorInstance;
	private BoxCollider2D _feetCollider;

	void Start() {
		_vectorInstance = new Vector2();
		_feetCollider = GetComponent<BoxCollider2D>();
	}
	
	void FixedUpdate () {
        var horizontalInput = Input.GetAxis("Horizontal");
		var jumpInput = Input.GetAxis("Jump");
		var absHorizontalInput = Math.Abs(horizontalInput);
		
		// check feet collider for collision
		var inGround = _feetCollider.IsTouchingLayers();
		var isJumping = Animator.GetBool("IsJumping");
		Animator.SetBool("InGround", inGround);
		if (inGround || RigidBody.velocity.y <= 0 && isJumping) {
			Animator.SetBool("IsJumping", false);
		}
		
		// change some values while on air
		if (!inGround) {
			horizontalInput *= 0.7f;
		}
		
		if (absHorizontalInput > FloatTolerance) {
			// set walking anim if feet touching 
			if (inGround) {
				Animator.SetBool("IsMoving", true);
			}
			
			// calculate force for desired displacement
			var displacement = HorizontalSpeed * horizontalInput * 2 - RigidBody.velocity.x;
			_vectorInstance.x = displacement;
			RigidBody.AddForce(_vectorInstance);
			
			// flip sprite to its moving direction
			SpriteRenderer.flipX = horizontalInput < FloatTolerance;
		}
		else {
			// set stopping animation
			Animator.SetBool("IsMoving", false);
			
			if (inGround) {
				// brake while touching ground
				_vectorInstance.x = -1 * RigidBody.velocity.x * Math.Abs(RigidBody.velocity.x) * 1.1f;
				RigidBody.AddForce(_vectorInstance);
			}
		}

		if (jumpInput > FloatTolerance && inGround) {
			Animator.SetBool("IsJumping", true);
			_vectorInstance.x = 0;
			_vectorInstance.y = JumpThrust + 0.6f * RigidBody.velocity.x;
			RigidBody.AddForce(_vectorInstance);
			_vectorInstance.y = _vectorInstance.x = 0;
		}
	}
}
