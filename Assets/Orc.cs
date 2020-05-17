using UnityEngine;

public class Orc : Enemy
{
    public Player player;

    public Rigidbody2D rb;

    private float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPlayerSeen()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime));
    }
}
