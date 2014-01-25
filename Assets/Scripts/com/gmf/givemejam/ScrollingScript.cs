using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
	/// <summary>
	/// Scrolling speed
	/// </summary>
	public float speed;
	
	/// <summary>
	/// 2 - List of children with a renderer.
	/// </summary>
	private List<Transform> backgroundPart;
	
	// 3 - Get all the children
	void Start()
	{
		// Get all the children of the layer with a renderer
		backgroundPart = new List<Transform>();
		
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			
			// Add only the visible children
			if (child.renderer != null)
			{
				backgroundPart.Add(child);
			}
		}

		// Sort by position.
		// Note: Get the children from left to right.
		// We would need to add a few conditions to handle
		// all the possible scrolling directions.
		backgroundPart = backgroundPart.OrderBy(
			t => t.position.x
			).ToList();
	}
	
	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			-(speed * Time.deltaTime),
			0,
			0);

		transform.Translate(movement);

			// Get the first object.
			// The list is ordered from left (x position) to right.
		Transform firstChild = backgroundPart.FirstOrDefault();
		
		if (firstChild != null)
		{
			// Check if the child is already (partly) before the camera.
			// We test the position first because the IsVisibleFrom
			// method is a bit heavier to execute.
			if (firstChild.position.x < Camera.main.transform.position.x)
			{
				// If the child is already on the left of the camera,
				// we test if it's completely outside and needs to be
				// recycled.

				if (firstChild.renderer.bounds.max.x <= Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect))
				{
					// Get the last child position.
					Transform lastChild = backgroundPart.LastOrDefault();
					Vector3 lastPosition = lastChild.transform.position;
					Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

					// Set the position of the recyled one to be AFTER
					// the last child.
					// Note: Only work for horizontal scrolling currently.
					firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);
					
					// Set the recycled child to the last position
					// of the backgroundPart list.
					backgroundPart.Remove(firstChild);
					backgroundPart.Add(firstChild);
				}
			}
		}

	}
}