using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGreyInput : MonoBehaviour {

    private const string AnimationStateParam = "PlayerGreyAnimationState";

    public uint HorizontalSpeed;
    public uint JumpScale;

    private Animator _animator;
    public Rigidbody2D _playerRigidBody;

    enum AnimationState
    {
        Idle,
        Walk,
        Jump
    }

	// Use this for initialization
	void Start () {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float hzInput = Input.GetAxis("Horizontal");
        
        if(hzInput < 0)
        {
            _playerRigidBody.transform.Translate(Vector3.left * HorizontalSpeed * Time.deltaTime);
            _animator.SetInteger(AnimationStateParam, (int)AnimationState.Walk);
        }
        else if (hzInput > 0)
        {
            _playerRigidBody.transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
            _animator.SetInteger(AnimationStateParam, (int)AnimationState.Walk);
        }
        else
        {
            _animator.SetInteger(AnimationStateParam, (int)AnimationState.Idle);
        }
    }
}
