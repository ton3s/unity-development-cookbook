using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
	public void Interact(GameObject fromObject)
	{
		Debug.Log($"I've ({this.gameObject}) been interacted with {fromObject}");
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.LogFormat("Object {0} started touching {1}!",
						collision.gameObject.name, this.name);
	}

	private void OnCollisionExit(Collision collision)
	{
		Debug.LogFormat("Object {0} stopped touching {1}!",
						collision.gameObject.name, this.name);
	}
}
