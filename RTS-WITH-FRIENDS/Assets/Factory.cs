﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
		En fabrik som kan producera trupper
 */
public class Factory : MonoBehaviour {
	public Queue<IBlueprint> UnitQueue {
		get; private set;
	}

	public IBlueprint CurrentProduction {get;set;}

	public Factory()
	{
			UnitQueue = new Queue<IBlueprint>();
	}

	void FixedUpdate() {
		if (CurrentProduction == null && UnitQueue.Count > 0) {
			CurrentProduction = UnitQueue.Dequeue();
		}
		if (CurrentProduction != null) {
			CurrentProduction.BuildTime -= Time.fixedDeltaTime;
			if (CurrentProduction.BuildTime < 0) {
				SpawnUnit(CurrentProduction.Unit);
				CurrentProduction = null;
			}
		}
	}

	void SpawnUnit(Unit unit) {
		Instantiate(unit);
	}

	public void PushUnit(IBlueprint blueprint) {
		UnitQueue.Enqueue(blueprint);
	}
}
