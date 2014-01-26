using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerHealth : MonoBehaviourExtends {
	protected override void OnPause (bool isPaused){}

	private List<Transform> fishList;

	/// <summary>
	/// Gets the life of the player (The number of fish te player has).
	/// </summary>
	/// <value>The life.</value>
	public int Life{
		get{ return fishList.Count; }
	}


	/// <summary>
	/// Damages the enemy (takes away one fish and returns the fish taken away)
	/// </summary>
	public Transform Damage(){
		if(Life > 1){
			BonusFish fish = fishList.Last().GetComponent<BonusFish>();
			fish.fishState = BonusFish.FishState.Dying;
			fishList.Remove(fish.transform);
			return fish.transform;
		}else{
			Debug.Log("Sifu!");
			return this.transform;
			//TODO gameover
		}
	}

	public void AddFish(BonusFish fishzinho){
		fishzinho.target = fishList.Last();
		fishList.Add(fishzinho.transform);
	}

	// Use this for initialization
	void Start () {
		fishList = new List<Transform>();
		fishList.Add(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
