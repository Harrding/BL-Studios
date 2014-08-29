using UnityEngine;
using System.Collections;

public static class MasterClass {

	/* Write down each food type and its index here
	 * 0 = Wheat
	 * 1 = Fish
	 * 2 = Potato
	 * 3 = Cabbages
	 * 4 = Meat
	 */
	public static int NUM_FOOD = 5;

	/* Types of tools
	 * 0 = Sword
	 * 1 = Pickaxe
	 * 2 = Hoe
	 */
	public static int NUM_TOOLS = 3;

	// Starting values for each resource
	public static int STARTING_FOOD = 500;
	public static int STARTING_TOOLS= 2;
	public static int STARTING_MEDICINE = 400;

	// Method to get the price based on the scarcity of a certain food product
	// Will create the same method for tools as well
	public static float getPrice(Food food, float scarcity) {
		return food.getDefaultPrice () / (scarcity);
	}

	/* Village Types
	 * 0 = Farming
	 * 1 = Mining/Smithing
	 * 2 = Fishing
	 * 3 = Lumber
	 * 4 = Ranching
	 */
	public static int FARMING_ID = 0;
	public static int MINING_ID = 1;
	public static int FISHING_ID = 2;
	public static int LUMBER_ID = 3;
	public static int RANCHING_ID = 4;

	/*
	public static float MUCalc(Food item) {
		// Calculates the marginal utility per item
	}
	public static float MUCalc(Tools item){
		
	}
	public static float MUCalc(){
		
	}
	*/
}
