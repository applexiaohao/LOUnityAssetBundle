// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace LOAssetFramework
{
	public sealed class LOAssetBundle
	{
		internal AssetBundle m_AssetBundle;
		internal string 	 m_AssetBundleName;
		internal LOAssetBundle(AssetBundle assetBundle,string name)
		{
			this.m_AssetBundle = assetBundle;
			this.m_AssetBundleName = name;
			this.m_ReferencedCount = 1;
		}
		
		#region ReferenceCountManage
		//yinyongjishujizhi
		private int m_ReferencedCount;
		public void Retain()
		{
			this.m_ReferencedCount++;
		}
		public void Release(){
			this.m_ReferencedCount--;
			//当引用计数为0时,卸载资源
			if (this.m_ReferencedCount == 0) 
			{
				this.m_AssetBundle.Unload (true);
				LOAssetCache.FreeBundle(this.m_AssetBundleName);
			}
		}
		
		public int RetainCount()
		{
			return this.m_ReferencedCount;
		}
		#endregion
		
	}
}
