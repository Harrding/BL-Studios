using UnityEngine;
using System.Collections;

public abstract class Village {

	protected int [] food = new int[MasterClass.NUM_FOOD];
	protected int MAX_FOOD;

	protected string type;
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

public class AgriVillage : Village{
	public AgriVillage () {
		type = "Agriculture";
		POP_MAX = 1500;
		DEATH_RATE = 1.0f;
		BIRTH_RATE = 1.0f;
		population = 300;
		setDefaultResources ();
	}
	private void setDefaultResources() {
		for (int i = 0; i < food.Length; i++) {
			food[i] = 4500/ food.Length;
		}
	}
}