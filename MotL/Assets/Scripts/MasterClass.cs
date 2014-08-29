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
	public static float[] V_DECAY_RATE = {1.00f};
	public static int STARTING_FOOD = 500;
	public static int STARTING_TOOLS= 2;
	public static int STARTING_MEDICINE = 400;
	public static float getPrice(Food food, float scarcity) {
		return food.getDefaultPrice () / (scarcity);
	}
}
