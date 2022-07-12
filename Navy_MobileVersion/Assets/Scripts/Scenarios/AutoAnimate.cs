using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAnimate : MonoBehaviour
{
	EntityInfo ei;
	private LineRenderer lr;
	[SerializeField, Tooltip("Initial bearing for radar line & sprite rotation")]
	private Vector2 initialBearing;
	private Vector3 prevPos;
	[Tooltip("Sets object rotation if true, use when swapping between realistic & gamified")]
	public bool setRotation = true;
	[SerializeField, Range(0.1f, 3.0f)]
	float LineLength = 1.0f;
	[SerializeField]
	bool controlPosition = true;
	public GameObject sprite;

	private void Awake()
	{
		ei = GetComponent<EntityInfo>();
		lr = GetComponent<LineRenderer>();
	}

	private void FixedUpdate()
	{
		if (prevPos != transform.position)
		{
			prevPos = transform.position;
		}
		else
		{
			prevPos = transform.position - (Vector3)initialBearing;
		}
	}

	private void Update()
	{
		Vector3 dir = transform.position - prevPos;
		dir = dir.normalized;
		if (dir != Vector3.zero)
		{
			ei.direction = dir;
			if (setRotation)
			{
				sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
			}
			ei.rotation = Quaternion.LookRotation(Vector3.forward, dir);

			// Draw momentum indictar
			lr.SetPosition(0, transform.position);
			lr.SetPosition(1, (Vector2)transform.position + (Vector2)dir * transform.localScale * LineLength);
		}
		if (controlPosition)
		{
			transform.position = ei.position;
		}
	}
}
