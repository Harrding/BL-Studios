using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {

	public GameObject target;
	private NavMeshAgent navComponent;


	// Use this for initialization
	void Start () {
		navComponent = this.transform.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
		{
			navComponent.SetDestination(target.transform.position);
		}
	}
}
