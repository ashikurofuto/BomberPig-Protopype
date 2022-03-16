using UnityEngine;


[CreateAssetMenu(fileName ="EnemyData",menuName = "Data/EnemyData",order =2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed { get => speed; }

}
