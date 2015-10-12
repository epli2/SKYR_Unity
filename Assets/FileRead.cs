using UnityEngine;
using System.Collections;
using System;
using System.IO;
using CielaSpike;
using System.Threading;
//using SpicyPixel.Threading;
//using SpicyPixel.Threading.Tasks;

public class FileRead : MonoBehaviour
{
    /// テキストファイルのパス
    private string[] filePathSet = {
"/Resources/53394610_dsm_1m.dat",
"/Resources/53394611_dsm_1m.dat",
"/Resources/53394620_dsm_1m.dat",
"/Resources/53394621_dsm_1m.dat",
"/Resources/53394630_dsm_1m.dat",
"/Resources/53394631_dsm_1m.dat",
"/Resources/53394640_dsm_1m.dat",
"/Resources/53394641_dsm_1m.dat"};
    /// 読み込んだテキストデータを格納する文字列変数
    private string textData;
    //private char[] delimiterChars = { ' ' };
    public GameObject cube;


    /// 初期化
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            this.StartCoroutineAsync(read(filePathSet[i]));
        }
        //this.StartCoroutineAsync(read(filePath1));
        //this.StartCoroutineAsync(read(filePath2));
        //this.StartCoroutineAsync(read(filePath3));
        //this.StartCoroutineAsync(read(filePath4));
        //this.StartCoroutineAsync(read(filePath5));
        //this.StartCoroutineAsync(read(filePath6));
        //this.StartCoroutineAsync(read(filePath7));
        //this.StartCoroutineAsync(read(filePath8));
        //read(filePath1);
        //read(filePath2);
        //read(filePath3);
        //read(filePath4);
        //read(filePath5);
        //read(filePath6);
        //read(filePath7);
        //read(filePath8);
        //StartCoroutine("read", filePath1);
        //StartCoroutine("read", filePath2);
        //StartCoroutine("read", filePath3);
        //StartCoroutine("read", filePath4);
        //StartCoroutine("read", filePath5);
        //StartCoroutine("read", filePath6);
        //StartCoroutine("read", filePath7);
        //StartCoroutine("read", filePath8);
    }

    IEnumerator read(string filePath)
    {
        //int cnt = 0;
        float x = 0;
        float y = 0;
        float z = 0;
        yield return Ninja.JumpToUnity;
        StreamReader reader = new StreamReader(
            Application.dataPath + filePath,
            System.Text.Encoding.GetEncoding("utf-8"));
        yield return Ninja.JumpBack;
        while (reader.EndOfStream == false)
        {
            textData = reader.ReadLine();
            string[] words = textData.Split(' ');
            //			Debug.Log (cnt);
            //			for(int i=0; i<9; i++){
            //				Debug.Log(i);
            //				Debug.Log(words[i]);
            //			}
            //			if(cnt >= 172){
            //				for(int i=9; i<12; i++){
            //					Debug.Log(i);
            //					Debug.Log(words[i]);
            //				}
            //			}
            //			Debug.Log (words [2]);
            //			Debug.Log (words [4]);
            //			Debug.Log (words [8]);
            x = float.Parse(words[2]);
            z = float.Parse(words[4]);

            if (words[5] == "-9999.99")
            {
                y = 1000;
            }
            else if (words[7] == words[0])
            {
                if (words[8] == words[0])
                {
                    y = float.Parse(words[9]);
                }
                else
                {
                    y = float.Parse(words[8]);
                }
            }
            else
            {
                y = float.Parse(words[7]);
            }
            yield return Ninja.JumpToUnity;
            Instantiate(this.cube, new Vector3(x, y, z), Quaternion.identity);
            yield return Ninja.JumpBack;
            //cnt++;
        }
        reader.Close();
        yield return null;
    }
}
