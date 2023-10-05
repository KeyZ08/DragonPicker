using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1;
    public float leftRightDistance = 10f;
    public float changeDirection = 0.1f;

    private void Start()
    {
        InvokeRepeating("DropEgg", timeBetweenEggDrops, timeBetweenEggDrops);
    }

    private void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftRightDistance)
            speed = -Mathf.Abs(speed);
    }

    private void FixedUpdate()
    {
        if(Random.value < changeDirection)
            speed *= -1;
    }

    private void DropEgg()
    {
        Instantiate(dragonEggPrefab, transform.position + Vector3.up * 4, Quaternion.identity);
    }
}
