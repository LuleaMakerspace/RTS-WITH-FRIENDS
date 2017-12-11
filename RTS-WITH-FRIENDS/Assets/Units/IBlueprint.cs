using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlueprint {
	int RequiredEnergy {
		get;
	}
	Unit Unit {
		get;
	}
	int RequiredMetal {
		get;
	}
	float BuildTime {
		get; set;
	}
}
