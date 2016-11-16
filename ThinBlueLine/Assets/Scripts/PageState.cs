using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PageState : MonoBehaviour {

	public static PageState Instance = null;
	
	public int currentPage = 0;
	
	void Awake()
	{
		
		if (Instance == null)
		{
			Instance = this;
		
			currentPage = 0;
		}
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);
	}
}
