using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; // 使用序列通信
using UnityEngine.UI;

public class sensorwitharduino : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM6", 9600); // 設定 Arduino 的序列埠 測試的時候要改這邊的數值COM要設定成你的數字
    public Button button2; // 對應 sensor1
    public Button button3; // 對應 sensor2
    public Button button4; // 對應 sensor3
    public Button button5; // 對應 sensor4

    // 設定 Arduino 的序列埠
    void Start()
    {
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
            serialPort.ReadTimeout = 100;
        }
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string sensorName = serialPort.ReadLine().Trim(); // 讀取感測器名稱
                Debug.Log("Received data: " + sensorName);       // 打印接收的資料
                TriggerButton(sensorName);
            }
            catch (System.Exception)
            {
                // 處理通信錯誤
            }
        }
    }

    void TriggerButton(string sensorName)
    {
        // 根據感測器名稱觸發對應動作
        switch (sensorName)
        {
            case "sensor1": // sensor1 對應按鈕 2
                if (button2 != null)
                    button2.onClick.Invoke();
                Debug.Log("Sensor 1 triggered -> Button 2 clicked!");
                break;

            case "sensor2": // sensor2 對應按鈕 3
                if (button3 != null)
                    button3.onClick.Invoke();
                Debug.Log("Sensor 2 triggered -> Button 3 clicked!");
                break;

            case "sensor3": // sensor3 對應按鈕 4
                if (button4 != null)
                    button4.onClick.Invoke();
                Debug.Log("Sensor 3 triggered -> Button 4 clicked!");
                break;

            case "sensor4": // sensor4 對應按鈕 5
                if (button5 != null)
                    button5.onClick.Invoke();
                Debug.Log("Sensor 4 triggered -> Button 5 clicked!");
                break;

            default:
                Debug.Log("Unknown sensor triggered: " + sensorName);
                break;
        }
    }

    private void OnApplicationQuit()
    {
        // 關閉序列埠
        if (serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
