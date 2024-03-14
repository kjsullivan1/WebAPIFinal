using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Networking;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;


public class JsonSerializer : MonoBehaviour
{
    public DataClass dataObj;
    public string filePath;
    public TMP_InputField playerName, firstName, lastName;
    //public TMP_Text feedback;
    //public TMP_Text allData;
    //public GameObject deleteBtn, editBtn;
    string currID;
    Scene scene;
    DataClass formData = new DataClass();
    // Start is called before the first frame update
    void Start()
    {
       // filePath = Path.Combine(Application.dataPath, "saveData.txt");
       // //dataObj = new DataClass();
       // //dataObj.level = 1;
       // //dataObj.timeElapsed = 44443.232323f;
       // //dataObj.name = "Jordan";
       // string json = JsonUtility.ToJson(dataObj);
       // Debug.Log(json);
       // //StartCoroutine(SendWebData(json));
       // File.WriteAllText(filePath, json);
       // //editBtn.SetActive(false);
       //// deleteBtn.SetActive(false);
       // scene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendButton()
    {
        //var levelData = int.Parse(level.text);
        //var timeData = float.Parse(elapsedTime.text);
        //DataClass formData = new DataClass();
        //formData.level = levelData;
        //formData.timeElapsed = timeData;
        //formData.name = playerName.text;
        //string json = JsonUtility.ToJson(formData);
        //filePath = Path.Combine(Application.dataPath, "formData.txt");
        //File.WriteAllText(filePath, json);
        //StartCoroutine(SendWebData(json));

    }

    //public void GetButton()
    //{
    //    StartCoroutine(GetRequest("http://localhost:3000/getUnity"));
    //   // deleteBtn.SetActive(true);
    //    //editBtn.SetActive(true);
    //}

    //public void GetButtonAll()
    //{
    //    StartCoroutine(GetRequestAll("http://localhost:3000/getUnity"));
    //}

    public void EditButton()
    {
        //var levelData = int.Parse(level.text);
        //var timeData = float.Parse(elapsedTime.text);
        //DataClass formData = new DataClass();
        //formData.level = levelData;
        //formData.timeElapsed = timeData;
        //formData.name = playerName.text;
        //formData._id = currID;
        //string json = JsonUtility.ToJson(formData);
        //StartCoroutine(EditRequest(json));
        //SceneManager.UnloadScene(0);
        //SceneManager.LoadScene(0);
    }
    public void DeleteButton()
    {
        //var levelData = int.Parse(level.text);
        //var timeData = float.Parse(elapsedTime.text);
        //DataClass formData = new DataClass();
        //formData.level = levelData;
        //formData.timeElapsed = timeData;
        //formData.name = playerName.text;
        //formData._id = currID;
        //string json = JsonUtility.ToJson(formData);
        ////filePath = Path.Combine(Application.dataPath, "formData.txt");
        ////File.WriteAllText(filePath, json);

        //StartCoroutine(DeleteRequest(json));
        //SceneManager.UnloadScene(0);
        //SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        var userName = playerName.text;
        var firstName = this.firstName.text;
        var lastName = this.lastName.text;
       
        formData.username = userName;
        formData.firstname = firstName;
        formData.lastname = lastName;
        SceneManager.LoadScene("Game");
    }
    public void EndGame(int score)
    {
        formData.score = score;

        formData.wins = 1;

        string json = JsonUtility.ToJson(formData);

        StartCoroutine(SendWebData(json));
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator SendWebData(string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3000/unity", json, "application-json"))
        {
            request.SetRequestHeader("content-type", "application/json");

            request.uploadHandler.contentType = "application/json";
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Data Posted");
            }
            request.uploadHandler.Dispose();
        }
    }

    //IEnumerator DeleteRequest(string json)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3000/deleteUnity", json, "application-json"))
    //    {
    //        request.SetRequestHeader("content-type", "application/json");

    //        request.uploadHandler.contentType = "application/json";
    //        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));

    //        yield return request.SendWebRequest();
    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Data Posted");
    //        }
    //        request.uploadHandler.Dispose();
    //    }
    //}

    //IEnumerator EditRequest(string json)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3000/updateUnity", json, "application-json"))
    //    {
    //        request.SetRequestHeader("content-type", "application/json");

    //        request.uploadHandler.contentType = "application/json";
    //        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));

    //        yield return request.SendWebRequest();
    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Data Posted");
    //        }
    //        request.uploadHandler.Dispose();
    //    }
    //}

    //IEnumerator SendWebData(string json)
    //{
    //    using (UnityWebRequest request = UnityWebRequest.Post("http://localhost:3000/unity", json, "application-json"))
    //    {
    //        request.SetRequestHeader("content-type", "application/json");

    //        request.uploadHandler.contentType = "application/json";
    //        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));

    //        yield return request.SendWebRequest();

    //        if (request.result != UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log(request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Data Posted");
    //        }
    //        request.uploadHandler.Dispose();
    //    }
    //}

    //IEnumerator GetRequest(string uri)
    //{
    //    using (UnityWebRequest getRequest = UnityWebRequest.Get(uri))
    //    {
    //        yield return getRequest.SendWebRequest();

    //        var newData = System.Text.Encoding.UTF8.GetString(getRequest.downloadHandler.data);
    //        Debug.Log(newData);
    //        var newGetRequestData = JsonUtility.FromJson<DataClass>(newData);
    //        Debug.Log(newGetRequestData);
    //        Debug.Log(newGetRequestData);

    //        //var newGetRoot = JsonUtility.FromJson<Root>(newData);
    //        //Debug.Log(newGetRoot.playerdata[0].level);

    //        //for (int i = 0; i < newGetRoot.playerdata.Length; i++)
    //        //{
    //        //    if (newGetRoot.playerdata[i].name == playerName.text)
    //        //    {
    //        //        level.text = newGetRoot.playerdata[i].level.ToString();
    //        //        elapsedTime.text = newGetRoot.playerdata[i].timeElapsed.ToString();
    //        //        currID = newGetRoot.playerdata[i]._id;
    //        //        break;
    //        //    }
    //        //    if (i == newGetRoot.playerdata.Length - 1)
    //        //    {
    //        //        feedback.text = "Feedback: User not Found";
    //        //    }
    //        //    Debug.Log(newGetRoot.playerdata[i].name);
    //        //    Debug.Log(newGetRoot.playerdata[i].level);
    //        //    Debug.Log(newGetRoot.playerdata[i].timeElapsed);

    //        //}


    //        //Debug.Log(newGetRequestData.name);
    //        //Debug.Log(newGetRequestData.level);
    //        //Debug.Log(newGetRequestData.timeElapsed);
    //    }
    //}


    //IEnumerator GetRequestAll(string uri)
    //{
    //    using (UnityWebRequest getRequest = UnityWebRequest.Get(uri))
    //    {
    //        yield return getRequest.SendWebRequest();

    //        var newData = System.Text.Encoding.UTF8.GetString(getRequest.downloadHandler.data);
    //        Debug.Log(newData);
    //        var newGetRequestData = JsonUtility.FromJson<DataClass>(newData);
    //        Debug.Log(newGetRequestData);
    //        Debug.Log(newGetRequestData);

    //        //var newGetRoot = JsonUtility.FromJson<Root>(newData);
    //        //Debug.Log(newGetRoot.playerdata[0].level);
    //        //List<string> names = new List<string>();
    //        //for (int i = 0; i < newGetRoot.playerdata.Length; i++)
    //        //{
    //        //    names.Add(newGetRoot.playerdata[i].name);

    //        //    //allData.text += "Player name: "

    //        //    //if (newGetRoot.playerdata[i].name == playerName.text)
    //        //    //{
    //        //    //    level.text = newGetRoot.playerdata[i].level.ToString();
    //        //    //    elapsedTime.text = newGetRoot.playerdata[i].timeElapsed.ToString();
    //        //    //    break;
    //        //    //}
    //        //    //if (i == newGetRoot.playerdata.Length - 1)
    //        //    //{
    //        //    //    feedback.text = "Feedback: User not Found";
    //        //    //}
    //        //    //Debug.Log(newGetRoot.playerdata[i].name);
    //        //    //Debug.Log(newGetRoot.playerdata[i].level);
    //        //    //Debug.Log(newGetRoot.playerdata[i].timeElapsed);

    //        //}
    //        //names.Sort();
    //        //Debug.Log(names[1]);
    //        //for (int j = 0; j < names.Count; j++)
    //        //{
    //        //    for (int i = 0; i < newGetRoot.playerdata.Length; i++)
    //        //    {

    //        //        if (newGetRoot.playerdata[i].name == names[j])
    //        //        {

    //        //            allData.text += "Player name: " + newGetRoot.playerdata[i].name +
    //        //                            "\t Level: " + newGetRoot.playerdata[i].level.ToString() +
    //        //                            "\t Time: " + newGetRoot.playerdata[i].timeElapsed.ToString() + "\n";
    //        //        }
    //        //        //newGetRoot.playerdata[i].name = "Hello";
    //        //    }
    //        //}


    //        //Debug.Log(newGetRequestData.name);
    //        //Debug.Log(newGetRequestData.level);
    //        //Debug.Log(newGetRequestData.timeElapsed);
    //    }
    //}
}
