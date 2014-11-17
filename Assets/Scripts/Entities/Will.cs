using UnityEngine;
using System.Collections;

public static class Will
{
	static int maxWill = 0, will = 0;
	public static bool full = true;

	//Use this to set initial will and add or subtract from total ammount.
	public static void modifyWill(int mod) {
		maxWill += mod;
		will += mod;

		if (maxWill == will)
			full = true;
		else
			full = false;
	}
	
	public static bool useWill(int cost) {
		if (cost <= will) {
			will -= cost;
			return true;
		} else {
			return false;
		}

		if (maxWill == will)
			full = true;
		else
			full = false;
	}

	public static void returnWill(int cost) {
		will += cost;

		if (maxWill == will)
			full = true;
		else
			full = false;
	}
}