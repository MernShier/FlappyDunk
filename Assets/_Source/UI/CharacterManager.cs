using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase CharacterDB;

    //public Text NameText;
    public SpriteRenderer ArtWorkSprite;

    private int SelectedOption = 0;
    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedOption"))
        {
            SelectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(SelectedOption);
    }

    public void NextOption()
    { 
        SelectedOption++;

        if (SelectedOption >= CharacterDB.CharacterCount)
        {
            SelectedOption = 0;
        }
        UpdateCharacter(SelectedOption);
        Save();
    }

    public void BackOption()
    { 
        SelectedOption--;

        if (SelectedOption < 0)
        {
            SelectedOption = CharacterDB.CharacterCount - 1;
        }
        UpdateCharacter(SelectedOption);
        Save();
    }
    private void UpdateCharacter(int SelectedOption)
    {
        Character character = CharacterDB.GetCharacter(SelectedOption);
        ArtWorkSprite.sprite = character.CharacterSprite;
    }

    private void Load()
    {
        SelectedOption = PlayerPrefs.GetInt("SelectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", SelectedOption);
    }
}
