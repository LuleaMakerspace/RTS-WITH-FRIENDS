using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
  public Factory TestFactory;
  public UnitLibrary UnitLibrary;
  public static GameController Instance;
  public ResourceStack ResourceStack {
    get; private set;
  }
  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      ResourceStack = new ResourceStack();
    }
    else
    {
      Destroy(this);
    }
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      TestFactory.PushUnit(new TankBlueprint());
    }
  }
}
