using NUnit.Framework.Constraints;
using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerInputs : MonoBehaviour
{

    public enum PumpStates
    {
        idle, 
        pumpUp, pumpDown,
        damaged
    }
    public enum RailStates
    {
        bottom,
        top
    }
    public TextMeshProUGUI player1Input, player2Input, p1StateText, p2StateText;
    public Slider speedSlider;
    public TextMeshProUGUI speedometer; 

    public PumpStates player1state;
    public PumpStates player2state;
    public RailStates currentRail; 

    public Transform bottomRail, topRail; 

    public bool isJumping; 
    public bool canJump; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1state = PumpStates.idle;
        player2state = PumpStates.idle;
        currentRail = RailStates.bottom;
        canJump = true; 
        speedSlider.maxValue = maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        HandleSpeed();
        HandleFall();
        GetInputs();

    }
    public void HandleState()
    {

    }

    public static float currentSpeed;
    float targetSpeed;
    public float decelerationRate;
    public float accelerationLerp;
    public float maxSpeed; 
    public void HandleSpeed()
    {
        targetSpeed -= decelerationRate * Time.deltaTime ;

        
        targetSpeed = Mathf.Clamp(targetSpeed, 0.0f, maxSpeed);
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, accelerationLerp * Time.deltaTime);
        

        if(targetSpeed < 0.2)
        {
            currentSpeed = 0.0f;
        }

        float fontSize = Mathf.Clamp(currentSpeed + 20, 20, 40);


        speedometer.text = $"" + Mathf.RoundToInt(currentSpeed) + " km/h";
        speedometer.fontSize = fontSize;
        speedSlider.value = currentSpeed;

    }
    public void GetInputs()
    {
        Vector2 currentInput;

        currentInput.x = Input.GetAxisRaw("Horizontal");
        currentInput.y = Input.GetAxisRaw("Vertical");

        player1Input.text = Mathf.RoundToInt(currentInput.x).ToString();
        player2Input.text = Mathf.RoundToInt(currentInput.y).ToString();
        p1StateText.text = player1state.ToString();
        p2StateText.text = player2state.ToString();

        HandleMove(currentInput);
        //print(currentInput);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            print("jump"); 
            if (canJump)
            {
                HandleJump(); 
            }
        }
    }

    public float heightThreshold;
    public float pumpSpeed; 
    public bool p1CanPump; 
    public bool p2CanPump;
    public DetectRail rail; 
    public void HandleMove(Vector2 input)
    {
        
        
        switch (player1state)
        {
            case PumpStates.idle:

                if (input.x > heightThreshold)
                {
                    p1CanPump = true;
                    player1state = PumpStates.pumpUp;
                }
                break; 

            case PumpStates.pumpUp:

                if (input.x < -heightThreshold && p1CanPump)
                {
                    targetSpeed += pumpSpeed; 
                    player1state = PumpStates.pumpDown;
                }
                break; 

            case PumpStates.pumpDown:

                if(input.x > heightThreshold)
                {
                    p1CanPump = true;
                    player1state = PumpStates.pumpUp;
                }
                break; 
        }
        switch (player2state)
        {
            case PumpStates.idle:

                if (input.y > heightThreshold)
                {
                    p1CanPump = true;
                    player2state = PumpStates.pumpUp;
                }
                break; 

            case PumpStates.pumpUp:

                if (input.y < -heightThreshold && p1CanPump)
                {
                    targetSpeed += pumpSpeed;
                    player2state = PumpStates.pumpDown;
                }
                break; 

            case PumpStates.pumpDown:

                if(input.y > heightThreshold)
                {
                    p2CanPump = true;
                    player2state = PumpStates.pumpUp;
                }
                break; 
        }




    }

    public void HandleJump()
    {
        if (!rail.CheckRail())
        {
            return;
        }

        isJumping = true;
        canJump = false; 
        print("check"); 
        switch (currentRail)
        {
            case RailStates.top:

                StartCoroutine(Jump(bottomRail.transform.position, topRail.transform.position, 5, 1)); 
                currentRail = RailStates.bottom;
                break;

            case RailStates.bottom:

                StartCoroutine(Jump(topRail.transform.position, bottomRail.transform.position, 5, 1));
                currentRail = RailStates.top; 
                break;   

        }
    }

    public void HandleFall()
    {
        if (!rail.CheckRail() && currentRail == RailStates.top)
        {
            StartCoroutine(Jump(bottomRail.transform.position, topRail.transform.position, 1, 3)); 
            currentRail = RailStates.bottom;
        }
    }

    Vector3[] jumpPoints = new Vector3[3];
    public float scaleChange; 
    float t; 
    public IEnumerator Jump(Vector3 endPos, Vector3 startPos, float jumpHeight, float jumpSpeedMultiplier)
    {
        print("startjump"); 
        t = 0f;
        Vector3 currentScale = transform.localScale;
        float scale; 

        if(currentRail == RailStates.top)
        {
            scale = 1f;
        }
        else
        {
            scale = -1f; 
        }

            jumpPoints[0] = startPos;
        jumpPoints[2] = endPos;
        jumpPoints[1] = jumpPoints[0] + (jumpPoints[2] - jumpPoints[0]) /2 + Vector3.up * jumpHeight; 

        while (t < 1f)
        {
            t += 1 * Time.deltaTime * jumpSpeedMultiplier;

            transform.localScale = Vector3.Lerp(currentScale, currentScale + (Vector3.one * scaleChange * scale), t);

            Vector3 m1 = Vector3.Lerp(jumpPoints[0], jumpPoints[1], t);
            Vector3 m2 = Vector3.Lerp(jumpPoints[1], jumpPoints[2], t);

            Vector3 newPos = Vector3.Lerp(m1, m2, t);

            transform.position = newPos; 

            yield return null;  
        }

        transform.position = endPos;
        canJump = true; 
        isJumping = false;  
       
    }

    public void HandleShake()
    {
        StartCoroutine(Shake());
    }
    float g;
    public float shakeTime;
    public float shakeMag; 
    IEnumerator Shake()
    {
        while (g < shakeTime)
        {
            g += Time.deltaTime;

            Vector2 newPos = Random.insideUnitCircle * (Time.deltaTime * shakeMag);

            newPos.y = transform.position.y;
            newPos.x = transform.position.x;

            yield return null;
        }
        

    }

    
}
