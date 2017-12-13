using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPositionTarget : Target
{
  public Vector2 StaticTargetPosition
  {
    get; private set;
  }
  public StaticPositionTarget(Vector2 staticTargetPosition)
  {
    this.StaticTargetPosition = staticTargetPosition;
  }

  public Vector2 GetTargetPosition()
  {
    return StaticTargetPosition;
  }
}
