using UnityEngine;
using System.Collections;

public abstract class Village {
	// Resources
	protected float [] food = new float[MasterClass.NUM_FOOD];
	protected float MAX_FOOD = 4500.0f;
	protected float [] tools = new float[MasterClass.NUM_TOOLS];
	protected float MAX_TOOLS = 100.0f;
	protected float medicine;
	protected float MAX_MEDS = 300.0f;
	protected float happiness = 95.00f;
	//protected float CONSUMPTION_FACTOR; // Will be equivalent of current population/ max population

	// Village Type
	protected int type;

	// Population
	protected float population = 1500.0f;
	protected float POP_MAX = 2000.0f;
	protected float DEATH_RATE;
	protected float BIRTH_RATE;

	// Getter Methods/ Default methods that exist already in each village
	public float getType() {return type;}
	public float getPopulation(){return population;}
	public float [] getFood(){return food;}
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
		setDefaultResources ();
	}
	private void setDefaultResources() {
		food [MasterClass.BREAD_ID] = 9000f;

	}
	public override void createResources() {

	}
	public override void consumeResources() {
		//if(!(food[MasterClass.BREAD_ID] <= 0))
		food[MasterClass.BREAD_ID] -= MasterClass.BREAD.getConsumptionRate() *((float)population / (float)POP_MAX)*MasterClass.timeAmount;
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

