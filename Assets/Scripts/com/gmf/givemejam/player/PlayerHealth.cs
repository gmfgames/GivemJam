using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerHealth : MonoBehaviourExtends {
	protected override void OnPause (bool isPaused){}

	private List<Transform> fishList;

	public int Life{
		get{ return fishList.Count; }
	}

	public void Damage(){
		if(Life > 1){
			//TODO zueiras do bagulho de remover life
		}else{
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
