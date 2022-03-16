using System;
using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour
{
    [SerializeField] private Sprite deadSprite;
    private SpriteRenderer spriteRenderer;
    public Action HasBeenKilled;
   


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Kill()
    {
        spriteRenderer.sprite = deadSprite;
        HasBeenKilled?.Invoke();
        StartCoroutine(TimeToOf());
    }

    private IEnumerator TimeToOf()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}

