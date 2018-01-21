using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraFollow : MonoBehaviour {

	public float followHieght = 8f;
	public float followDistance = 6f;

	private Transform player;
	private float targerHeight;
	private float currentHeight;
	private float currentRotation;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		targerHeight = player.position.y + followHieght;
		currentRotation = transform.eulerAngles.y;
		currentHeight = Mathf.Lerp (transform.position.y, targerHeight, 0.9f * Time.deltaTime);
		Quaternion euler = Quaternion.Euler (0f, currentRotation, 0f);
		Vector3 targetPosition = player.position - (euler * Vector3.forward) * followDistance;
		targetPosition.y = currentHeight;
		transform.position = targetPosition;
		transform.LookAt (player);

	}
}
