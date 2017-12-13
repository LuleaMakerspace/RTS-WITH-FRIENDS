using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
  void OnSelect();
  void OnRightClick(Vector2 position);
  void OnUnSelect();
}
