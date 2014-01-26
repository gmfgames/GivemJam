using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Pneu : Obstaculo {

	protected override void OnPause (bool isPaused){}

	public float speed = 5f;


	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void FixedUpdate(){
		if(!isDone)
			rigidbody2D.velocity = new Vector2(0, speed);
		else
			rigidbody2D.velocity = new Vector2(0, Mathf.Abs(speed));
	}

	void OnCollisionEnter2D(Collision2D _collider){
		animator.SetTrigger("Bounce");
		Terreno terreno = _collider.gameObject.GetComponent<Terreno>();
		if(terreno && !isDone){
			speed = -speed;
		}
	}

	void OnCollisionStay2D(Collision2D _collider){
		Terreno terreno = _collider.gameObject.GetComponent<Terreno>();
		if(terreno && isDone && speed < 0){
			if(collider2D){
				Destroy(collider2D);
			}
		}
	}
}
