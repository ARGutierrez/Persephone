using UnityEngine;
using System.Collections;

public static class Will
{
	public static int maxWill = 0, will = 0;
	public static int count = 0;

	//Use this to set initial will and add or subtract from total ammount.
	public static void modifyWill(int mod) {
		maxWill += mod;
		will += mod;
	}
	
	public static bool useWill(int cost) {
		if (cost <= will) {
			will -= cost;
			count ++;
			return true;
		} else {
			return false;
		}
	}

	public static void returnWill(int cost) {
		will += cost;
		count --;
	}
}