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
	public bool UseResource(Resource resource)
	{
		foreach (Resource listResource in Resources) {
			if (resource.ResourceType == listResource.ResourceType) {
				if (listResource.Amount - resource.Amount < 0) {
					return false;
				}
				else {
					listResource.Amount -= resource.Amount;
					return true;
				}
			}
		}
		return false;
	}
	public bool UseResources(List<Resource> resources) {
		foreach (Resource resource in resources) {
			if (!UseResource(resource)) {
				return false;
			}
		}
		return true;
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
