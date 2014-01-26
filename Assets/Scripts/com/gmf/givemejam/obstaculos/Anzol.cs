using UnityEngine;
using System.Collections;

public class Anzol : Obstaculo {
	protected override void OnPause(bool isPaused){}

	public float returnSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if(isDone){
			rigidbody2D.velocity = new Vector2(0, returnSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D _collider){
		PlayerHealth player = _collider.GetComponent<PlayerHealth>();
		BonusFish fish = player.Damage().GetComponent<BonusFish>();
		fish.Follow(this.transform);
		BeDone();
	}
}
