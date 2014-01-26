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

	public FishState _fishState;

	public FishState fishState{
		get { return _fishState; }
		set { 
			_fishState = value;
			if(fishState == FishState.Following)
				IsTracking = true;
			else{
				IsTracking = false;
				if(fishState == FishState.Dying)
					transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
			}
		}
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if(fishState == FishState.Dying){
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3);
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
