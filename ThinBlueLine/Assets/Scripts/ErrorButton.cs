using UnityEngine;
using System.Collections;

public class ErrorButton : MonoBehaviour {

	public void ClickClose()
    {
        Destroy(gameObject);
    }
}
