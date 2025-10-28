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
    public TextMeshProUGUI player1Input, player2Input, p1StateText, p2StateText;
    public Slider speedSlider;
    public TextMeshProUGUI speedometer; 

    public PumpStates player1state;
    public PumpStates player2state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1state = PumpStates.idle;
        player2state = PumpStates.idle;
        speedSlider.maxValue = maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        HandleSpeed(); 
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

            print(currentSpeed);

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

    }

    public float heightThreshold;
    public float pumpSpeed; 
    public bool p1CanPump; 
    public bool p2CanPump; 
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
}
