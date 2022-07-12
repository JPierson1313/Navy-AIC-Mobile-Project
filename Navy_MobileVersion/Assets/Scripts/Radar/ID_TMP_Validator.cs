using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Input Field Validator", menuName = "Input Field Validator")]
public class ID_TMP_Validator : TMPro.TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (char.IsLetter(ch) || char.IsNumber(ch))
        {
            ch = char.ToUpper(ch);

            if (text.Length < 4)
            {
                text = text.Insert(pos, ch.ToString());
                // Increment the insertion point by 1
                pos++;
            }
        }

        return '\0';
    }
}
