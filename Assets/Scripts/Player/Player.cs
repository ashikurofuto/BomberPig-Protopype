using System.Collections.Generic;
using UnityEngine;
using System;



public interface IMove
{
    void UpMove();
    void DownMove();
    void LeftMove();
    void RightMove();
    void DontMove();
}
public interface IBomber
{
    void Plant();
    void Detonate();
}

public class Player : MonoBehaviour, IMove, IBomber
{
    public Action OnBombCountChange;
    private PlayerData playerData;
    private Bomb bombPrefab;
    private int bombIndex = -1;
    private int bombCount;
    private SpriteRenderer spriteRenderer;
    private int spriteIndex = 2;
    private List<Bomb> bombsList;
    public int BombCount { get => bombCount; }



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerData = Resources.Load<PlayerData>("PlayerData");
        bombPrefab = Resources.Load<Bomb>("bomb");
        bombsList = new List<Bomb>(playerData.BombCount);
        bombCount = playerData.BombCount;
    }


    public void UpMove()
    {
        spriteIndex = 0;
        Move(Vector3.up);  
    }

    public void DownMove()
    {
        spriteIndex = 1;
        Move(Vector3.down);
    }

    public void LeftMove()
    {
        spriteIndex = 2;
        Move(Vector3.left);
    }

    public void RightMove()
    {
        spriteIndex = 3;
        Move(Vector3.right);
    }
    private void Move(Vector3 dir)
    {
        transform.position += dir * playerData.Speed * Time.deltaTime;
        spriteRenderer.sprite = playerData.PigSprites[spriteIndex];
    }

    public void DontMove()
    {
        Move(Vector3.zero);
    }

    public void Plant()
    {
        if (bombCount <= 0)
            return;
        bombCount--;
        var obj = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        bombsList.Add(obj);
        bombIndex++;
        OnBombCountChange?.Invoke();
    }

    public void Detonate()
    {
        if (bombIndex < 0)
            return;
        bombsList[bombIndex].Explose();
        bombsList.Remove(bombsList[bombIndex]);
        bombIndex--;
        

    }
}

