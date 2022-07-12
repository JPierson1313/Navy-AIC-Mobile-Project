using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePathing : MonoBehaviour
{
	[Tooltip("The object that this missile should fly towards")]
	public Transform target;
	[Tooltip("Speed at which this missile turns to face its target")]
	[SerializeField, Range(0.0f, 100.0f)]
	private float turnSpeed = 40.0f;
	[Tooltip("Speed at which this missile moves forward")]
	[SerializeField, Range(0.0f, 4.0f)]
	private float moveSpeed = 1.0f;
	[Tooltip("How fast this missile can reach max speed")]
	[SerializeField, Range(0.0f, 3.0f)]
	private float accelerationSpeed = 1.0f;
	[SerializeField]
	private float speedRate = 0.0f;
	[SerializeField]
	private GameObject explosionVFX;

	void Update()
	{
		if (target != null)
		{
			// Rotate towards target
			Vector2 direction = target.position - transform.position;
			direction.Normalize();
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * (angle - 90)),
				turnSpeed * Time.deltaTime);
			// Move towards target
			speedRate += accelerationSpeed * Time.deltaTime;
			speedRate = Mathf.Min(1.0f, speedRate);
			transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, moveSpeed * speedRate * Time.deltaTime);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform == target.transform)
		{
			Instantiate(explosionVFX, transform.position, explosionVFX.transform.rotation);
			Destroy(target.gameObject);
			Destroy(gameObject);
		}
	}
	private void OnEnable()
	{
		if (transform.parent != null)
		{
			transform.parent = null;
		}
	}
}
