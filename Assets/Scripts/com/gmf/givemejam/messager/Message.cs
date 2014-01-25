using System;

/// <summary>
/// Classe base para todas as classes que são utilizadas como messagem pela <code>MessageDispatcher</code>.
/// </summary>
public class Message
{
	/// <summary>
	/// Tipo da mensagem que esta sendo enviada.
	/// </summary>
	public string type;
	
	/// <summary>
	///<param name="type">Tipo da mensagem. Este parametro server tambem para o <code>MessageDispatcher</code>
	///saber quais métodos chamar, ou seja, aquele métodos que adicionaram um ouvinte a esse event.</param>
	/// </summary>
	public Message(string type)
	{
		this.type = type;
	}
}
