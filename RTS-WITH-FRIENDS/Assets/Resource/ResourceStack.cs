using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceStack
{

  public List<Resource> Resources
  {
    get; private set;
  }

  public ResourceStack()
  {
    Resources = new List<Resource>();
  }
  public ResourceStack(List<Resource> resources)
  {
    Resources = resources;
  }
  public void AddResource(Resource resource)
  {
    if (FindResource(resource.ResourceType) != null)
    {
      FindResource(resource.ResourceType).Amount += resource.Amount;
    }
    else
    {
      Resources.Add(resource);
    }
  }
  public void AddResources(List<Resource> resources)
  {
    resources.ForEach(resource => AddResource(resource));
  }
  public Resource FindResource(ResourceType resourceType)
  {
    foreach (Resource resource in Resources)
    {
      if (resource.ResourceType == resourceType)
      {
        return resource;
      }
    }
    return null;
  }
}
