using UnityEngine;
using System.Collections;

public class TrackingObject : FlipableObject {
	protected override void OnPause (bool isPaused){}

	/// <summary>
	/// The object this tracker will follow
	/// </summary>
	public Transform target;

	/// <summary>
	/// The min distance (relative to the target) at which the tracker will stop following
	/// </summary>
	public float minDistance;

	/// <summary>
	/// The speed at which the tracker will follow the target
	/// </summary>
	public float speed;

	private bool _isTracking;
	public bool IsTracking{
		get{ return _isTracking; }
		protected set { _isTracking = value; }
	}

	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if(IsTracking){
			if(Vector3.Distance(transform.position, target.position) > minDistance){
				Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
				rigidbody2D.velocity = new Vector2(direction.x * speed, direction.y * speed);
			}else{
				rigidbody2D.velocity = Vector2.zero;
			}
		}
	}

	protected override void Start(){
	}
}
