using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable {
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

  public void OnSelect()
  {
    throw new System.NotImplementedException();
  }

  public void OnDirectionsRecived()
  {
    throw new System.NotImplementedException();
  }

  public void OnUnSelect()
  {
    throw new System.NotImplementedException();
  }
}
