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

	public Factory TestFactory;
	public UnitLibrary UnitLibrary;
	public static GameController Instance;

	// Use this for initialization
	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(this);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			TestFactory.PushUnit(new TankBlueprint());
		}
	}
}
