using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PostScoreData : MonoBehaviour
{

    public string Username;
    public int Score;

    void Start() 
    {
        Username = "Keegan";
        Score = 0;

        Application.quitting += () => SendScore(Username, Score);
        Debug.Log("Post score subscribed to application quit event.");
    }

    void Update()
    {
        Score += 1;
    }

    public void SendScore(string username, int score)
    {
        StartCoroutine(PostScore(username, score));
    }

    private IEnumerator PostScore(string username, int score)
    {
        string PostUrl = "http://localhost/340Scripts/insertScore.php";

        WWWForm form = new WWWForm();

        form.AddField("userPost", Username);
        form.AddField("scorePost", Score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(PostUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error posting score: " + www.error);
            }
            else
            {
                Debug.Log("Score posted successfully" + "\nUser: " + Username + " Score: " + Score);
            }
        }
    }
}
