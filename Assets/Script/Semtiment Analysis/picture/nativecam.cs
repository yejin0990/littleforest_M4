
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

        path = Application.persistentDataPath + "/ mnt / sdcard / Android / data / com.m4.LittleForest / files";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {



    }


    public void takepicture()
    {
        // Don't attempt to use the camera if it is already open
        if (NativeCamera.IsCameraBusy())
            return;
        TakePicture(512);

    }


    private void TakePicture(int maxSize)
    {

        NativeCamera.Permission permission = NativeCamera.TakePicture((PATH) =>
        {
            Debug.Log("Image path: " + PATH);
            if (PATH != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(PATH, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + PATH);
                    return;
                }

                //image.sprite = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2(0,0));
                texture = duplicateTexture(texture);
                bytes = texture.EncodeToPNG();
                Debug.Log("nativecam   " + bytes[0]);
                
                //path에 저장!_!
                FileStream fs = new FileStream(path + "test.png", FileMode.Create, FileAccess.Write);
                byte[] data = bytes;
                fs.Write(data, 0, (int)data.Length);
                Debug.Log("저장 완료");
                fs.Close();

                /*
                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);


                Material material = quad.GetComponent<Renderer>().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

                Destroy(quad, 5f);
                */

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
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
