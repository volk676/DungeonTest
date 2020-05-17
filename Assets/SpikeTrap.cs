using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int animTimer = 100;

    public int frame = 0;

    private int index;

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (animTimer == 0)
        {
            animTimer = 100;
            index = 0;
        }

        if (animTimer-- % 25 == 0)
        {
            frame = index;
            spriteRenderer.sprite = sprites[frame];
            index++;
        }
    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && frame > 1)
        {
            Player player = other.GetComponent<Player>();
            if (!player.invuln)
            {
                player.damaged(0.5f);
            }
        }
    }
}
