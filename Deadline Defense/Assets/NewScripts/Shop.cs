using UnityEngine;


public class Shop : MonoBehaviour
{
	public Tower Policeman;
	public Tower Grenadier;
	public Tower Soldier;

	private TowersController towersController;

	void Start ()
	{
        towersController = TowersController.instance;
	}

	public void BuyPoliceman()
	{
        towersController.ChooseTowerToBuild(Policeman);
	}

	public void BuyGrenadier()
	{
        towersController.ChooseTowerToBuild(Grenadier);
	}

	public void ButSoldier()
	{
        towersController.ChooseTowerToBuild(Soldier);
	}

}
