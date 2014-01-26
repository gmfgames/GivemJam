using UnityEngine;
using System.Collections;

public class Anzol : Obstaculo {
	protected override void OnPause(bool isPaused){}

	public float returnSpeed;
	public bool isAnimated;

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
		if(player){
			BonusFish fish = player.Damage().GetComponent<BonusFish>();
			fish.Follow(this.transform);
			BeDone();
		}
	}

	public override void BeDone(){
		if(isAnimated){
			Animator _animator = GetComponent<Animator>();
			_animator.SetTrigger("Attack");
			StartCoroutine(KillAnimator(.4f));
		}
		base.BeDone();
	}

	IEnumerator KillAnimator(float delay){
		for(float f = 0; f <= delay; f += Time.deltaTime){
			yield return null;
		}
		Animator _animator = GetComponent<Animator>();
		_animator.enabled = false;
	}
}
