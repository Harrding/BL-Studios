using UnityEngine;
using System.Collections;

public abstract class Village {

	// Resources
	protected int [] food = new int[MasterClass.NUM_FOOD];
	protected int MAX_FOOD = 4500;
	protected int [] tools = new int[MasterClass.NUM_TOOLS];
	protected int MAX_TOOLS = 100;
	protected int medicine;
	protected int MAX_MEDS = 300;
	protected float happiness = 95.00f;
	//protected float CONSUMPTION_FACTOR; // Will be equivalent of current population/ max population

	// Village Type
	protected int type;

	// Population
	protected int population = 1500;
	protected int POP_MAX = 2000;
	protected float DEATH_RATE;
	protected float BIRTH_RATE;

	// Getter Methods/ Default methods that exist already in each village
	public int getType() {return type;}
	public int getPopulation(){return population;}
	public int [] getFood(){return food;}
	public float getHappiness() {return happiness;}

	// Abstract methods that are required in each village for each village to exist
	public abstract void createResources();
	public abstract void consumeResources();
	public abstract void useTools();
}
public class TestVillage:Village{

	public TestVillage(){
		type = MasterClass.TEST_ID;
		DEATH_RATE = 1.0f;
		BIRTH_RATE = 1.2f;
	}
	private void setDefaultResources() {
		food [MasterClass.BREAD_ID] = 9000;

	}
	public override void createResources() {

	}
	public override void consumeResources() {
		if(!(food[MasterClass.BREAD_ID] <= 0))
			food[MasterClass.BREAD_ID] -= (int)(Bread.getConsumptionRate() * ((float)population / POP_MAX)*MasterClass.timeAmount);
	}

	public override void useTools() {
		
	}
}
public class FarmingVillage : Village{
	public FarmingVillage () {
		type = MasterClass.FARMING_ID;
		DEATH_RATE = 1.0f;
		BIRTH_RATE = 1.2f;
		setDefaultResources ();
		setMaxResources ();
	}
	private void setDefaultResources() {

	}
	private void setMaxResources() {

	}
	public override void createResources() {
		
	}
	public override void consumeResources() {

	}

	public override void useTools() {

	}
}

