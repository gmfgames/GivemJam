using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent(typeof(PlayerMove))]
public class PlayerBubbleEmitter : MonoBehaviourExtends {

	public ParticleSystem emitterLeft;
	public ParticleSystem emitterRight;

	public override void OnPause(bool isPaused){
	
	}

	public void LeftEmit ()
	{
		if(!isPaused && isEnabled){
			ParticleSystem particle = Instantiate(emitterRight, transform.position, Quaternion.identity) as ParticleSystem;
			Destroy(particle.gameObject, emitterLeft.duration);
		}
	}
	
	public void RightEmit ()
	{
		if(!isPaused && isEnabled){
			ParticleSystem particle = Instantiate(emitterLeft, transform.position, Quaternion.identity) as ParticleSystem;
			Destroy(particle.gameObject, emitterRight.duration);
		}

	}



}
