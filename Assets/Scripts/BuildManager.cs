
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake()
	{	if (instance != null) {
			Debug.LogError ("More than one BuildManger in scene!");
		}
		instance = this;
	}


	public GameObject standadTurretPrefab;

	void Start()
	{
		turretToBuild = standadTurretPrefab;
	}

	private GameObject turretToBuild;

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

}
