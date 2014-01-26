using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviourExtends {
	protected override void OnPause(bool isPaused){}

	protected bool isDone;

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	public virtual void BeDone(){
		isDone = true;
	}
}
