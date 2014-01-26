using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BonusFish : FlipableObject {

	protected override void OnPause (bool isPaused){}

	public Transform target;
	public float speed = 3f;
	public float safeDistance;

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
		}
	}

	// Use this for initialization
	void Start () {
		//Fishes start needing help
		fishState = FishState.Waiting;

		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		if(fishState == FishState.Following){
			if(Vector3.Distance(transform.position, target.position) > safeDistance){
				Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
				rigidbody2D.velocity = new Vector2(direction.x * speed, direction.y * speed);
			}else{
				rigidbody2D.velocity = Vector2.zero;
			}
		}
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
