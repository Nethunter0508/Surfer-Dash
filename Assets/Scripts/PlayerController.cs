using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] float baseSpeed = 25f;
    [SerializeField] float boostspeed = 35f;
    [SerializeField] ParticleSystem powerupParticles;
    [SerializeField] ScoreManager scoreManager;

    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D surfaceEffector2D;

    Vector2 moveVector;
    bool canControlPlayer = true;

    float previousRotation;
    float totalRotation;
    int activePowerupCount;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueAmount);
        }
        else if (moveVector.x > 0)
        {
            myRigidbody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostspeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        float rotationDifference = Mathf.DeltaAngle(previousRotation, currentRotation);

        totalRotation += rotationDifference;
        previousRotation = currentRotation;

        if (totalRotation > 340f || totalRotation < -340f)
        {
            totalRotation = 0f;
            scoreManager.AddScore(100);
        }
    }

    public void DisablePlayerControl()
    {
        canControlPlayer = false;
    }

    public void ActivatePowerup(Powerups powerup)
    {
        powerupParticles.Play();
        activePowerupCount += 1;
        if (powerup.GetPowerupType() == "Speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostspeed += powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            torqueAmount += powerup.GetValueChange();
        }
    }

    public void DeactivatePowerup(Powerups powerup)
    {
        activePowerupCount -= 1;
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }
        if (powerup.GetPowerupType() == "Speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostspeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }
    }
}