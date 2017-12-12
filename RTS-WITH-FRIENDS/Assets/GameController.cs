using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour {
	public Factory TestFactory;
	public UnitLibrary UnitLibrary;
	public static GameController Instance;

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(this);
		}
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			TestFactory.PushUnit(new TankBlueprint());
		}
	}
}
