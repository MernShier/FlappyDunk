using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDataBase : ScriptableObject
{
    public Character[] Character;

    public int CharacterCount
    {
        get 
        { 
            return Character.Length; 
        }
    }

    public Character GetCharacter(int index)
    { 
        return (Character[index]);
    }
}
