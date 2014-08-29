using UnityEngine;
using System.Collections;

public abstract class Village {

	// Resources
	protected int [] food = new int[MasterClass.NUM_FOOD];
	protected int MAX_FOOD;
	protected int [] tools = new int[MasterClass.NUM_TOOLS];
	protected int MAX_TOOLS;
	protected int [] medicine = new int[MasterClass.NUM_MEDS];
	protected int MAX_MEDS;

	// Village Type
	protected int type;

	// Population
	protected int population;
	protected int POP_MAX;
	protected float DEATH_RATE;
	protected float BIRTH_RATE;

	// Getter Methods/ Default methods that exist already in each village
	public int getType() {return type;}
	public int getPopulation(){return population;}
	public int [] getFood(){return food;}

	// Abstract methods that are required in each village for each village to exist
	public abstract void createResources();
	public abstract void consumeFoodResources();
	public abstract void consumeMedicineResources();
	public abstract void useTools();
}

public class FarmingVillage : Village{
	public FarmingVillage () {
		type = MasterClass.FARMING_ID;
		POP_MAX = 1500;
		DEATH_RATE = 1.0f;
		BIRTH_RATE = 1.0f;
		population = 300;
		setDefaultResources ();
		setMaxResources ();
	}
	private void setDefaultResources() {
		for (int i = 0; i < food.Length; i++) {
			food[i] = MasterClass.STARTING_FOOD + 300;
		}

		for(int i = 0; i < medicine.Length; i++) {
			medicine[i] = MasterClass.STARTING_MEDICINE;
		}
		tools [MasterClass.HOE_ID] = MasterClass.STARTING_TOOLS;
	}
	private void setMaxResources() {
		MAX_FOOD = 10000;
		MAX_MEDS = 3000;
		MAX_TOOLS = 1000;
	}
	public override void createResources() {
		
	}
	public override void consumeFoodResources() {

	}
	public override void consumeMedicineResources(){

	}
	public override void useTools() {

	}
}

