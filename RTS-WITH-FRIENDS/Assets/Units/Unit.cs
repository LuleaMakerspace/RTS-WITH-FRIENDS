using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : TeamObject, ISelectable
{
  public float Speed;
  public UnitType UnitType;
  public Target Target
  {
    get; set;
  }

  public Vector2 RealTarget {get;set;}

  public Queue<Vector2> DrivingOrder {get;set;}
  public virtual void Update()
  {
    if(RealTarget == null && DrivingOrder.Count > 0)
    {
      RealTarget = DrivingOrder.Dequeue();
    }
    Move();
  }

  public virtual void Move()
  {
    if (RealTarget != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, RealTarget, Time.deltaTime * Speed);
      if (Vector2.Distance(transform.position, RealTarget) < 0.5f)
      {
        RealTarget = DrivingOrder.Dequeue();
      }
    }
  }

  private void SetTarget(List<Vector2> targets, int id)
  {
    print("Fick en order på " + targets.Count);
    DrivingOrder = new Queue<Vector2>(targets);
  }
  public override void OnRightClick(Vector2 position)
  {
    if (!IsOwnTeam()) {
      return;
    }
    var paaa = GameController.Instance.GetComponent<Pathfinding>();
    paaa.FindPathPriority(transform.position, position, 123, SetTarget);
  //   this.Target = new StaticPositionTarget(position);
  //   print(UnitType + " got " + position + " as target");
  }
}
