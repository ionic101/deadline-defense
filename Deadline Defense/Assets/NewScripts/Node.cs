using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Node : MonoBehaviour {

	private static Color hoverColor = Color.green;
	private static Color upgradeColor = Color.yellow;
    private static Vector3 towerOffset = new Vector3(0, 0.5f, 0);

    private TowersController towersController;
    private Renderer rend;
    private Color startColor;

    public Tower tower;
    public Vector3 towerPosition { get { return transform.position + towerOffset; } }

    private GameObject shootArea;

    private void SetColor(Color color)
	{
		rend.material.color = color;
    }

	private void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

        towersController = TowersController.instance;


        //shoot area
        shootArea = GameObject.FindWithTag("ShootArea");
        HideShootArea();
    }

	void OnMouseDown ()
	{
        // if cursor on UI
        if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (tower != null)
		{
            DisplayShootArea();
            UpgraderUI.instance.UpdateData(tower);
            UpgraderUI.instance.Upgrader.SetActive(true);
			return;
        }

        HideShootArea();

		if (towersController.IsCanBuild)
		{
            towersController.Build(this);
			SetColor(startColor);
        }
        UpgraderUI.instance.Upgrader.SetActive(false);
    }

	void OnMouseEnter ()
	{
		// if cursor on UI
		if (EventSystem.current.IsPointerOverGameObject())
			return;

        if (towersController.IsCanBuild)
            SetColor(hoverColor);
		else if (tower != null)
			SetColor(upgradeColor);
    }

	private void DisplayShootArea()
	{
        if (shootArea == null)
            return;

        shootArea.transform.localScale = new Vector3(tower.ShootRange * 2, shootArea.transform.localScale.y, tower.ShootRange * 2);
        shootArea.transform.position = tower.transform.position;
        shootArea.GetComponent<MeshRenderer>().enabled = true;
    }

    private void HideShootArea()
    {
        if (shootArea != null)
            shootArea.GetComponent<MeshRenderer>().enabled = false;
    }

	void OnMouseExit ()
	{
		SetColor(startColor);
    }
}
