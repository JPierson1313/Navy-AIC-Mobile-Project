using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Detatch attatched cameras when being destroyed; used by CameraMovement.cs
/// </summary>
public class DetatchCamera : MonoBehaviour
{
	public Transform cameraTransform;
	public void Start()
	{
		SceneManager.sceneUnloaded += OnSceneUnloaded;
		Debug.Log("Start: SceneLoaded1");
	}

	private void OnSceneUnloaded(Scene current)
	{
		Debug.Log("OnSceneUnloaded: " + current);
	}

	private void OnDestroy()
	{
		if (cameraTransform != null)
		{
			cameraTransform.transform.parent = null;
		}
	}
}
