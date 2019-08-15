using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class md5Script : MonoBehaviour {


    //Method that does the magic, insert the string you want to be encripted Ex: 1 = c4ca4238a0b923820dcc509a6f75849b
    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    void GetProceduralColor()
    {
        //Make the Hex code from the value you want
        string hexa = Md5Sum("YOUR VALUE.TOSTRING()");

        //Make a Color Hex value - Substring doing the job of choosing wich 6 letters of the hex Code to chosse - You can change it Between 0 & 25
        string fixedHexa = "#" + hexa.Substring(15, 6) + "FF";

        //Make a color(r) out of your Color Hex value
        Color r = new Color();
        ColorUtility.TryParseHtmlString(fixedHexa, out r);

        //Insert The new color to your gameobject
        string colorExample = "GameObject.color = r";
    }

    void DecodeMD5String()
    {
        //Make the Hex code from the value you want
        string hexa = Md5Sum("YOUR VALUE.TOSTRING()");

        //turn the hex code you made into a array dividing each letter on it's own
        char[] hexaChars = hexa.ToCharArray();

        //Choose the letter you want, inserting it's index from 1 to 32. Change the 1
        string strAux = hexaChars[1].ToString();

        //Tunr the letter you want insto a decimal value. EX. Your letter = C -> Decimal Value = 12  
        int decodedHexValue = Convert.ToInt32(strAux, 16);

        // Now you can use the "decodedHexValue" in everything you want, being always the same exact "Random" value
    }


}
