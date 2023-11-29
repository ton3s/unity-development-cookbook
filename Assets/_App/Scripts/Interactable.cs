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
}
