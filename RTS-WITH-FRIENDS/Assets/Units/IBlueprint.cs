using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
	Vad som behövs för att kunna bygga en Unit
 */
public interface IBlueprint
{
  int RequiredEnergy
  {
    get;
  }
  Unit Unit
  {
    get;
  }
  int RequiredMetal
  {
    get;
  }
  float BuildTime
  {
    get; set;
  }
}
