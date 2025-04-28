using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	private static Color hoverColor = Color.gray;
    private static Vector3 towerOffset = new Vector3(0, 0.5f, 0);

    private TowersController towersController;
    private Renderer rend;
    private Color startColor;

    public Tower tower;
    public Vector3 towerPosition { get { return transform.position + towerOffset; } }

    private void SetColor(Color color)
	{
		rend.material.color = color;
    }

	private void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

        towersController = TowersController.instance;
    }

	void OnMouseDown ()
	{
        // if cursor on UI
        if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (towersController.IsCanBuild)
		{
            towersController.Build(this);
			SetColor(startColor);
        }	
	}

	void OnMouseEnter ()
	{
		// if cursor on UI
		if (EventSystem.current.IsPointerOverGameObject() || !towersController.IsCanBuild)
			return;
		
		SetColor(hoverColor);
	}

	void OnMouseExit ()
	{
		SetColor(startColor);
    }
}
