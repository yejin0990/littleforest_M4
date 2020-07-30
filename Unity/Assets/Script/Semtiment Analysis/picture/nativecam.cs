
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class nativecam : MonoBehaviour
{
    public static nativecam instance;
    private string path;
    public byte[] bytes;

    private void Awake()
    {
        instance = this;

        //path 지정
        path = Application.persistentDataPath + "/ mnt / sdcard / Android / data / com.m4.LittleForest / files";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    //카메라 여는 함수
    public void takepicture()
    {
        if (NativeCamera.IsCameraBusy())
            return;
        TakePicture(512);

    }

    //Native Camera 에셋 -> https://github.com/yasirkula/UnityNativeCamera 지침 참조
    private void TakePicture(int maxSize)
    {
        //안드로이드 카메라 권한
        NativeCamera.Permission permission = NativeCamera.TakePicture((PATH) =>
        {
            Debug.Log("Image path: " + PATH);
            if (PATH != null)
            {
                // 선택된 이미지의 Texture 생성
                Texture2D texture = NativeCamera.LoadImageAtPath(PATH, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + PATH);
                    return;
                }

                //texture를 byte로 변환
                texture = duplicateTexture(texture);
                bytes = texture.EncodeToPNG();
                Debug.Log("nativecam   " + bytes[0]);
                
                //path에 저장
                FileStream fs = new FileStream(path + "test.png", FileMode.Create, FileAccess.Write);
                byte[] data = bytes;
                fs.Write(data, 0, (int)data.Length);
                Debug.Log("저장 완료");
                fs.Close();

                Destroy(texture, 5f);

                socket.instance.ImageServer_C();
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }

    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

}
