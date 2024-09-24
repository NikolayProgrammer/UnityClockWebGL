using System.Collections;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// ��������� �������� �������� � ������������� � ����������
/// </summary>
public class UI_Input_Number : MonoBehaviour
{
    private TMP_InputField inputField;

    /// <summary>
    /// ��������� ���� (���� ����)
    /// </summary>
    [SerializeField] private TMP_InputField next_InputField;

    /// <summary>
    /// ������������ ����� �����
    /// </summary>
    [SerializeField] private int inputLength = 3;

    /// <summary>
    /// ����������� �������� �����
    /// </summary>
    /// 
    [SerializeField] private int minValue = 1;

    /// <summary>
    /// ������������ �������� �����
    /// </summary>
    [SerializeField] private int maxValue = 999;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.characterLimit = inputLength;
        inputField.onValidateInput += ValidateInput;
    }

    private char ValidateInput(string text, int charIndex, char addedChar)
    {

        if (charIndex >= inputLength)
        {
            if (next_InputField)
            {
                SelectNextInputField(addedChar);
            }
            else
            {
                inputField.DeactivateInputField();
            }
            return '\0';
        }

        if (!char.IsDigit(addedChar))
        {
            return '\0';
        }

        int.TryParse((text + addedChar), out int res);
        if (res > maxValue)
        {
            inputField.text = maxValue.ToString();
            if (next_InputField)
            {
                SelectNextInputField();
            }
            return '\0';
        }

        return addedChar;
    }

    public void SelectNextInputField()
    {
        next_InputField.ActivateInputField();
        next_InputField.Select();
    }
    public void SelectNextInputField(char charToAdd)
    {
        SelectNextInputField();
        next_InputField.SetTextWithoutNotify(charToAdd.ToString());
    }
}
