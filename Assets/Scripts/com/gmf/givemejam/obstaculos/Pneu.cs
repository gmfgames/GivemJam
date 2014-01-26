using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Pneu : MonoBehaviourExtends {

	protected override void OnPause (bool isPaused){}

	public float speed = 5f;

	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){
		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, speed);
	}

	void OnCollisionEnter2D(Collision2D collider){
		Terreno terreno = collider.gameObject.GetComponent<Terreno>();
		if(terreno){
			speed = -speed;
		}
	}
}
