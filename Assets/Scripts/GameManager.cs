using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject canvas;
    public GameObject events;

    public GameObject startButton;
    public GameObject instructionButton;
    public GameObject creditsButton;
    public GameObject backButton;

    public GameObject titleTextBox;
    public GameObject instructionTextBox;
    public GameObject creditsTextBox;

    public GameObject backgroundImage;
    public GameObject blackBackground;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
        }
        else
        {
            Destroy(gameObject);
            Destroy(canvas);
            Destroy(events);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        DeactivateAllButtons();
        titleTextBox.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("SampleScene"));
        // Fade image out
        StartCoroutine(FadeBackgroundImage(new Color(1, 1, 1, 0), 2));
        backgroundImage.SetActive(false);
    }

    public void CreditsButton()
    {
        DeactivateAllButtons();
        titleTextBox.SetActive(false);
        backButton.SetActive(true);
        creditsTextBox.SetActive(true);
    }

    public void InstructionButton()
    {
        DeactivateAllButtons();
        titleTextBox.SetActive(false);
        backButton.SetActive(true);
        instructionTextBox.SetActive(true);
    }

    public void BackButton()
    {
        creditsTextBox.SetActive(false);
        instructionTextBox.SetActive(false);
        backButton.SetActive(false);
        ActivateMenuButtons();
        titleTextBox.GetComponent<TextMeshProUGUI>().SetText("Pearl Diver");
        titleTextBox.SetActive(true);
    }

    public void GameOver()
    {
        titleTextBox.GetComponent<TextMeshProUGUI>().SetText("Game Over");
        EndGame();
    }

    public void WinGame()
    {
        titleTextBox.GetComponent<TextMeshProUGUI>().SetText("You Win!");
        EndGame();
    }

    private void EndGame()
    {
        blackBackground.SetActive(true);
        StartCoroutine(LoadYourAsyncScene("Menu"));
        backButton.SetActive(true);
        titleTextBox.SetActive(true);
        // Fade image in
        backgroundImage.SetActive(true);
        StartCoroutine(FadeBackgroundImage(new Color(1, 1, 1, 1), 2));
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        Debug.Log("Loading " + scene);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator FadeBackgroundImage(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
        blackBackground.SetActive(false);
    }

    private void ActivateMenuButtons()
    {
        startButton.SetActive(true);
        creditsButton.SetActive(true);
        instructionButton.SetActive(true);
    }

    private void DeactivateAllButtons()
    {
        startButton.SetActive(false);
        creditsButton.SetActive(false);
        instructionButton.SetActive(false);
        backButton.SetActive(false);
    }
}
