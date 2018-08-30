using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class GetPreviewWindow : EditorWindow
{
    private Object asset;

    [MenuItem("Window/GetPreview")]
    public static void ShowWindow()
    {
        var w = GetWindow<GetPreviewWindow>("GetPreview");
        w.minSize = new Vector2(100, 100);
        w.Show();
    }

    private void OnGUI()
    {
        asset = EditorGUILayout.ObjectField("Asset", asset, typeof(Object));

        if (GUILayout.Button("Export texture"))
            ExportTexture();
    }

    private void ExportTexture()
    {
        var path = Application.dataPath + "/" + asset.name + ".png";
        var texture = AssetPreview.GetAssetPreview(asset);

        File.WriteAllBytes(path, texture.EncodeToPNG());
        AssetDatabase.Refresh();
    }
}
