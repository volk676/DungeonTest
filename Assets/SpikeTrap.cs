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
}
