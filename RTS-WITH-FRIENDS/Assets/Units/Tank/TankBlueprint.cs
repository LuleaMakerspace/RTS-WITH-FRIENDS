using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBlueprint : IBlueprint
{
  public int RequiredEnergy
  {
    get
    {
      return 200;
    }
  }
	public TankBlueprint()
	{
			BuildTime = 3;
	}
  public int RequiredMetal { get { return 200; } }
  public float BuildTime { get; set; }

  public Unit Unit
  {
    get
    {
      return new TankUnit();
    }
  }
}
