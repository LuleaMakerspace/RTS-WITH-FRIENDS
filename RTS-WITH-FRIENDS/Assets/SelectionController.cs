using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
  private List<ISelectable> selectedObjects = new List<ISelectable>();
  private Vector2 startDrag;
  private Vector2 endDrag;
  public float MinimumDragDistance;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      startDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    if (Input.GetMouseButtonUp(0))
    {
      endDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      if (Vector2.Distance(startDrag, endDrag) < MinimumDragDistance)
      {
        RaycastHit2D hit = Physics2D.Raycast(endDrag, -Vector2.up);
        if (hit.collider != null)
        {
          ISelectable selectableObject = hit.transform.GetComponent<ISelectable>();
          if (selectableObject != null)
          {
            SelectObjects(new List<ISelectable>() { selectableObject });
          }
        }
        else
        {
          RemoveSelection();
        }
      }
      else
      {

      }
    }
    if (Input.GetMouseButtonDown(1))
    {
      this.selectedObjects.ForEach(selectedObject => selectedObject.OnRightClick(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
  }
  private void RemoveSelection()
  {
    this.selectedObjects.ForEach(selectedObject => selectedObject.OnUnSelect());
    this.selectedObjects = new List<ISelectable>();
  }
  private void SelectObjects(List<ISelectable> objects)
  {
    this.selectedObjects = objects;
    this.selectedObjects.ForEach(selectedObject => selectedObject.OnSelect());
  }
}
