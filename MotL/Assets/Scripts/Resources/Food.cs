using UnityEngine;
using System.Collections;

public abstract class Food {
	protected static float decayRate = 1.00f;
	protected static float defaultPrice = 1.00f;
	protected static float foodValue = 5.00f;
	protected static float consumptionRate = 1.00f;
	protected static int foodID;

	public static float getConsumptionRate() {
		return consumptionRate;
	}
	public static float getDecayRate() {
		return decayRate;
	}
	public static float getDefaultPrice() {
		return defaultPrice;
	}
	public static float getFoodValue() {
		return foodValue;
	}
	public static int getFoodID() {
		return foodID;
	}
}

public class Bread : Food {

	public Bread() {
		foodID = MasterClass.BREAD_ID;
		decayRate = 0.4f;
		consumptionRate = 0.4f;
	}
}
public class Fish : Food {
	public Fish() {
		foodID = MasterClass.FISH_ID;
	}
}
public class Potato : Food {
	public Potato() {
		foodID = MasterClass.POTATO_ID;
	}
}
public class Cabbages : Food {
	public Cabbages() {
		foodID = MasterClass.CABBAGE_ID;
	}
}
public class Meat : Food {
	public Meat() {
		foodID = MasterClass.MEAT_ID;
	}
}