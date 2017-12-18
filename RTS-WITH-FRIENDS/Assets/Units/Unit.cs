using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : TeamObject, ISelectable
{
  public float Speed;
  public UnitType UnitType;
  public Vector2 CurrentTarget {get;set;}
  public Queue<Vector2> DrivingOrder {get;set;}

  public virtual void Update()
  {
    Move();
  }

  public virtual void Move()
  {
      transform.position = Vector2.MoveTowards(transform.position, CurrentTarget, Time.deltaTime * Speed);
      if (Vector2.Distance(transform.position, CurrentTarget) < 0.5f)
      {
        CurrentTarget = DrivingOrder.Dequeue();
      }
  }

  private void SetTarget(List<Vector2> targets, int id)
  {
    DrivingOrder = new Queue<Vector2>(targets);
  }

  public override void OnRightClick(Vector2 position)
  {
    if (!IsOwnTeam()) {
      return;
    }
    var pathfinding = GameController.Instance.GetComponent<Pathfinding>();
    pathfinding.FindPathPriority(transform.position, position, 123, SetTarget);
  }
}
