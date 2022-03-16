using UnityEngine;
using System.Collections.Generic;
using System;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    private ParticleSystem kaboom;
    private Damager damager;
    private Vector2 pos;


    private void Awake()
    {
        kaboom = Resources.Load<ParticleSystem>("BoomParticle");
        damager = new Damager();
        this.gameObject.SetActive(true);
        pos.x = transform.position.x;
        pos.y = transform.position.y;
    }
    public void Explose()
    {
        damager.Damage(pos, radius, layerMask);
        Destroy();
        Instantiate(kaboom, transform.position,Quaternion.identity);
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}

public class Damager
{
    
    public void Damage(Vector2 pos,float radius,LayerMask layer)
    {
        Collider2D[] hitCol = Physics2D.OverlapCircleAll(pos, radius, layer);
        foreach (Collider2D hit in hitCol)
        {
            hit.GetComponent<Health>().Kill();
        }
    }

}

