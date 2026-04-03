using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DialogueSceneTransition : MonoBehaviour
{
    public string nextSceneName;     // Name of the next scene to load
    public Image fadeImage;          // UI Image used for fade effect
    public float fadeDuration = 1f;  // How long the fade takes

    private bool dialogueFinished = false;   // Set this true when all dialogue is done
    private bool waitingForFinalPress = false;
    private bool isTransitioning = false;

    void Update()
    {
        if (dialogueFinished)
        {
            // Wait for the player to press Space after dialogue ends
            if (!waitingForFinalPress && Input.GetKeyDown(KeyCode.Space))
            {
                waitingForFinalPress = true;  // Wait for next Space to start transition
            }
            else if (waitingForFinalPress && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(TransitionToNextScene());
            }
        }
    }

    // Call this method when all dialogue is finished
    public void OnDialogueFinished()
    {
        dialogueFinished = true;
    }

    IEnumerator TransitionToNextScene()
    {
        isTransitioning = true;
        float timer = 0f;
        Color color = fadeImage.color;

        Debug.Log("B");
        while (timer < fadeDuration)
        {
            Debug.Log("A");
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
