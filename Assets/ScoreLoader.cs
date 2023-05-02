using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ScoreLoader : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoresText;
    private string scoresString;
    // URL to fetch user scores
    private const string URL = "https://csis340softwareengineers.com/USER_SCORE.php";

    // Start loading scores when the game object is enabled
    private void Start()
    {
        StartCoroutine(LoadScores());
    }

    // Coroutine to load scores from the URL
    private IEnumerator LoadScores()
    {
        // Make a web request to the URL
        using (UnityWebRequest webRequest = UnityWebRequest.Get(URL))
        {
            yield return webRequest.SendWebRequest();

            // If there was an error, log the error message
            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // Parse the user scores from the web request response
                List<UserScore> userScores = ParseUserScores(webRequest.downloadHandler.text);

                // Sort the user scores in descending order by score
                userScores.Sort((a, b) => b.score.CompareTo(a.score));

                // Log the top three scores and their associated user names
                LogTopThreeScores(userScores);
            }
        }
    }

    // Parse user scores from a semicolon-separated string
    private List<UserScore> ParseUserScores(string responseText)
    {
        List<UserScore> userScores = new List<UserScore>();
        string[] userScoreStrings = responseText.Split(';');

        foreach (string userScoreString in userScoreStrings)
        {
            // Ignore empty strings
            if (!string.IsNullOrEmpty(userScoreString))
            {
                string[] keyValue = userScoreString.Split('|');

                // Check that the key-value pair contains both user name and score fields
                if (keyValue.Length == 2 && keyValue[0].StartsWith("User:") && keyValue[1].StartsWith("Score:"))
                {
                    // Extract the user name and score fields and add a new UserScore object to the list
                    string userName = keyValue[0].Substring("User:".Length);
                    float score;

                    // Try to parse the score field as an integer
                    if (float.TryParse(keyValue[1].Substring("Score:".Length), out score))
                    {
                        userScores.Add(new UserScore(userName, score));
                    }
                }
            }
        }

        return userScores;
    }

    // Log the top three scores and their associated user names
    private void LogTopThreeScores(List<UserScore> userScores)
    {
        const int numScoresToLog = 3;
        int numScores = Mathf.Min(numScoresToLog, userScores.Count);

        for (int i = 0; i < numScores; i++)
        {
            scoresString+=scoresText.text=$"{userScores[i].userName} scored {userScores[i].score}\n";
            Debug.Log($"User {userScores[i].userName} scored {userScores[i].score}");
        }
        scoresText.text=scoresString;
    }
}

// Class representing a user score, consisting of a user name and a score value
public class UserScore
{
    public string userName;
    public float score;

    public UserScore(string name, float scr)
    {
        userName = name;
        score = scr;
    }
}