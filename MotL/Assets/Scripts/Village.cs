using UnityEngine;
using System.Collections;

public abstract class Village {

	protected int [] food = new int[MasterClass.NUM_FOOD];
	protected int MAX_FOOD;
	protected int [] tools = new int[MasterClass.NUM_TOOLS];
	protected int MAX_TOOLS;

	protected int type;
	protected int population;
	protected int POP_MAX;
	protected float DEATH_RATE;
	protected float BIRTH_RATE;

	public string getType() {return type;}
	public int getPopulation(){return population;}
	public int [] getFood(){return food;}

	public abstract void createResources();
	public abstract void consumeFoodResources();
	public abstract void consumeMedicineResources();
}

public class FarmingVillage : Village{
	public FarmingVillage () {
		type = MasterClass.FARMING_ID;
		POP_MAX = 1500;
		DEATH_RATE = 1.0f;
		BIRTH_RATE = 1.0f;
		population = 300;
		setDefaultResources ();
	}
	private void setDefaultResources() {
		for (int i = 0; i < food.Length; i++) {
			food[i] = MasterClass.STARTING_FOOD + 300;
		}
	}
}

