using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Vector2 dragStart;
	public float MoveSpeed;

	void Start () {
		
	}
	void Update () {
		transform.position += (Vector3)new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed * Time.deltaTime;
	}
}
