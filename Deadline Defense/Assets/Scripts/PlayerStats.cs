using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 0;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		Money = 250;
		Lives = startLives;

		Rounds = 0;
	}

}
