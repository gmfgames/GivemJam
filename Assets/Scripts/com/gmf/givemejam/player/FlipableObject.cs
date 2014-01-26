using UnityEngine;
using System.Collections;

public abstract class FlipableObject : MonoBehaviourExtends {
	protected abstract override void OnPause(bool pause);

	private bool _isFacingRight;
	public virtual bool IsFacingRight{
		get { return _isFacingRight; }
		protected set { _isFacingRight = value; }
	}

	protected virtual void Update(){
		if(IsFacingRight && rigidbody2D.velocity.x < 0)
			FlipX();
		else if(!IsFacingRight && rigidbody2D.velocity.x > 0)
			FlipX();
	}

	protected virtual void FlipX(){
		IsFacingRight = !IsFacingRight;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	protected virtual void Start(){
	}
}
