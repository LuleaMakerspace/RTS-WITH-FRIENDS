using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private Vector2 dragStart;
	public float MoveSpeed;

	public float MaxZoom;
	public float MinZoom;
	public float ZoomSpeed;

	void Start () {
		
	}
	void Update () {
		transform.position += (Vector3)new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed * Time.deltaTime;
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > MinZoom) {
			Camera.main.orthographicSize -= ZoomSpeed;
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < MaxZoom) {
			Camera.main.orthographicSize += ZoomSpeed;
		}
	}
}
