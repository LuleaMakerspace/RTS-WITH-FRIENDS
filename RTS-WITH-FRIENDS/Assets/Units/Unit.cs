using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
  public float Speed;
  public UnitType UnitType;
  public Vector2 Target {
    get; set;
  }

  public virtual void Update() {

  }

  public virtual void Awake() {
    print(UnitType + " awoken");
  }

  public virtual void Start() {
    print(UnitType + " spawned");
  }

}
