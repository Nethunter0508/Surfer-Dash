using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] Powerups[] powerups;

    PlayerController player;
    SpriteRenderer mySpriteRenderer;
    float powerupDuration;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        powerupDuration = powerups[0].GetDuration();
    }

    void Update()
    {
        CountdownPowerup();
    }

    void CountdownPowerup()
    {
        if (!mySpriteRenderer.enabled)
        {
            if (powerupDuration > 0)
            {
                powerupDuration -= Time.deltaTime;

                if (powerupDuration <= 0)
                {
                    player.DeactivatePowerup(powerups[0]);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex && mySpriteRenderer.enabled)
        {
            mySpriteRenderer.enabled = false;
            player.ActivatePowerup(powerups[0]);
        }
    }
}