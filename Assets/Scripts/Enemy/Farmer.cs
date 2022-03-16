using UnityEngine;

public class Farmer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    private EnemyData enemyData;
    private IEnemyMove enemyMove;
    private Enemy enemy;


    private void Awake()
    {
        enemyData = Resources.Load<EnemyData>("FarmerData");
        enemy = new Enemy();
        enemyMove = enemy;
    }


    private void Update()
    {

        enemyMove.EnemyMoving(playerPos, this.transform, enemyData.Speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Health>().Kill();
        }
    }
}
