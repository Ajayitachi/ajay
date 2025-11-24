using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button muteButton;
    public Button quitButton;

    public string levelSceneName = "GameScene"; // Change this to your level scene name

    private bool isMuted = false;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        muteButton.onClick.AddListener(ToggleMute);
        quitButton.onClick.AddListener(QuitGame);

        // Load saved mute state
        if (PlayerPrefs.HasKey("Muted"))
            isMuted = PlayerPrefs.GetInt("Muted") == 1;

        AudioListener.volume = isMuted ? 0 : 1;
        UpdateMuteText();
    }

    void PlayGame()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateMuteText();
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit pressed"); // works only in build
    }

    void UpdateMuteText()
    {
        Text txt = muteButton.GetComponentInChildren<Text>();
        txt.text = isMuted ? "Unmute" : "Mute";
    }
}
