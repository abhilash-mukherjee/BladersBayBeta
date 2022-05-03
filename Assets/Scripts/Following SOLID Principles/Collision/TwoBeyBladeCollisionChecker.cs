using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TwoBeyBladeCollisionChecker : CollisionChecker
{
    [SerializeField]
    private List<Collidable> collidables;
    [SerializeField]
    private float timeGapBetweenTwoCollisions = 0.2f;
    [SerializeField]
    private GameObject sparkPrefab;
 
    [SerializeField]
    private Vector3 sparkScale;
    private float m_collisionTimer = 0;

    public float CollisionTimer
    {
        get => m_collisionTimer;
        set => m_collisionTimer = value > timeGapBetweenTwoCollisions ? timeGapBetweenTwoCollisions : (value < 0 ? 0 : value);
    }

    private void Update()
    {
        if (CollisionTimer > 0)
            return;
        CheckCollisions();
    }

    private void CheckCollisions()
    {
        if (collidables.Count < 2)
        {
            Debug.LogError("The script needs atleast two collidables to run");
            return;
        }
        if (CollisionTimer > 0)
            return;
        var collision = CheckCollisions(collidables);
        if (collision != null)
        {
            var obj = Instantiate(sparkPrefab, (collision.Collidable1.Transform.position + collision.Collidable2.Transform.position) / 2f, Quaternion.identity);
            obj.transform.localScale = sparkScale;
            InvokeAudioEvent(collision);
            InvokeCollisionEvent(collision);
            CollisionTimer = timeGapBetweenTwoCollisions;
            StartCoroutine(TickClock());
        }
    }
    public ICollision CheckCollisions(List<Collidable> collidables)
    {
        if (collidables[0].Collider.bounds.Intersects(collidables[1].Collider.bounds)) return new CustomCollision(collidables[0],collidables[1]);
        return null;
    }

    IEnumerator TickClock()
    {
        while (CollisionTimer > 0)
        {
            CollisionTimer -= Time.deltaTime;
            yield return null;
        }
    }
   
}
