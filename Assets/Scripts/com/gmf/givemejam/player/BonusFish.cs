using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BonusFish : TrackingObject {

	protected override void OnPause (bool isPaused){}

	protected Animator animator;


	public enum FishState{
		Waiting,
		Following,
		Dying
	};

	private FishState _fishState;

	public FishState fishState{
		get { return _fishState; }
		set { 
			_fishState = value;
			if(fishState == FishState.Following)
				IsTracking = true;
			else
				IsTracking = false;
		}
	}

	// Use this for initialization
	void Start () {
		//Fishes start needing help
		fishState = FishState.Waiting;

		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(fishState == FishState.Waiting){
			PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
			if(playerHealth != null){
				playerHealth.AddFish(this);
				fishState = FishState.Following;
				animator.SetTrigger("Rescue");
			}
		}
	}
}
