using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public bool seePlayer;

    public abstract void OnPlayerSeen();
}