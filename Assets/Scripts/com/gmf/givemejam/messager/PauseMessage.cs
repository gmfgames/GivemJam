/// <summary>
/// Mensagem disparada quando o jogo é parado ou continuado.
/// </summary>
public class PauseMessage : Message
{
	public const string ON_PAUSE_CHANGED = "onPauseChanged";
	
	/// <summary>
	/// Este valor será <code>true</code> se o jogo estiver parado e <code>false</code> se não.
	/// </summary>
	public bool paused;
	
	/// <summary>
	/// Iniciliza uma intancia da classe <see cref="PauseMessage"/>.
	/// </summary>
	/// <param name='type'>
	/// Tipo de mensagem.
	/// </param>
	/// <param name='paused'>
	/// Valor que indica se o jogo esta parado ou não.
	/// </param>
	public PauseMessage (string type, bool paused): base(type)
	{		
		this.paused = paused;
	}
}
	

