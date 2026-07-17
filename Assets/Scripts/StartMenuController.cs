using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Button musicButton;
    public Button sfxButton;
    public Sprite musicSprite;
    public Sprite musicMuteSprite;
    public Sprite sfxSprite;
    public Sprite sfxMuteSprite;

    public void OnStartClick()
    {
        SceneManager.LoadScene("Game");
        Audio.Instance.PlaySFX("Button");
    }
    public void OnExitClick()
    {
        Audio.Instance.PlaySFX("Button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleMusic()
    {
        Audio.Instance.ToggleMusic();

        if (Audio.Instance.musicSource.mute)
        {
            musicButton.image.sprite = musicMuteSprite;
        }
        else
        {
            musicButton.image.sprite = musicSprite;
        }
    }

    public void ToggleSFX()
    {
        Audio.Instance.ToggleSFX();

        if (Audio.Instance.sfxSource.mute)
        {
            sfxButton.image.sprite = sfxMuteSprite;
        }
        else
        {
            sfxButton.image.sprite = sfxSprite;
        }
    }
}
