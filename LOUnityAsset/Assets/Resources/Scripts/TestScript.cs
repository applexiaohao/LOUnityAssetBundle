using UnityEngine;
using System.Collections;
using LOAssetFramework;

public class TestScript : MonoBehaviour {
	
	/// <summary>
	/// 测试加载资源函数
	/// </summary>
	protected IEnumerator Load (string assetBundleName, string level)
	{
		IEnumerator b = da.LoadLevelAsync(assetBundleName);
		yield return StartCoroutine(b);
		Application.LoadLevel(level);
	}

	LOAssetManager da;
	void Start () 
	{
		LOAssetManager.URI = "http://project.lanou3g.com/assetbundles/Others/";
		LOAssetManager.ManifestName = "Others";
		LOAssetManager.InitBlock = ((bool obj) => {
			if (obj) {
				StartCoroutine (Load ("scenes/loaderscene.unity3d", "LoaderScene"));
			}
		});

		da = LOAssetManager.DefaultAssetManager;
	}
}
