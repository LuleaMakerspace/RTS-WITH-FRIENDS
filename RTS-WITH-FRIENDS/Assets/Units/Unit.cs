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
    print(UnitType + " selected");
  }

  public void OnDirectionsRecived(Vector2 position)
  {
    this.Target = position;
    print(UnitType + " got " + position + " as target");
  }

  public void OnUnSelect()
  {
    print(UnitType + " unselected");
  }
}
