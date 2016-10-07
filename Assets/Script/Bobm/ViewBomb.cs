using UnityEngine;
using System.Collections;

public class ViewBomb : MonoBehaviour 
{
	[SerializeField]
	Camera cameraMain;

	[SerializeField]
	GameObject bomb;

	void Start()
	{
		ControllerBomb.onUseBomb += Explosion;
 	}

	void Explosion(Vector3 mousePosition)
	{
		RaycastHit [] hits;
        Ray ray = cameraMain.ScreenPointToRay(mousePosition);

		bomb.SetActive (true);

        hits = Physics.RaycastAll(ray);		           

        foreach (RaycastHit h in hits)
        {
            if (h.collider.name == "Road")
            {
                bomb.transform.position = h.point;

                StartCoroutine(IExplosion());
            }
        }
 		 
	}
 
	IEnumerator IExplosion()
	{
		yield return new WaitForSeconds (0.15f);
		bomb.SetActive (false);
	}


 
}
