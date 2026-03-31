using UnityEditor;
using UnityEngine;

namespace Editor.Lesson47_AssetImporter和AssetPostprocessor
{
    public class Lesson47 : AssetPostprocessor
    {
        // AssetPostprocessor-资源导入后处理（对导入的资源进行统一的预处理）

        private void OnPreprocessTexture()
        {
            Debug.Log("纹理设置回调：" + assetPath);

            var importer = assetImporter as TextureImporter;
            if (importer != null)
            {
                importer.textureType = TextureImporterType.Sprite;
                importer.mipmapEnabled = false;
            }
        }

        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("纹理后处理回调：" + texture.name);
            // EditorUtility.CompressTexture(texture, TextureFormat.ETC_RGB4, TextureCompressionQuality.Fast);
        }

        private void OnPreprocessModel()
        {
        }

        private void OnPostprocessModel(GameObject g)
        {
        }

        private void OnPreprocessAudio()
        {
        }

        private void OnPostprocessAudio(AudioClip arg)
        {
        }

        // AssetImporter-资源导入批量设置（对导入的资源进行统一的设置）
    }
}