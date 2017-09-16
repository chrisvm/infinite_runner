using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject ObjectToFollow;
	
	private Transform _transform;
	private bool IsInside { get; set; }
	
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform>();
		_transform.SetParent(ObjectToFollow.transform);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsInside) return;
		// todo: calculate the delta vector to use as acceleration
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IsInside = true;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		IsInside = false;
	}
}
