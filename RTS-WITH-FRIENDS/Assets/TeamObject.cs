using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(SpriteRenderer))]
public class TeamObject : MonoBehaviour, ISelectable {
	public Team Team {
    get; set;
  }
	public Sprite FriendlySprite;
	public Sprite EnemySprite;
	public bool IsOwnTeam() {
		return GameController.Instance.Team == Team;
	}
	public static TeamObject SpawnTeamObject(TeamObject teamObject, Vector2 position, Quaternion rotation, Team team) {
		TeamObject spawnedTeamObject = Instantiate(teamObject, position, rotation);
		spawnedTeamObject.Team = team;
		spawnedTeamObject.GetComponent<SpriteRenderer>().sprite = spawnedTeamObject.IsOwnTeam() ? spawnedTeamObject.FriendlySprite : spawnedTeamObject.EnemySprite;
		return spawnedTeamObject;
	}
	void OnMouseEnter() {
	}
	Color GetTeamColor() {
		return IsOwnTeam() ? Color.green : Color.red;
	}
	void OnMouseExit() {
	}

  public virtual void OnSelect()
  {
		GetComponent<Renderer>().material.color = GetTeamColor();
  }
  public virtual void OnRightClick(Vector2 position)
  {
  }
  public virtual void OnUnSelect()
  {
		GetComponent<Renderer>().material.color = Color.white;
  }
}
