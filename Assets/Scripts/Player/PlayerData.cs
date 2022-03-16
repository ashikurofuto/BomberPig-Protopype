using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData",menuName = "Data/PlayerData ",order = 1)]
public class PlayerData : ScriptableObject
{
   [SerializeField] private float speed;
   [SerializeField] private int bombCount;
   [SerializeField] private Sprite[] pigSprites;


    public Sprite[] PigSprites { get => pigSprites; }
    public float Speed { get => speed; }
    public int BombCount { get => bombCount; }


}
