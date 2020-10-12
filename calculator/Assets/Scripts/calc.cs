using UnityEngine;
using UnityEngine.UI;

public class calc : MonoBehaviour
{
    public Text CalculatorWindow;
    private float _input;
    private float _input2;
    private float _result;
    private string operation;
    private bool operationPressed = false;

    private void Awake()
    {
        Debug.Log("calculator is awaken!");
        CalculatorWindow.text = " ";
    }

    public void NumberButton(int number)
    {
        if (!operationPressed)
        {
            _input = _input != 0 ? (_input * 10) + number : number;
        }
        else
        {
            _input2 = _input2 != 0 ? (_input2 * 10) + number : number;
        }
        CalculatorWindow.text += number;
        Debug.Log("operationPressed " + operationPressed + "input1 = " + _input + "input 2 = " + _input2);
    }
    public void operationButton(string op)
    {
        operationPressed = true;
        operation = op;
        _input2 = 0.0f;
        CalculatorWindow.text = _input.ToString() + " " + operation + " ";

        Debug.Log("operationPressed = " + operationPressed + "operation = " + operation);
    }
    private void EqualButton()
    {
        if (string.IsNullOrEmpty(operation))
        {
            CalculatorWindow.text = _input.ToString();
        }
        else
        {
            string operation1 = operation;
            switch (operation1)
            {
                case "+":
                    _result = _input + _input2;
                    break;
                case "-":
                    _result = _input - _input2;
                    break;
                case "/":
                    if (_input2 == 0)
                    {
                        CalculatorWindow.text = "That's a bullshit!";
                    }
                    else
                    {
                        _result = _input / _input2;
                    }
                    break;
                case "*":
                    _result = _input * _input2;
                    break;
            }
        }
        CalculatorWindow.text = _result.ToString();
        _input = _result;
        _result = 0.0f;
        Debug.Log("operation " + operation + "input1 = " + _input + "input 2 = " + _input2 + "result = " + _result);
    }

    public void ButtonC()
    {
        _input = 0.0f;
        _input2 = 0.0f;
        _result = 0.0f;
        operationPressed = false;
        operation = "";
        CalculatorWindow.text = "";

    }
}
