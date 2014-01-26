using UnityEngine;
using System.Collections;

/// <summary>
/// Final da fase.
/// </summary>
public class LevelEnd : MonoBehaviourExtends
{
	void OnTriggerEnter(Collision collision)
	{
		PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();

		if(player)
		{
			player.isEnabled = false;

			player.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

			Pause.instance.gameObject.SetActive(false);

			StartCoroutine(WaitPlayer());
		}
	}

	IEnumerator WaitPlayer()
	{
		yield return new WaitForSeconds(.5f);

		Application.LoadLevel(0);
	}


	#region implemented abstract members of MonoBehaviourExtends
	protected override void OnPause (bool pause)
	{

	}
	#endregion
}

