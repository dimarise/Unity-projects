using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class calc : MonoBehaviour
{
    public Text CalculatorWindow;
    private float _number1;
    private float _number2;
    private float _currentNumber;
    private float _result;
    private string operation;
    private bool operationIsPressed = false;
    private bool dotIsPressed = false;
    private void Awake()
    {
        Debug.Log("calculator is awaken!");
        CalculatorWindow.text = " ";
    }

    public void NumberPressed(int number)
    {
        if (dotIsPressed)
        {
            _currentNumber = GetFloatedNumber(number, _currentNumber);
            CalculatorWindow.text = _currentNumber.ToString();
        }
        else
        {
            CheckOperation(number);
        }
/*        Debug.Log("operationIsPressed = " + operationIsPressed + "dotispressed " + dotIsPressed);
        Debug.Log("input 1 = " + _number1 + "input 2 = " + _number2 + "current number" + _currentNumber);*/
    }

    private void CheckOperation(int NumberOnButton)
    {
        if (!operationIsPressed)
        {
            _number1 = _number1 != 0 ? (_number1 * 10) + NumberOnButton : NumberOnButton;
            _currentNumber = _number1;
            CalculatorWindow.text = "" + _currentNumber;

        }
        else
        {
            _number2 = _number2 != 0 ? (_number2 * 10) + NumberOnButton : NumberOnButton;
            _currentNumber = _number2;
            CalculatorWindow.text = "" + _currentNumber;
        }
    }
    private float GetFloatedNumber(int NumberOnButton, float CurrentNumber)
    {
        string shouldBeFloat = CurrentNumber.ToString() + "." + NumberOnButton.ToString();
        return float.Parse(shouldBeFloat, CultureInfo.InvariantCulture.NumberFormat);
    }
    public void DotPressed()
    {
        dotIsPressed = true;
        CalculatorWindow.text += ".";
        Debug.Log("dotIsPressed = " + dotIsPressed + "Currentnumber = " + _currentNumber);
    }
    public void OperationPressed(string op)
    {
        operationIsPressed = true;
        dotIsPressed = false;
        //save 1st number
        _number1 = _currentNumber;
        operation = op;
        _number2 = 0.0f;
        CalculatorWindow.text = _number1.ToString() + " " + operation + " ";

        Debug.Log("operationPressed = " + operationIsPressed + "operation = " + operation);
    }
    public void EqualPressed()
    {
        if (string.IsNullOrEmpty(operation))
        {
            CalculatorWindow.text = _number1.ToString();
        }
        else
        {
            Calculate();
        }
        CalculatorWindow.text = _result.ToString();
        _currentNumber = _result;
        _result = 0.0f;
    }
    private void Calculate()
    {
        switch (operation)
        {
            case "+":
                _result = _number1 + _currentNumber;
                break;
            case "-":
                _result = _number1 - _currentNumber;
                break;
            case "/":
                if (_currentNumber == 0)
                {
                    CalculatorWindow.text = "That's a bullshit!";
                }
                else
                {
                    _result = _number1 / _currentNumber;
                }
                break;
            case "*":
                _result = _number1 * _currentNumber;
                break;
            default:
                break;
        }
    }

/*    private bool IsFloatedNumber(float number)
    {
        string str = number.ToString();
        return str.Contains(".");
    }*/

    public void ButtonC()
    {
        _number1 = 0.0f;
        _number2 = 0.0f;
        _result = 0.0f;
        _currentNumber = 0.0f;
        operationIsPressed = false;
        dotIsPressed = false;
        operation = "";
        CalculatorWindow.text = "";
    }
}
