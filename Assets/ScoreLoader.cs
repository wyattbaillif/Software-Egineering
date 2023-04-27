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
                List<UserScore> userScores = new List<UserScore>();
                string responseText = webRequest.downloadHandler.text;

                // Split the response string into individual user-score strings
                string[] userScoreStrings = responseText.Split(';');

                // Parse each user-score string and add to the list
                foreach (string userScoreString in userScoreStrings)
                {
                    if (userScoreString.Length > 0)
                    {
                        string[] keyValue = userScoreString.Split('|');
                        if (keyValue.Length == 2)
                        {
                            string userName = keyValue[0].Split(':')[1];
                            int score = int.Parse(keyValue[1].Split(':')[1]);
                            UserScore userScore = new UserScore(userName, score);
                            userScores.Add(userScore);
                        }
                    }
                }

                // Sort the list in descending order based on the score
                userScores.Sort((a, b) => b.score.CompareTo(a.score));

                // Log the top three scores and their associated user names
                for (int i = 0; i < 3 && i < userScores.Count; i++)
                {
                    Debug.Log("User " + userScores[i].userName + " scored " + userScores[i].score);
                }
            }
        }
    }
}

public class UserScore
{
	public string userName;
	public int score;

	public UserScore(string name, int scr)
	{
		userName = name;
	    score = scr;
	}
}

