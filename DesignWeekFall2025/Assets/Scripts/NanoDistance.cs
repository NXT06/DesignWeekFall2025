using UnityEngine;
using System.IO;
using TMPro;
using System.IO.Ports;

public class NanoDistance : MonoBehaviour
{
    public TextMeshProUGUI distance;

    //COM port is the one listed in Arduino when you upload the code, but Arduino must be closed
    //before running Unity (or they fight over who's using the port)
    SerialPort port = new SerialPort("COM3", 9600);
    void Start()
    {
        port.Open();
        port.ReadTimeout = 5000;
    }

    
    void Update()
    {
        if (port.IsOpen)
        {
            try
            {
                getDistance(port.ReadByte());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

    void getDistance(int data)
    {
        distance.text = data.ToString();
    }
}
