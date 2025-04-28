using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private Tower towerToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return towerToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.TowerInfo.Cost; } }

	public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		towerToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild (Tower tower)
	{
		towerToBuild = tower;
		DeselectNode();
	}

	public Tower GetTurretToBuild ()
	{
		return towerToBuild;
	}

}
