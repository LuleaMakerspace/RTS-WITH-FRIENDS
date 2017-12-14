using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable
{
  public float Speed;
  public UnitType UnitType;
  public Target Target
  {
    get; set;
  }

  public virtual void Update()
  {
    Move();
  }

  public virtual void Move() {
    if(Target != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, Target.GetTargetPosition(), Time.deltaTime * Speed);
      if (Vector2.Distance(transform.position, Target.GetTargetPosition()) < Target.AcceptableDistance()) {
        Target = null;
      }
    }
  }

  public virtual void Awake()
  {
    print(UnitType + " awoken");
  }

  public virtual void Start()
  {
    print(UnitType + " spawned");
  }

  public void OnSelect()
  {
    print(UnitType + " selected");
  }

  public void OnRightClick(Vector2 position)
  {
    this.Target = new StaticPositionTarget(position);
    print(UnitType + " got " + position + " as target");
  }

  public void OnUnSelect()
  {
    print(UnitType + " unselected");
  }
}
