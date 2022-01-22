using System;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private string path = "D:\\FileTextTest\\TextTesting";
    private string file = "bot";
    private string extension = ".txt";

    private void Start() {
        if(SimpleFileMethods.TryToWriteTextDataToFile(path, file, extension, writer => {
            writer.WriteLine("Testing system...");
            writer.WriteLine("...Nitro5...");
            writer.WriteLine("...a lot of rasengans found!");
        })) {
            Debug.Log("Ramen");
        }
    }
}
