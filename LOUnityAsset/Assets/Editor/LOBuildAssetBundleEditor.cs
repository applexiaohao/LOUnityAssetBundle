using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

/// <summary>
/// 打包编辑器
/// </summary>
public class LOBuildAssetBundleEditor : EditorWindow {

	/// <summary>
	/// 获取不同平台下的包裹存储路径
	/// </summary>
	public static string GetAssetBundlePath(BuildTarget target)
	{
		string opp = "";

		opp += Application.persistentDataPath;
		opp += "AssetBundles/";

		switch (target) {
		case BuildTarget.iOS:
			{
				opp += "iOS/";
				break;
			}
		case BuildTarget.StandaloneOSXUniversal:
			{
				opp += "MacOS/";
				break;
			}
		default:
			{
				opp += "Others/";
				break;
			}
		}

		//当在硬盘目录结构里不存在该路径时,创建文件夹
		if (!Directory.Exists(opp)) 
		{
			Directory.CreateDirectory (opp);
		}

		return opp;
	}

	[MenuItem("LOAssetBundles/Build")]
	public static void CustomBuildAssetBundle()
	{
		//包裹存储的路径...
		string outputPath = LOBuildAssetBundleEditor.GetAssetBundlePath(EditorUserBuildSettings.activeBuildTarget);

		//输出路径
		Debug.Log (outputPath);

		//打包过程..
		BuildPipeline.BuildAssetBundles(outputPath);
	}
}
