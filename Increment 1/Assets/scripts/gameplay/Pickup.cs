using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Ball
{
    int freezeDuration;
    Timer freezeTimer;
    ScreenSide side;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (ballType == BallType.Freeze)
        {
            freezeDuration = ConfigurationUtils.FreezerEffectDuration;
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        var ltPaddle = GameObject.FindGameObjectWithTag("LtPaddle").GetComponent<Paddle>();
        var rtPaddle = GameObject.FindGameObjectWithTag("RtPaddle").GetComponent<Paddle>();

        if (coll.gameObject.name == "RightPaddle")
        {
            ltPaddle.FreezePaddleDuration(freezeDuration);
        }
        else
        {
            rtPaddle.FreezePaddleDuration(freezeDuration);
        }

        // spawn a new ball and destroy self
        Destroy(gameObject);
        Camera.main.GetComponent<BallSpawner>().SpawnBall();

    }
}