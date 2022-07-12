using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds data for displaying on the HUD; controlled by the GameObject's animator
/// None of the data here has any functionality, it's just for displaying on the HUD
/// </summary>
public class EntityInfo : MonoBehaviour
{
	[Header("Data"), ReadOnly]
	public float velocity;
	[Tooltip("Actual velocity calculated based off of the movement")]
	[ReadOnly]
	public float realVelocity;
	[ReadOnly]
	public Vector2 position;
	[ReadOnly]
	public int elevation;
	[ReadOnly]
	public Quaternion rotation;
	[ReadOnly]
	public Vector2 direction;

	private Vector2 lastPos = new Vector2();
	private void Update()
	{
		float distance = Vector2.Distance(transform.position, lastPos);
		// Convert to nautical miles per hour
		distance *= 5.0f;
		distance = distance / Time.deltaTime * 3600;
		realVelocity = distance;
		lastPos = transform.position;
	}
}
