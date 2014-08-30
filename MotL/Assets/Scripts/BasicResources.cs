using UnityEngine;
using System.Collections;

public abstract class BasicResources {
	protected float defaultPrice = 1.00f;
	protected int resourceID;

	public float getDefaultPrice() {
		return defaultPrice;
	}

	public int getResourceID() {
		return resourceID;
	}
}

public class IronOre : BasicResources {
	public IronOre() {
		resourceID = MasterClass.IRON_ORE_ID;
	}
}
public class Wheat : BasicResources {
	public Wheat() {
		resourceID = MasterClass.WHEAT_ID;
	}
}
public class Wood : BasicResources {
	public Wood() {
		resourceID = MasterClass.WOOD_ID;
	}
}
public class Rubies : BasicResources {
	public Rubies() {
		resourceID = MasterClass.RUBIES_ID;
	}
}
