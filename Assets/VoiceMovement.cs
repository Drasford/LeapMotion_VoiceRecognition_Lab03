using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("forward", Forward);
        actions.Add("back", Back);
        actions.Add("left", Left);
        actions.Add("right", Right);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("go", Go);

        rig = GetComponent<Rigidbody>();

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizeSpeech;
        keywordRecognizer.Start();

    }

     void Update()
    {
        
    }


    private void RecognizeSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    // Update is called once per frame
    private void Forward()
    {
        
        transform.Translate(1, 0, 0);
    }
    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }
    private void Up()
    {
        transform.Translate(0, 1, 0);
    }
    private void Down()
    {
        transform.Translate(0 , -1, 0);
    }
    private void Left()
    {
        transform.Translate(0, 0, -1);
    }
    private void Right()
    {
        transform.Translate(0, 0, 1);
       
    }
    private void Go()
    {
        Vector3 movement = new Vector3(0, 0, 0.7f) * 7 * Time.deltaTime;
        rig.MovePosition(transform.position + movement);
        
    }
}
