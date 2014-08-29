using UnityEngine;
using System.Collections;

public abstract class Food {
	protected float decayRate;
	protected float defaultPrice;
	protected float foodValue;
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
		decayRate = 1.00f;
		defaultPrice = 1.00f;
		foodValue = 5.00f;
		foodID = 0;
	}
}
public class Fish : Food {
	public Fish() {
		decayRate = 1.00f;
		defaultPrice = 1.00f;
		foodValue = 5.00f;
		foodID = 1;
	}
}
public class Potato : Food {
	public Potato() {
		decayRate = 1.00f;
		defaultPrice = 1.00f;
		foodValue = 5.00f;
		foodID = 2;
	}
}
public class Cabbages : Food {
	public Cabbages() {
		decayRate = 1.00f;
		defaultPrice = 1.00f;
		foodValue = 5.00f;
		foodID = 3;
	}
}
public class Meat : Food {
	public Meat() {
		decayRate = 1.00f;
		defaultPrice = 1.00f;
		foodValue = 5.00f;
		foodID = 4;
	}
}