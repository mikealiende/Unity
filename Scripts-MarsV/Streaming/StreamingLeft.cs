using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class StreamingLeft : MonoBehaviour
{

    [DllImport("StreamingPlugin", EntryPoint = "setup", CallingConvention = CallingConvention.Cdecl)]
    private static extern void setup();

    [DllImport("StreamingPlugin", EntryPoint = "start", CallingConvention = CallingConvention.Cdecl)]
    private static extern int start(string url, int width, int height, int fps, int bitrate);

    [DllImport("StreamingPlugin", EntryPoint = "sendVideoFrame", CallingConvention = CallingConvention.Cdecl)]
    private static extern int sendVideoFrame(IntPtr data);

    [DllImport("StreamingPlugin", EntryPoint = "stop", CallingConvention = CallingConvention.Cdecl)]
    private static extern int stop();

    public RenderTexture renderTexture1;
    public Texture2D texture2;
    private bool streaming = false;
    private int frameCounter;

    void Start()
    {
        //Application.targetFrameRate = 30;
        texture2 = new Texture2D(renderTexture1.width, renderTexture1.height);
        setup();
        frameCounter = 0;
        streaming = true;
        //int result = start("udp://127.0.0.1:1234", renderTexture.width, renderTexture.height, 60, 2000000);
        int result = start("udp://192.168.0.101:1234", renderTexture1.width, renderTexture1.height, 60, 2000000);
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
            RenderTexture tempRenderTexture = RenderTexture.GetTemporary(renderTexture1.width, renderTexture1.height, 0, renderTexture1.format);
            RenderTexture.active = tempRenderTexture;
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, renderTexture1.width, 0, renderTexture1.height);
            Graphics.DrawTexture(new Rect(0, 0, renderTexture1.width, renderTexture1.height), renderTexture1);
            GL.PopMatrix();
            texture2.ReadPixels(new Rect(0, 0, renderTexture1.width, renderTexture1.height), 0, 0);
            texture2.Apply();
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(tempRenderTexture);
            /**/

            Color32[] color32 = texture2.GetPixels32();
            GCHandle dataHandle = GCHandle.Alloc(color32, GCHandleType.Pinned);
            sendVideoFrame(dataHandle.AddrOfPinnedObject());
            dataHandle.Free();

            frameCounter++;

        }
    }

    void OnGUI()
    {
        //if (streaming) GUI.Button(new Rect(0, 0, 150, 50), "STREAMING " + frameCounter);
    }

    void OnApplicationQuit()
    {
    }
}
