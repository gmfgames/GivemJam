using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviourExtends {
	protected override void OnPause (bool isPaused){	}

	public Inimigo inimigo;

	protected virtual void OnTriggerEnter2D(Collider2D _collider){
		EnemyKiller enemyKiller = _collider.gameObject.GetComponentInChildren<EnemyKiller>();
		if(enemyKiller != null && inimigo.enemyState != Inimigo.EnemyState.Done){
			Obstaculo obstaculo = enemyKiller.transform.parent.GetComponentInChildren<Obstaculo>();
			inimigo.Follow(obstaculo.transform);
			obstaculo.BeDone();
		}
	}
}
