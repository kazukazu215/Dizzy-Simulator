using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using System.Linq;
#endif

public class UpdateShader : MonoBehaviour {
	[SerializeField] Material[] mats;

#if UNITY_EDITOR
	void Awake () {
		// 登録したマテリアルのシェーダーを更新	
		foreach (var mat in mats) {
			mat.shader = Shader.Find (mat.shader.name);
		}
	}

	void Reset () 
	{	
		// シーン内のマテリアルを収集する
		List<Material> matList = new List<Material> ();
		matList.AddRange( GameObject.FindObjectsOfType<MeshRenderer> ().SelectMany( c => c.sharedMaterials) );
		matList.AddRange (GameObject.FindObjectsOfType<SkinnedMeshRenderer> ().SelectMany (c => c.sharedMaterials));
		mats = matList.Distinct().ToArray ();
	}
#endif
}
