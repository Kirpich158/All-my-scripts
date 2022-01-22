using System;
using UnityEngine;
using System.IO;

public static class SimpleFileMethods {
    public static bool TryToWriteTextDataToFile(string directoryPath,
        string fileName = null, string fileExtention = null, Action<StreamWriter> writeAction = null) {
        if (File.Exists(Path.Combine(directoryPath, fileName + fileExtention)) == false || Directory.Exists(directoryPath) == false || writeAction == null) {
            return false;
        }
        else {
            try {
                FileStream stream = new FileStream(Path.Combine(directoryPath, fileName + fileExtention), FileMode.Open);
                StreamWriter sw = new StreamWriter(stream);
                writeAction(sw);
                sw.Close();
                stream.Close();
                return true;
            }
            catch (Exception e) {
                Debug.Log(e.Message);
                return false;
            }
        }
    }
}