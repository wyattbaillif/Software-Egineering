using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreLoader : MonoBehaviour
{
	// Start is called before the first frame update
	IEnumerator Start()
	{
		string url = "http://localhost/340Scripts/USER_SCORE.php"; // replace with the URL of the website containing the string you want to fetch
		using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
		{
			yield return webRequest.SendWebRequest();

			if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
				webRequest.result == UnityWebRequest.Result.ProtocolError)
			{
				Debug.LogError("Error: " + webRequest.error);
			}
			else
			{
				Debug.Log("Fetched string: " + webRequest.downloadHandler.text);
			}
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
