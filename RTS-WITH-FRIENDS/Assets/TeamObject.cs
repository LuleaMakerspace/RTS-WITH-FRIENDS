using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TeamObject : MonoBehaviour {
	public Team Team {
    get; set;
  }
	public bool IsOwnTeam() {
		return GameController.Instance.Team == Team;
	}
	public static TeamObject SpawnTeamObject(TeamObject teamObject, Vector2 position, Quaternion rotation, Team team) {
		teamObject.Team = team;
		TeamObject spawnedTeamObject = Instantiate(teamObject, position, rotation);
		return spawnedTeamObject;
	}
	void OnMouseEnter() {
		GetComponent<Renderer>().material.color = GetTeamColor();
	}

	Color GetTeamColor() {
		return IsOwnTeam() ? Color.green : Color.red;
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = Color.white;
	}
}
