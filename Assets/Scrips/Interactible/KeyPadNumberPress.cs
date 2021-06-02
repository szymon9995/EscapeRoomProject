using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadNumberPress : InteractibleBase
{
    protected override Color color => new Vector4(0.5f,0.5f,0.0f,1.0f);

    public int number = 1;
    public KeyPadOutput keypad;
    public override void OnInteract()
    {
        if(keypad.solved==false)
            keypad.addNumber(number);
    }
}
