using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI NamesText;
    public Image mc;
    public Image boss;
    public string[] dialogues;
    public string[] names;
    public Sprite[] McImage;
    public Sprite[] BossImage;
    public float typingSpeed = .05f;
    private int cureentDialogueIndex = 0;
    public string next;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogues.Length > 0)
        {
            StartCoroutine(DisplayDialogue());
        }
    }

    IEnumerator DisplayDialogue()
    {

        for (int i = 0; i < dialogues.Length; i++) 
        {
            string dialogue = dialogues[i];
            
            dialogueText.text = ""; // Clear the text each time before showing new dialogue
            NamesText.text = names[i];
            if (McImage[i] != null) 
            {
                mc.sprite = McImage[i];
            }
            if (BossImage[i] != null)
            {
                boss.sprite = BossImage[i];
            }
            foreach (char letter in dialogue)
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed); // Type out the dialogue one character at a time
            }

            // Wait for user to press a key before moving to the next dialogue (optional)
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        // Load the next scene after all dialogue lines have been shown
        SceneManager.LoadScene(next);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}