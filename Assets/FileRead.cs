using UnityEngine;
using System.Collections;
using System;
using System.IO;

/// テキストを読み込みするクラス
public class  FileRead : MonoBehaviour
{
	/// テキストファイルのパス
	private string filePath = "/53394610_dsm_1m.dat"; //53394610_dsm_1m.dat
	/// 読み込んだテキストデータを格納する文字列変数
	public string textData;
	char[] delimiterChars = { ' ' };
	public GameObject cube;
	/// 初期化
	void Start ()
	{
		int cnt = 0;
		float x = 0;
		float y = 0;
		float z = 0;
		StreamReader reader = new StreamReader (
			Application.dataPath + filePath,
			System.Text.Encoding.GetEncoding ("utf-8"));
		while (cnt < 400000/* && (reader.EndOfStream == false)*/) {
			textData = reader.ReadLine ();
			string[] words = textData.Split (delimiterChars);
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
			x = float.Parse (words [2]);
			z = float.Parse (words [4]);
			if(words[5] == "-9999.99"){
				y = 1000;
			}else{
				if(words[8] == words[0]){
					y = float.Parse (words [9]);
				}else{
					y = float.Parse (words [8]);
				}
			}
			Instantiate(this.cube, new Vector3(x, y, z), Quaternion.identity);
			cnt++;
		}
		reader.Close ();
	}
}
