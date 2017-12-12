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
			// Check if click
			print(Vector2.Distance(startDrag, endDrag));
			if (Vector2.Distance(startDrag, endDrag) < 0.3) {
				print("Click occured");
				RaycastHit2D hit = Physics2D.Raycast(endDrag, -Vector2.up);
				if (hit.collider != null && hit.transform.GetComponent<ISelectable>() != null) {
					SelectObjects(new List<ISelectable>() {hit.transform.GetComponent<ISelectable>()});
				}
			}
			else {
				print("Drag occured...");
				// This is a drag
			}
		}
	}
	private void SelectObjects(List<ISelectable> objects) {
		this.selectedObjects = objects;
		print("Selected objects");
	}
}
