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
	private int[] takasa = new int[1000];
	private int count1 = 0;
    /// 初期化
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            //this.StartCoroutineAsync(read(filePathSet[i]));
			//read(filePathSet[i]);
			//StartCoroutine("read", filePathSet[i]);
		}
		StartCoroutine("read", filePathSet[7]);
//		for(int i=0; i<1000; i++){
//			//Debug.Log(takasa[i]);
//			for(int j=0; j<takasa[i]/10; j++){
//				Instantiate(this.cube, new Vector3(0, takasa[i]-j, i), Quaternion.identity);
//			}
//		}
		Debug.Log(count1);
    }

    IEnumerator read(string filePath)
    {
        int cnt = 0;
		
		float[] x = new float[1500000];
		float[] y = new float[1500000];
		float[] z = new float[1500000];
        //yield return Ninja.JumpToUnity;
        StreamReader reader = new StreamReader(
            Application.dataPath + filePath,
            System.Text.Encoding.GetEncoding("utf-8"));
        //yield return Ninja.JumpBack;
		while (reader.EndOfStream == false)
		//while( cnt <  1000000)
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
            x[cnt] = float.Parse(words[2]);
            z[cnt] = float.Parse(words[4]);

            if (words[5] == "-9999.99")
            {
                y[cnt] = 1000;
				count1 ++;
            }
            else if (words[7] == words[0])
            {
                if (words[8] == words[0])
                {
                    y[cnt] = float.Parse(words[9]);
                }
                else
                {
                    y[cnt] = float.Parse(words[8]);
                }
            }
            else
            {
                y[cnt] = float.Parse(words[7]);
            }
            //yield return Ninja.JumpToUnity;
            Instantiate(this.cube, new Vector3(x[cnt], y[cnt], z[cnt]), Quaternion.identity);
			//int tmp = (int)System.Math.Round(y[cnt]);
			//takasa[tmp] += 1;
            //yield return Ninja.JumpBack;
            cnt++;
        }
        reader.Close();
        yield return null;
    }
}
