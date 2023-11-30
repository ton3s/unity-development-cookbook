using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
	[SerializeField] private KeyCode interactionKey = KeyCode.Return;
	[SerializeField] private float interactingRange = 2;

	private void Update()
	{
		if (Input.GetKeyDown(interactionKey))
		{
			AttemptInteraction();
		}
	}

	private void AttemptInteraction()
	{
		var ray = new Ray(transform.position, transform.forward);

		int everythingExceptPlayers = ~(1 << LayerMask.NameToLayer("Player"));
		int layerMask = Physics.DefaultRaycastLayers & everythingExceptPlayers;

		// Draw ray cast for troubleshooting
		Debug.DrawRay(ray.origin, ray.direction * interactingRange, Color.red, 5);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, interactingRange, layerMask))
		{
			Interactable interactable = hit.collider.GetComponent<Interactable>();
			if (interactable != null)
			{
				interactable.Interact(this.gameObject);
			}
		}
	}
}
