using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveBomb : MonoBehaviour , IDragHandler   , IPointerDownHandler , IPointerUpHandler
{
	[SerializeField]
	Text countBomb; 

	[SerializeField]
	GameObject moveBoosterBomb;

 
	[SerializeField]
	public RectTransform mainCanvas;

	Vector3 convertationResult;

	Vector2 deltaY = new Vector2(0 , 150f);  

	void Start()
	{
		ControllerGamingPerformance.onUpdateCountBomb += UpdateCountBomb;
 	}
 

	public void OnDrag(PointerEventData eventData)
	{ 
		if (!ControllerGamingPerformance.CheckFinishedBomb)
			return;
		
			Vector2 mousePos = Input.mousePosition;

			RectTransformUtility.ScreenPointToWorldPointInRectangle (mainCanvas, mousePos + deltaY, Camera.main, out convertationResult);

			moveBoosterBomb.transform.position = convertationResult; 
 	} 

	public void OnPointerDown(PointerEventData eventData)
	{ 
		if (!ControllerGamingPerformance.CheckFinishedBomb)
			return;
		
			Vector2 mousePos = Input.mousePosition;

			RectTransformUtility.ScreenPointToWorldPointInRectangle (mainCanvas, mousePos + deltaY, Camera.main, out convertationResult);

			moveBoosterBomb.transform.position = convertationResult;

			moveBoosterBomb.SetActive (true);
 	} 

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!ControllerGamingPerformance.CheckFinishedBomb)
			return;
		
			ControllerBomb.UseBomb (moveBoosterBomb.transform.position);

			moveBoosterBomb.transform.localPosition = Vector2.one;

			moveBoosterBomb.SetActive (false); 		 

			ControllerGamingPerformance.MinusCountBomb ();
 	}

	void UpdateCountBomb()
	{
		countBomb.text = ControllerGamingPerformance.GetCountBomb.ToString (); 
	}
 
}