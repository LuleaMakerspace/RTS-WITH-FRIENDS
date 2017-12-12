using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour {

	// This is where magic happens
	// > No
	// > YEs
	// > Is Victor delusional?
	// > Proably
	// > Cool

	public Factory TestFactory;
	public UnitLibrary UnitLibrary;
	public static GameController Instance;

	private List<ISelectable> selectedObjects = new List<ISelectable>();

	private Vector2 startDrag;
	private Vector2 endDrag;

	// Use this for initialization
	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(this);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			TestFactory.PushUnit(new TankBlueprint());
		}
		// Basic select prototype
		if (Input.GetMouseButtonDown(0)) {
			startDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if (Input.GetMouseButtonUp(0)) {
			endDrag = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(startDrag, endDrag) < 0.3) {
				RaycastHit2D hit = Physics2D.Raycast(endDrag, -Vector2.up);
				if (hit.collider != null) {	
					if (hit.transform.GetComponent<ISelectable>() != null) {
						SelectObjects(new List<ISelectable>() {hit.transform.GetComponent<ISelectable>()});
					}
				}
				else {
					RemoveSelection();
				}
			}
			else {

			}
		}
		if (Input.GetMouseButtonDown(1)) {
			this.selectedObjects.ForEach(selectedObject => selectedObject.OnDirectionsRecived(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
		}
	}
	private void RemoveSelection() {
		this.selectedObjects.ForEach(selectedObject => selectedObject.OnUnSelect());
		this.selectedObjects = new List<ISelectable>();
	}
	private void SelectObjects(List<ISelectable> objects) {
		this.selectedObjects = objects;
		this.selectedObjects.ForEach(selectedObject => selectedObject.OnSelect());
	}
}
