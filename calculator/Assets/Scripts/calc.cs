using System;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class calc : MonoBehaviour
{
    public Text CalculatorWindow;
    private float _number1 =0.0f;
    private float _number2 = 0.0f;
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
        if (!dotIsPressed)
        {
            CheckOperation(number);
        }
        else
        {
            _currentNumber = GetFloatedNumber(number, _currentNumber);
            CalculatorWindow.text += _currentNumber.ToString();
        }
    }
    // работает лучше чем 2 функции ниже for some reason 
    /*    private void CheckOperation(int NumberOnButton)
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
                CalculatorWindow.text += ""+ _currentNumber;
            }
        }*/
    private void CheckOperation(int NumberOnButton)
    {
        Debug.Log("number = " + NumberOnButton + " _number1 = " + _number1 + " number 2 = " + _number2);
        if (!operationIsPressed)
        {
            SetCurrentNumber(NumberOnButton, _number1);
        }
        else
        {
            SetCurrentNumber(NumberOnButton, _number2);
        }
    }
    private void SetCurrentNumber(int NumberOnButton, float InputNumber)
    {
        InputNumber = InputNumber != 0 ? (InputNumber * 10) + NumberOnButton : NumberOnButton;
        _currentNumber = InputNumber;
        CalculatorWindow.text = "" + _currentNumber;
    }

    private float GetFloatedNumber(int NumberOnButton, float CurrentNumber)
    {
        string shouldBeFloat = (CurrentNumber).ToString() + "." + NumberOnButton.ToString();
        return float.Parse(shouldBeFloat, CultureInfo.InvariantCulture.NumberFormat);
    }
    public void DotPressed()
    {
        dotIsPressed = true;
        CalculatorWindow.text += ",";
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
    }
    public void EqualPressed()
    {
        if (string.IsNullOrEmpty(operation))
        {
            CalculatorWindow.text = _number1.ToString();
            _currentNumber = _number1;
        }
        else
        {
            Calculate();
        }
        CalculatorWindow.text = _result.ToString();
        _currentNumber = _result;
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
            case "%":
                _result = _number1 % _currentNumber;
                break;
            default:
                break;
        }
    }

    /*  хз как это работает, но не работает
        private float Calculate()
        {
            return operation switch
            {
                "+" => _number1 + _currentNumber,
                "-" => _number1 - _currentNumber,
                "*" => _number1 * _currentNumber,
                "/" => _number1 / _currentNumber,
                _ => throw new ArgumentException("Недопустимый код операции")
            };
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
