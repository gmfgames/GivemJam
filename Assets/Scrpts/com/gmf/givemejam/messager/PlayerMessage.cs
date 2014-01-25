using UnityEngine;

public class PlayerMessage : Message
{
	/// <summary>
	/// Tipo de mensagem enviada quando o player pula.
	/// </summary>
	public const string ON_JUMP = "onJump";
	
	/// <summary>
	/// Tipo de mensagem enviada quando o player cai de uma altura maior do que a permitida.
	/// </summary>
	public const string ON_FALL = "onFall";
	
	/// <summary>
	/// Tipo de mensagem enviada quando o player morre.
	/// </summary>
	public const string ON_DEATH = "onDeath";
	
	/// <summary>
	/// Posição atual do player
	/// </summary>
	public Vector3 position;
	
	/// <summary>
	/// <see cref="Vector3"/> com as informações de movimento do player: valocidade horizontal e vertical.
	/// </summary>
	public Vector3 moveDirection;
	
	/// <summary>
	/// Posição do player quando ele começou a cair. Se esse valor for zero quer dizer que o player esta
	/// colidindo com o chão.
	/// </summary>
	public float fallYPosition;	
		
	/// <summary>
	/// Initializes a new instance of the <see cref="PlataformMoveMessage"/> class.
	/// </summary>
	/// <param name='type'>
	/// Tipo de mensagem.
	/// </param>
	/// <param name='position'>
	/// Posição atual do player.
	/// </param>
	/// <param name='moveDirection'>
	/// Informações de movimento do player.
	/// </param>
	/// <param name='fallYPosition'>
	/// Posição do player quando ele começou a cair.
	/// </param>
	public PlayerMessage (string type, Vector3 position, Vector3 moveDirection, float fallYPosition): base(type)
	{		
		this.position 		= position;
		this.moveDirection 	= moveDirection;
		this.fallYPosition 	= fallYPosition;
	}
}

