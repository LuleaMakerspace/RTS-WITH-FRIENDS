﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable {
	void OnSelect();
	void OnDirectionsRecived();
	void OnUnSelect();
}
