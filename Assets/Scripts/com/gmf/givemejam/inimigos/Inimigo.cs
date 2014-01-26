﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Inimigo : TrackingObject {
	protected override void OnPause (bool isPaused){}
	private Animator animator;

	public enum EnemyState{
		Idle,
		Charging,
		Done
	}
	public EnemyState enemyState = EnemyState.Idle;



	/// <summary>
	/// The standard direction the enemy will move when it's got nothing better to do.
	/// </summary>
	public Vector2 standardDirection;

	protected override void Start(){
		IsTracking = false;
		animator = GetComponent<Animator>();
	}

	protected override void Update ()
	{
		base.Update ();
		if(enemyState == EnemyState.Done && collider2D){
			Destroy(collider2D);
		}
	}

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if(!IsTracking){
			rigidbody2D.velocity = standardDirection;
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		PlayerHealth player = collider.gameObject.GetComponent<PlayerHealth>();
		if(player && enemyState == EnemyState.Idle){
			target = player.transform;
			IsTracking = true;
			animator.SetBool("IsAttacking", true);
			enemyState = EnemyState.Charging;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		PlayerHealth player = collider.gameObject.GetComponent<PlayerHealth>();
		if(player && enemyState == EnemyState.Charging){
			IsTracking = false;
			target = null;
			animator.SetBool("IsAttacking", false);
			enemyState = EnemyState.Idle;
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		PlayerHealth player = collider.gameObject.GetComponent<PlayerHealth>();
		if(player && enemyState == EnemyState.Charging){
			Follow(player.Damage());
		}
	}

	public void Follow(Transform lastTarget){
		target = lastTarget;
		speed *= 4;
		enemyState = EnemyState.Done;
		IsTracking = true;
	}
}
