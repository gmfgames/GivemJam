/// <summary>
// Messenger.cs v1.0 by Magnus Wolffelt, magnus.wolffelt@gmail.com
//
// Inspired by and based on Rod Hyde's Messenger:
// http://www.unifycommunity.com/wiki/index.php?title=CSharpMessenger
//
// This is a C# messenger (notification center). It uses delegates
// and generics to provide type-checked messaging between event producers and
// event consumers, without the need for producers or consumers to be aware of
// each other. The major improvement from Hyde's implementation is that
// there is more extensive error detection, preventing silent bugs.
//
// Usage example:
// Messenger<float>.AddListener("myEvent", MyEventHandler);
// ...
// Messenger<float>.Broadcast("myEvent", 1.0f);
/// </summary>
  
using System;
using System.Collections.Generic;
 
/// <summary>
/// Tipo de envio que o <code>MessageDispatcher</code> irá tentar executar para enviar a mensagem.
/// </summary>
public enum DispatcherMode 
{
	/// <summary>
	/// Se não ouvir nenhum ouvinte registro para o evento o <code>MessageDispatcher</code> não envia a mensagem e não
	/// gera erro.
	/// </summary>
	DONT_REQUIRE_LISTENER,
	/// <summary>
	/// Se não ouvir nenhum ouvinte registro para o evento o <code>MessageDispatcher</code> gera um erro.
	/// </summary>
	REQUIRE_LISTENER,
}

/// <summary>
/// Classe utilizada para adicionar, remover e enviar mensagens.
/// </summary>
static public class MessageDispatcher
{
	private static Dictionary<string, Delegate> eventTable = MessengerInternal.eventTable;
 
	/// <summary>
	/// Adiciona um ouvinte a um tipo de event.
	/// </summary>
	/// <param name='eventType'>
	/// Tipo de evento ao qual o ouvinte será adicionado.
	/// </param>
	/// <param name='handler'>
	/// Método que será chamado quando a mensagem for disparada.
	/// </param>
	static public void AddListener<T>(String eventType, Callback<T> handler)where T:Message
	{
		MessengerInternal.OnListenerAdding(eventType, handler);
		eventTable[eventType] = (Callback<T>) eventTable[eventType] + handler;
	}
 
	/// <summary>
	/// Remove um ouvinte a um tipo de event.
	/// </summary>
	/// <param name='eventType'>
	/// ipo de evento ao qual o ouvinte será removido.
	/// </param>
	/// <param name='handler'>
	/// Método que deixara de ouvir o evento.
	/// </param>
	static public void RemoveListener<T>(string eventType, Callback<T> handler) where T:Message
	{
		MessengerInternal.OnListenerRemoving(eventType, handler);	
		eventTable[eventType] = (Callback<T>)eventTable[eventType] - handler;
		MessengerInternal.OnListenerRemoved(eventType);
	}
 
	/// <summary>
	/// Dispara uma mensagem. Se não houver nenhum ouvinte para esse tipo de mensagem o <code>MessageDispatcher</code>
	/// ira disparar um erro.
	/// </summary>
	/// <param name='message'>
	/// Um classe do tipo <code>Message</code> com um tipo definido.
	/// </param>
	static public void Broadcast<T>(T message) where T:Message
	{
		sendBroadcast<T>(message, MessengerInternal.DEFAULT_MODE);
	}
 
	/// <summary>
	/// Dispara uma mensagem.
	/// </summary>
	/// <param name='message'>
	/// Um classe do tipo <code>Message</code> com um tipo definido.
	/// </param>
	/// <param name='mode'>
	/// Modo como o <code>MessageDispatcher</code> tentará enviar a mensagem.
	/// </param>
	static public void Broadcast<T>(T message, DispatcherMode mode)where T:Message
	{
		sendBroadcast<T>(message, mode);
	}
	
	static private void sendBroadcast<T>(T message, DispatcherMode mode)where T:Message
	{
		MessengerInternal.OnBroadcasting(message.type, mode);
		Delegate d;
		if (eventTable.TryGetValue(message.type, out d)) 
		{
			Callback<T> callback = d as Callback<T>;
			if (callback != null)
				
				callback(message);
			
			 else 
				
				throw MessengerInternal.CreateBroadcastSignatureException(message);			
		}
	}
	
	/// <summary>
	/// Reinicia o gerenciador de messsagens apagando todas as escutas.
	/// </summary>
	static public void Restart()
	{
		eventTable.Clear();
		MessengerInternal.Restart();
	}
}


static internal class MessengerInternal
{
	static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
	
	static public readonly DispatcherMode DEFAULT_MODE = DispatcherMode.REQUIRE_LISTENER;
 
	static public void OnListenerAdding(string eventType, Delegate listenerBeingAdded)
	{
		if (!eventTable.ContainsKey(eventType)) 
		
			eventTable.Add(eventType, null);		
 
		Delegate d = eventTable[eventType];
		if (d != null && d.GetType() != listenerBeingAdded.GetType()) 
			
			throw new ListenerException(string.Format("Attempting to add listener with inconsistent signature for " +
				"event type {0}. Current listeners have type {1} and listener being added has type {2}", 
				eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
		
	}
 
	static public void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved) 
	{
		if (eventTable.ContainsKey(eventType))
		{
			Delegate d = eventTable[eventType];
 
//			if (d == null) 
//				
//				throw new ListenerException(string.Format("Attempting to remove listener with for event type {0}" +
//				 	"but current listener is null.", eventType));
//			
//			else if (d.GetType() != listenerBeingRemoved.GetType()) 
//				throw new ListenerException(string.Format("Attempting to remove listener with inconsistent " +
//					"signature for event type {0}. Current listeners have type {1} and listener being removed has " +
//					"type {2}", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
			
		} 
//		else
//		
//			throw new ListenerException(string.Format("Attempting to remove listener for type {0} but Messenger" +
//			 	"doesn't know about this event type.", eventType));	
	}
 
	static public void OnListenerRemoved(string eventType)
	{
		if (eventTable[eventType] == null) 
			
			eventTable.Remove(eventType);		
	}
 
	static public void OnBroadcasting(string eventType, DispatcherMode mode) 
	{
		if (mode == DispatcherMode.REQUIRE_LISTENER && !eventTable.ContainsKey(eventType)) 
			
			throw new MessengerInternal.BroadcastException(string.Format("Broadcasting message {0} but no listener " +
				"found.", eventType));		
	}
 
	static public BroadcastException CreateBroadcastSignatureException(Message message) 
	{
		return new BroadcastException(string.Format("Broadcasting message {0} but listeners have a different" +
		 	"signature than the broadcaster.", message.type));
	}
	
	static public void Restart()
	{
		eventTable.Clear();
	}
 
	public class BroadcastException : Exception
	{
		public BroadcastException(string msg)
			: base(msg) 
		{
		}
	}
 
	public class ListenerException : Exception 
	{
		public ListenerException(string msg)
			: base(msg)
		{
		}
	}
}
 
