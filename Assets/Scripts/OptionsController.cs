using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;


    // Start is called before the first frame update
    void Start() {
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update() {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        } else {
            Debug.LogWarning("No music player found");
        }
    }

    public void SetDefaults() {
        difficultySlider.value = defaultDifficulty;
        volumeSlider.value = defaultVolume;
    }

    public void SaveAndExit() {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
}
