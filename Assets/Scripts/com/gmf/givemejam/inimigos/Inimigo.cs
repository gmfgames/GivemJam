using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Inimigo : TrackingObject {
	protected override void OnPause (bool isPaused){}
	private Animator animator;

	/// <summary>
	/// The standard direction the enemy will move when it's got nothing better to do.
	/// </summary>
	public Vector2 standardDirection;

	protected override void Start(){
		IsTracking = false;
		animator = GetComponent<Animator>();
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if(!IsTracking){
			rigidbody2D.velocity = standardDirection;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		PlayerHealth player = collider.gameObject.GetComponent<PlayerHealth>();
		if(player){
			target = player.transform;
			IsTracking = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		PlayerHealth player = collider.gameObject.GetComponent<PlayerHealth>();
		if(player){
			IsTracking = false;
		}
	}
}
