using UnityEngine;



public interface IEnemyMove
{
    void EnemyMoving(Transform playerPos, Transform enemyPos, float speed);
}

public class Enemy : IEnemyMove
{
    public void EnemyMoving(Transform playerPos, Transform enemyPos, float speed)
    {
        enemyPos.position = Vector3.Lerp(enemyPos.position, playerPos.position, speed/7 * Time.deltaTime);
    }
}
