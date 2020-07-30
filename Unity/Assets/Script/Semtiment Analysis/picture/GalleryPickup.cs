using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GalleryPickup : MonoBehaviour
{
    public static GalleryPickup instance;
    public byte[] bytes;

    private void Awake()
    {
        instance = this;
    }
        
    
    //갤러리에서 사진을 고르는 함수
    public void sajingolra()
    {
        if (NativeGallery.IsMediaPickerBusy())
            return;

        PickImage(512);
    }
    //NativeGallery 에셋-> https://github.com/yasirkula/UnityNativeGallery 지침활용
    private void PickImage(int maxSize)
	{
        //안드로이드 갤러리접근
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				// 선택된 이미지의 Texture 생성
				Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}
                //texture를 byte로 변환
                texture = duplicateTexture(texture);
                bytes = texture.EncodeToPNG();
                Debug.Log("GallyPickup   " + bytes[0]);
                

                Destroy(texture, 5f);

                socket.instance.ImageServer_G();
            }
		}, "Select a PNG image", "image/png");

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
