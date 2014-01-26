using UnityEngine;
using System.Collections;

/// <summary>
/// Componente de camera que segue um alvo.
/// </summary>
public class SmoothCamera : MonoBehaviourExtends
{
	protected override void OnPause (bool isPaused){}

	/**********************************************************
	 * PROPRIEDADES
	 **********************************************************/ 
	
		/**------------------------------------------------------------
		 * PUBLICAS
		 **----------------------------------------------------------*/ 
	
		/// <summary>
		/// O tempo máxima que a camera deve demorar para atingir o alvo.
		/// </summary>
		[MultiRange(0, 1, "Tempo maxima que a camera deve levar para atingir o alvo.")]
	    public float dampTime = 0.15f;
	
		/// <summary>
		/// Velocidade em que a camera irá seguir o alvo.
		/// </summary>
		[CompactAttribute("Velocidade mínima da camera.")]
	    private Vector3 velocity = Vector3.zero;
	
		/// <summary>
		/// Alvo da camera.
		/// </summary>
	    public Transform target;
	
		/// <summary>
		/// Area de alcance da camera.
		/// </summary>
		public Rect cameraBounds;
	
		/**------------------------------------------------------------
		 * INTERNAS
		 **----------------------------------------------------------*/ 
	
		/// <summary>
		/// A posição da camera.
		/// </summary>
		protected Vector3 cameraPosition;
	
		/// <summary>
		/// A posição mínima da camera.
		/// </summary>
		protected Vector2 cameraMin;
	
		/// <summary>
		/// A posição máxima da camera.
		/// </summary>
		protected Vector2 cameraMax;
	
		/// <summary>
		/// O tamanho atual da camera.
		/// </summary>
		protected Vector2 cameraSize;
	
	/**********************************************************
	 * FUNÇÕES
	 **********************************************************/ 
	
	void Awake()
	{
		cameraMin = new Vector2(cameraBounds.xMin, cameraBounds.yMin);
		
		cameraMax = new Vector2(cameraBounds.xMax, cameraBounds.yMax);
		
		Vector3 worldMin       =  camera.ViewportToWorldPoint(new Vector3(0, 1,
			Mathf.Abs(Camera.main.transform.position.z - target.transform.position.z)));
		
		Vector3 worldMax   = camera.ViewportToWorldPoint(new Vector3(1, 0,
			Mathf.Abs(Camera.main.transform.position.z - target.transform.position.z)));
		
		cameraSize = new Vector2(Mathf.Abs(worldMax.x - worldMin.x), Mathf.Abs(worldMax.y - worldMin.y));
	}
 
    void Update () 
    {
       if (target)
       {			
	        Vector3 point 			= camera.WorldToViewportPoint(target.position);
	        Vector3 delta 			= target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
	        Vector3 destination 	= transform.position + delta;
	        cameraPosition 	= Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			
			if(cameraPosition.x < (cameraMin.x + (cameraSize.x / 2)))
				
				cameraPosition.x = (cameraMin.x + (cameraSize.x / 2));
			
			else if(cameraPosition.x > (cameraMax.x - (cameraSize.x / 2)))
				
				cameraPosition.x = (cameraMax.x - (cameraSize.x / 2));
			
			if(cameraPosition.y  < (cameraMin.y + (cameraSize.y / 2)))
				
				cameraPosition.y = (cameraMin.y + (cameraSize.y / 2));
			
			else if(cameraPosition.y > (cameraMax.y - (cameraSize.y / 2)))
				
				cameraPosition.y = (cameraMax.y - (cameraSize.y / 2));
			
			
			transform.position = cameraPosition;			
       } 
    }
	
	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(cameraBounds.center, new Vector3(cameraBounds.width, cameraBounds.height, .1f));
    }
}

