
using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffSet;

	private GameObject turret;

	private Renderer rend;
	private Color startColor;



	void Start()
	{
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseDown()
	{
		if (turret != null) {
			Debug.Log ("Can build there! - TODO: Display on screen.");
			return;
		}


		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild ();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + positionOffSet, transform.rotation);
	}

	void OnMouseEnter()
	{
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
