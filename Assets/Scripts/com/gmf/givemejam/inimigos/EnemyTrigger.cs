using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

	public Inimigo inimigo;

	void OnTriggerEnter2D(Collider2D collider){
		EnemyKiller enemyKiller = collider.GetComponent<EnemyKiller>();
		if(enemyKiller && inimigo.enemyState != Inimigo.EnemyState.Done){
			Obstaculo obstaculo = collider.transform.parent.GetComponent<Obstaculo>();
			inimigo.Follow(obstaculo.transform);
			obstaculo.BeDone();
		}
	}
}
