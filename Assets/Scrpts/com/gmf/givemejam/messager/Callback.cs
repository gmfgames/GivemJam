/// <summary>
/// Método principal que envia os eventos aos ouvintes.
/// 
/// <para name="message">Classe que implementa <code>IMessage</code> com as informacoes da mensagem</para>
/// </summary>
public delegate void Callback<T>(T message) where T:Message;