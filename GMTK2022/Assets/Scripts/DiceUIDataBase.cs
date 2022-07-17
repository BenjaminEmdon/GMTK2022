using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy/SpriteData", fileName = "SpriteData")]
public class DiceUIDataBase : ScriptableObject
{
  public Sprite[] D2Sprites;
  public Sprite[] D6Sprites;
  public Sprite[] D8Sprites;
  public Sprite[] D20Sprites;
  
}
