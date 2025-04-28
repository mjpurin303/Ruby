using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using DG.Tweening;

public class ImageController2 : MonoBehaviour
{
    string url = "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEiPz936DPLjBT11FxCGKXrA45UPuNvGINDy-cmq9-IAQ3gHisCphf9sHu_zYmYCon0DcC_CDCBj7PTcojyEtl-4SEI8EsTiYF4lQbe2zjBQfYz2J2nphc0ge_juZDb1aQ1SmpuowGsvSY76qzlOcTEkps8_jW5hcgOycBQZlQjNfepnFYb7Ux0UoxTw89wT/s180-c/pose_hoppe_heart_schoolgirl.png";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetRequest(string uri){
        using(UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }else{
                Texture texture = DownloadHandlerTexture.GetContent(uwr);
                Sprite sp = Sprite.Create(
                    (Texture2D)texture,
                    new Rect(0,0,texture.width,texture.height),
                    new Vector2(0.5f,0.5f));
                Image image = GetComponent<Image>();
                image.rectTransform.sizeDelta=new Vector2(sp.rect.width,sp.rect.height);
                //image.rectTransform.pivot=new Vector2(0f,0f);
                image.sprite=sp;
                image.transform.DORotate(new Vector3(0f,0f,360f),2f,RotateMode.FastBeyond360)
                .SetDelay(2f);
            }
            
        }
    }
}
