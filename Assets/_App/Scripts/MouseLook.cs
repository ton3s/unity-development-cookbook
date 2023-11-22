using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	[SerializeField] private float turnSpeed = 90f;
	[SerializeField] private float headUpperAngleLimit = 85f;
	[SerializeField] private float headLowerAngleLimit = -80f;

	float yaw = 0f;
	float pitch = 0f;

	Quaternion bodyStartRotation;
	Quaternion headStartRotation;

	Transform head;

	private void Start()
	{
		head = GetComponentInChildren<Camera>().transform;

		bodyStartRotation = transform.localRotation;
		headStartRotation = head.transform.localRotation;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Mouse X") * Time.deltaTime * turnSpeed;
		float vertical = Input.GetAxis("Mouse Y") * Time.deltaTime * turnSpeed;

		yaw += horizontal;
		pitch -= vertical;

		pitch = Mathf.Clamp(pitch, headLowerAngleLimit, headUpperAngleLimit);

		Quaternion bodyRotation = Quaternion.AngleAxis(yaw, Vector3.up);
		Quaternion headRotation = Quaternion.AngleAxis(pitch, Vector3.right);

		transform.localRotation = bodyRotation * bodyStartRotation;
		head.localRotation = headRotation * headStartRotation;
	}
}
