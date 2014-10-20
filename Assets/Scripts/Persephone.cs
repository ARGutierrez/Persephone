using UnityEngine;
using System.Collections;

public class Persephone : BaseUnit {

	private int MaxWill, CurWill;
	private int INVENTORY_SIZE = 20;
	private bool[] inventory = new bool[INVENTORY_SIZE];
	public GameObject[] minions;

	/*TODO
	 * constructor that modifies the BaseUnit's constructor to initialize her private variables.
	 */
	public Persephone() {

	}

	public void setMaxWill(int i) {
		MaxWill = i;
	}

	public void setCurWill(int i) {
		CurWill = i;
	}

	public int getMaxWill() {
		return MaxWill;
	}

	public int getCurWill() {
		return CurWill;
	}

	/*TODO
	*Accessor method for the summons list
	*NOTE: not certain what parameter should be...	*/
	public GameObject getMinion(string s) {

	}

	/*TODO
	 * 
	 */
	public void summonMinion(GameObject m) {

	}

	/*TODO
	 * 
	 */
	public void updateInventory() {

	}

}