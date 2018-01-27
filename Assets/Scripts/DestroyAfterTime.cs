using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float timer = 2f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timer);
	}
	

}
