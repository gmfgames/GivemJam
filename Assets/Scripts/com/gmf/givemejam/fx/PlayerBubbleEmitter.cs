using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent(typeof(PlayerMove))]
public class PlayerBubbleEmitter : MonoBehaviourExtends {

	public float threshould = .3f;
	public ParticleSystem emitterLeft;
	public ParticleSystem emitterRight;

	public TapGesture leftButton;
	public TapGesture rightButton;

	public override void onPause(bool isPaused){
	
	}
	
	// Use this for initialization
	void Awake () {
		if(leftButton){
			leftButton.StateChanged += LeftButtonPress;
		}else
			throw new UnityException("O botao esquerdo de movimentaçao do personagem nao esta configurado.");
		
		if(rightButton){
			rightButton.StateChanged += RightButtonPress;

		}else
			throw new UnityException("O botao direito de movimentaçao do personagem nao esta configurado.");
	}

	void LeftButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled && e.State == Gesture.GestureState.Began){
			ParticleSystem particle = Instantiate(emitterRight, transform.position, Quaternion.identity) as ParticleSystem;
			Destroy(particle.gameObject, emitterLeft.duration);
		}
	}
	
	void RightButtonPress (object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if(!isPaused && isEnabled && e.State == Gesture.GestureState.Began){
			ParticleSystem particle = Instantiate(emitterLeft, transform.position, Quaternion.identity) as ParticleSystem;
			Destroy(particle.gameObject, emitterRight.duration);
		}

	}



}
