using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 velocity = Vector3.zero;

	void FixedUpdate()
	{
		if (player != null)
		{
			transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 40, player.transform.position.z), ref velocity, Time.deltaTime * 1f);
		}
	}
}
