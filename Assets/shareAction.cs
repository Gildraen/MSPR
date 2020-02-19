﻿using System.Collections;
using System.IO;
using UnityEngine;

public class shareAction : MonoBehaviour
{

    private void test() {
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("My Title").SetText("#cerealis #coloring #AR").Share();
    }
    private IEnumerator TakeSSAndShare() {
        yield return new WaitForEndOfFrame();

        test();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }
    

    public void ShareActivity() {
        /*CreateActivity();
        AndroidJavaObject sharingIntent = new AndroidJavaObject("android.content.Intent", "android.intent.action.SEND")
                          .Call<AndroidJavaObject>("setType", "text/plain")
                          .Call<AndroidJavaObject>("putExtra", "android.intent.extra.TEXT", "a test body")
                          .Call<AndroidJavaObject>("putExtra", "android.intent.extra.SUBJECT", "test subject");

        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", activity)
                          .CallStatic<AndroidJavaObject>("createChooser", sharingIntent, "test title");
        activity.Call("startActivity", intent);*/
        /*
        //create intent for action send
        AndroidJavaClass intentClass = new
                         AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new
                          AndroidJavaObject("android.content.Intent");

        //set action to that intent object   
        intentObject.Call<AndroidJavaObject>
        ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        intentObject.Call<AndroidJavaObject>("putExtra",
                    intentClass.GetStatic<string>("EXTRA_SUBJECT"), "test subject");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "test message");
        */
        StartCoroutine(TakeSSAndShare());
    }
    /*int i = 0;
    void Update() {
        int width = Screen.width;
        int height = Screen.height;
        Vector3 pos = _button.transform.position;
        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
            pos.x = (width / 2) - _button.GetComponent<RectTransform>().rect.width - 20;
            pos.y = _button.GetComponent<RectTransform>().rect.height + 10 - (height / 2);
        }else {
            pos.y = (width / 2) - _button.GetComponent<RectTransform>().rect.width - 20;
            pos.x = _button.GetComponent<RectTransform>().rect.height + 10 - (height / 2);

        }
        if (i == 0) {
            Debug.Log("Screen w" + width);
            Debug.Log("Screen h" + height);
            Debug.Log(pos.x);
            Debug.Log(pos.y);
            i++;

        }
        _button.transform.position = pos;

    }

    void Start() {
        _button = GameObject.Find("Button").GetComponent<Button>();
    }
    */
}
