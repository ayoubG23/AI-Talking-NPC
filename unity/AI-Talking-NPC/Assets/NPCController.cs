using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class NPCController : MonoBehaviour
{
    // Input field where player types
    public TMP_InputField playerInput;

    // Text where AI response appears
    public TextMeshProUGUI dialogueText;

    // Backend API URL
    private string apiUrl =
        "http://127.0.0.1:8000/chat";

    // Called automatically when button clicked
    public void SendMessage()
    {
        // Get player text
        string message = playerInput.text;

        // Start HTTP request coroutine
        StartCoroutine(SendMessageToAI(message));
    }

    // Coroutine for API request
    IEnumerator SendMessageToAI(string message)
    {
        // Create JSON body
        string json =
            "{\"message\":\"" + message + "\"}";

        // Convert string to bytes
        byte[] bodyRaw =
            Encoding.UTF8.GetBytes(json);

        // Create POST request
        UnityWebRequest request =
            new UnityWebRequest(apiUrl, "POST");

        // Attach JSON data
        request.uploadHandler =
            new UploadHandlerRaw(bodyRaw);

        // Receive response
        request.downloadHandler =
            new DownloadHandlerBuffer();

        // Set content type
        request.SetRequestHeader(
            "Content-Type",
            "application/json"
        );

        // Wait for backend response
        yield return request.SendWebRequest();

        // Success case
        if (request.result ==
            UnityWebRequest.Result.Success)
        {
            // Get backend response
            string response =
                request.downloadHandler.text;

            // Show response in UI
            dialogueText.text = response;
        }
        else
        {
            // Error message
            dialogueText.text =
                "Connection Error";
        }
    }
}