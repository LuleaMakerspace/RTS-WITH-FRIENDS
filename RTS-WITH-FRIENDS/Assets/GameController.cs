using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// This is where magic happens
	// > No
	// > YEs
	// > Is Victor delusional?
	// > Proably
	// > Cool

	public Factory testFactory;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			testFactory.PushUnit(new TankBlueprint());
		}
	}
}
