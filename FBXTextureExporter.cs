using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class FBXTextureExporter : EditorWindow
{
    private GameObject selectedObject;
    private string exportFolderName = "ExportedModel";

    [MenuItem("Tools/FBX + Texture Exporter")]
    public static void ShowWindow()
    {
        GetWindow<FBXTextureExporter>("FBX Texture Exporter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Unity FBX + Texture Dışa Aktarıcı", EditorStyles.boldLabel);
        GUILayout.Space(10);

        selectedObject = (GameObject)EditorGUILayout.ObjectField(
            "Model Seç:", 
            selectedObject, 
            typeof(GameObject), 
            true
        );

        GUILayout.Space(5);
        
        exportFolderName = EditorGUILayout.TextField("Klasör Adı:", exportFolderName);
        
        GUILayout.Space(10);

        if (GUILayout.Button("Masaüstüne Dışa Aktar", GUILayout.Height(30)))
        {
            ExportModelWithTextures();
        }

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(
            "Seçili modeli FBX olarak ve tüm texture'larını masaüstünde bir klasöre aktarır.",
            MessageType.Info
        );
    }

    private void ExportModelWithTextures()
    {
        if (selectedObject == null)
        {
            EditorUtility.DisplayDialog("Hata", "Lütfen bir model seçin!", "Tamam");
            return;
        }

        // Masaüstü yolunu al
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string exportPath = Path.Combine(desktopPath, exportFolderName);

        // Klasörü oluştur
        if (!Directory.Exists(exportPath))
        {
            Directory.CreateDirectory(exportPath);
        }

        // Texture'ları topla
        HashSet<Texture2D> textures = new HashSet<Texture2D>();
        Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.sharedMaterials)
            {
                if (mat != null)
                {
                    // Material'deki tüm texture'ları bul
                    Shader shader = mat.shader;
                    for (int i = 0; i < ShaderUtil.GetPropertyCount(shader); i++)
                    {
                        if (ShaderUtil.GetPropertyType(shader, i) == ShaderUtil.ShaderPropertyType.TexEnv)
                        {
                            string propName = ShaderUtil.GetPropertyName(shader, i);
                            Texture2D tex = mat.GetTexture(propName) as Texture2D;
                            if (tex != null)
                            {
                                textures.Add(tex);
                            }
                        }
                    }
                }
            }
        }

        // Texture'ları kopyala
        string texturesFolder = Path.Combine(exportPath, "Textures");
        if (!Directory.Exists(texturesFolder))
        {
            Directory.CreateDirectory(texturesFolder);
        }

        int textureCount = 0;
        foreach (Texture2D texture in textures)
        {
            string assetPath = AssetDatabase.GetAssetPath(texture);
            if (!string.IsNullOrEmpty(assetPath))
            {
                string fileName = Path.GetFileName(assetPath);
                string destPath = Path.Combine(texturesFolder, fileName);
                
                try
                {
                    File.Copy(assetPath, destPath, true);
                    textureCount++;
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning($"Texture kopyalanamadı: {fileName} - {e.Message}");
                }
            }
        }

        // FBX dışa aktarma
        string fbxFileName = selectedObject.name + ".fbx";
        string fbxPath = Path.Combine(exportPath, fbxFileName);
        
        bool fbxExported = false;
        
        #if UNITY_EDITOR
        try
        {
            // Unity FBX Exporter kullanarak export et
            UnityEditor.Formats.Fbx.Exporter.ModelExporter.ExportObject(fbxPath, selectedObject);
            fbxExported = true;
            Debug.Log($"FBX başarıyla dışa aktarıldı: {fbxPath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"FBX Export hatası: {e.Message}");
            Debug.LogError("FBX Exporter package yüklü mü kontrol edin: Window > Package Manager > FBX Exporter");
        }
        #endif
        
        if (!fbxExported)
        {
            EditorUtility.DisplayDialog(
                "FBX Export Başarısız", 
                "FBX dosyası oluşturulamadı!\n\n" +
                "Çözüm: Window > Package Manager > Unity Registry > 'FBX Exporter' yükleyin\n\n" +
                "Texture'lar başarıyla kopyalandı.", 
                "Tamam"
            );
        }

        // README dosyası oluştur
        string readmePath = Path.Combine(exportPath, "README.txt");
        File.WriteAllText(readmePath, 
            $"Model: {selectedObject.name}\n" +
            $"Dışa Aktarma Tarihi: {System.DateTime.Now}\n" +
            $"Texture Sayısı: {textureCount}\n" +
            $"FBX Durumu: {(fbxExported ? "Başarılı" : "Başarısız - FBX Exporter package gerekli")}\n" +
            $"\nTexture'lar 'Textures' klasöründe bulunmaktadır.");

        if (fbxExported)
        {
            EditorUtility.DisplayDialog(
                "Başarılı!", 
                $"Model ({fbxFileName}) ve {textureCount} texture masaüstüne aktarıldı!\n\nKonum: {exportPath}", 
                "Tamam"
            );
        }

        // Klasörü aç
        EditorUtility.RevealInFinder(exportPath);
    }
}
