using UnityEngine;

public class View : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = (Rigidbody2D)this.GetComponentInParent(typeof(Rigidbody2D));
        enemy = (Enemy)this.GetComponentInParent(typeof(Enemy));
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        enemy.OnPlayerSeen();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        enemy.seePlayer = true;
        this.enabled = true;
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        enemy.seePlayer = false;
        this.enabled = false;
    }
}
