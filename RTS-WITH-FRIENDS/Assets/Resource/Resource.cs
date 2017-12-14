using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
  public int Amount
  {
    get; set;
  }
  public ResourceType ResourceType
  {
    get; private set;
  }
  public Resource(ResourceType resourceType, int amount = 0)
  {
    this.ResourceType = resourceType;
    this.Amount = amount;
  }
}
