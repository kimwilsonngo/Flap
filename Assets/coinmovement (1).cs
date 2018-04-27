using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmovement : MonoBehaviour {

	public float RotationSpeed = 45.0f;
	// Use this for initialization


	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, RotationSpeed * Time.deltaTime);
	}
}
