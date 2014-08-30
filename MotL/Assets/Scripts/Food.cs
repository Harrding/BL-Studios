using UnityEngine;
using System.Collections;

public abstract class Food {
	protected float decayRate = 1.00f;
	protected float defaultPrice = 1.00f;
	protected float foodValue = 5.00f;
	protected int foodID;

	public float getDecayRate() {
		return decayRate;
	}
	public float getDefaultPrice() {
		return defaultPrice;
	}
	public float getFoodValue() {
		return foodValue;
	}
	public int getFoodID() {
		return foodID;
	}
}

public class Bread : Food {

	public Bread() {
		foodID = MasterClass.BREAD_ID;
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