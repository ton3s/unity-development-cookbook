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

	private void OnTriggerEnter(Collider other)
	{
		Debug.LogFormat("Object {0} entered trigger {1}!",
						other.name, this.name);
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.LogFormat("Object {0} exited trigger {1}!",
						other.name, this.name);
	}

}
