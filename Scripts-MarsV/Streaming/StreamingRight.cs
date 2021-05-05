using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class StreamingRight : MonoBehaviour
{

    [DllImport("StreamingPlugin103", EntryPoint = "setup", CallingConvention = CallingConvention.Cdecl)]
    private static extern void setup();

    [DllImport("StreamingPlugin103", EntryPoint = "start", CallingConvention = CallingConvention.Cdecl)]
    private static extern int start(string url, int width, int height, int fps, int bitrate);

    [DllImport("StreamingPlugin103", EntryPoint = "sendVideoFrame", CallingConvention = CallingConvention.Cdecl)]
    private static extern int sendVideoFrame(IntPtr data);

    [DllImport("StreamingPlugin103", EntryPoint = "stop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int stop();

    public RenderTexture renderTexture;
    public Texture2D texture;
    private bool streaming = false;
    private int frameCounter;

    void Start()
    {
        //Application.targetFrameRate = 30;
        texture = new Texture2D(renderTexture.width, renderTexture.height);
        setup();
        frameCounter = 0;
        streaming = true;
        //int result = start("udp://127.0.0.1:1234", renderTexture.width, renderTexture.height, 60, 2000000);
        int result = start("udp://192.168.0.103:1234", renderTexture.width, renderTexture.height, 60, 2000000);
        Debug.Log("Start " + result);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("1"))
        {
            frameCounter = 0;
            streaming = true;
            //int result = start("udp://127.0.0.1:1234", renderTexture.width, renderTexture.height, 60, 2000000);
            int result = start("udp://192.168.0.255:1234", renderTexture.width, renderTexture.height, 60, 2000000);
            Debug.Log("Start " + result);
        }*/

        /*if (Input.GetKeyDown("2"))
        {
            streaming = false;
            stop();
            Debug.Log("Stop");
        }*/

        if (streaming)
        {
            /*
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
            RenderTexture.active = null;
            */

            /**/
            RenderTexture tempRenderTexture = RenderTexture.GetTemporary(renderTexture.width, renderTexture.height, 0, renderTexture.format);
            RenderTexture.active = tempRenderTexture;
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, renderTexture.width, 0, renderTexture.height);
            Graphics.DrawTexture(new Rect(0, 0, renderTexture.width, renderTexture.height), renderTexture);
            GL.PopMatrix();
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(tempRenderTexture);
            /**/

            Color32[] color32 = texture.GetPixels32();
            GCHandle dataHandle = GCHandle.Alloc(color32, GCHandleType.Pinned);
            sendVideoFrame(dataHandle.AddrOfPinnedObject());
            dataHandle.Free();

            frameCounter++;

        }
    }

    void OnGUI()
    {
        if (streaming)
        {
            //GUI.Button(new Rect(0, 0, 300, 50), "STREAMING " + frameCounter);
            //print("Hago stream lado derecho");
        }
    }

    void OnApplicationQuit()
    {
    }
}
