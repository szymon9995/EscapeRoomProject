using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadOutput : MonoBehaviour
{
    public string solution; 
    private string output = "";
    public bool solved = false;
    public TextMesh textMesh;
    public Item itemOut;

    public void addNumber(int num)
    {
        output += num.ToString();
        if(output==solution)
        {
            itemOut.AddToInventory();
            solved = true;
        }
        else if(output.Length>=solution.Length)
        {
            output = "";
        }
        textMesh.text = output;
    }
}
