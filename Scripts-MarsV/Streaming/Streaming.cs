using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Streaming : MonoBehaviour
{

    [DllImport("StreamingPlugin102", EntryPoint = "setup", CallingConvention = CallingConvention.Cdecl)]
    private static extern void setup();

    [DllImport("StreamingPlugin102", EntryPoint = "start", CallingConvention = CallingConvention.Cdecl)]
    private static extern int start(string url, int width, int height, int fps, int bitrate);

    [DllImport("StreamingPlugin102", EntryPoint = "sendVideoFrame", CallingConvention = CallingConvention.Cdecl)]
    private static extern int sendVideoFrame(IntPtr data);

    [DllImport("StreamingPlugin102", EntryPoint = "stop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int stop();

    public RenderTexture renderTexture2;
    public Texture2D texture1;
    private bool streaming = false;
    private int frameCounter;

    void Start()
    {
        //Application.targetFrameRate = 30;
        texture1 = new Texture2D(renderTexture2.width, renderTexture2.height);
        setup();
        frameCounter = 0;
        streaming = true;
        //int result = start("udp://127.0.0.1:1234", renderTexture.width, renderTexture.height, 60, 2000000);
        int result = start("udp://192.168.0.102:1234", renderTexture2.width, renderTexture2.height, 60, 2000000);
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

            RenderTexture tempRenderTexture = RenderTexture.GetTemporary(renderTexture2.width, renderTexture2.height, 0, renderTexture2.format);
            RenderTexture.active = tempRenderTexture;
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, renderTexture2.width, 0, renderTexture2.height);
            Graphics.DrawTexture(new Rect(0, 0, renderTexture2.width, renderTexture2.height), renderTexture2);
            GL.PopMatrix();
            texture1.ReadPixels(new Rect(0, 0, renderTexture2.width, renderTexture2.height), 0, 0);
            texture1.Apply();
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(tempRenderTexture);
            /**/

            Color32[] color32 = texture1.GetPixels32();
            GCHandle dataHandle = GCHandle.Alloc(color32, GCHandleType.Pinned);
            sendVideoFrame(dataHandle.AddrOfPinnedObject());
            dataHandle.Free();

            frameCounter++;

            /*if (Input.GetKeyDown("q"))
            {
                Application.Quit();
            }*/
        }
    }

    void OnGUI()
    {
        //if (streaming) GUI.Button(new Rect(0, 0, 150, 50), "STREAMING1 " + frameCounter);
    }

    void OnApplicationQuit()
    {
    }
}
