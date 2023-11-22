using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 6f;
	[SerializeField] private float jumpHeight = 2f;
	[SerializeField] private float gravity = 20f;
	[Range(0, 10), SerializeField] private float airControl = 5;
	Vector3 moveDirection = Vector3.zero;

	CharacterController characterController;

	private void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	private void FixedUpdate()
	{
		Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		input *= moveSpeed;
		input = transform.TransformDirection(input);

		if (characterController.isGrounded)
		{
			moveDirection = input;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = Mathf.Sqrt(2 * gravity * jumpHeight);
			}
			else
			{
				moveDirection.y = 0;
			}
		}
		else
		{
			input.y = moveDirection.y;
			moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		characterController.Move(moveDirection * Time.deltaTime);
	}
}
