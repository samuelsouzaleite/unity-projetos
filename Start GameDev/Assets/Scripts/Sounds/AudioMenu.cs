using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    private bool stateSound = true;

    [SerializeField] private AudioSource musicMenu;
    [SerializeField]private Sprite soundOnnSprite;
    [SerializeField]private Sprite soundOffSprite;
    [SerializeField]private Image muteImage;

    public void TurnOnTurnOffSound()
    {
        stateSound = !stateSound;
        musicMenu.enabled = stateSound;

        if (stateSound )
        {
            muteImage.sprite = soundOnnSprite;
        }
        else
        {
            muteImage.sprite = soundOffSprite;
        }
    }

    public void musicVolume(float value)
    {
        musicMenu.volume = value;
    }
    
}
