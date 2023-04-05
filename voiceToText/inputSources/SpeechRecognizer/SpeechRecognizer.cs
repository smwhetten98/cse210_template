using System;
using System.Speech.Recognition;

public class SpeechRecognizer: InputSource
{
    private Grammar _g;
    private SpeechRecognitionEngine _recognizer;

    public SpeechRecognizer()
    {
        SpeechOptions speechOptions = new SpeechOptions(Program.GetRepository());
        Grammar g = new Grammar(new GrammarBuilder(speechOptions.GetLibrary()));
        
        _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        _recognizer.LoadGrammar(g);
        _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_SpeechRecognized);
        _recognizer.SetInputToDefaultAudioDevice();
    }

    public override void Start()
    {
        _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        while (!base.GetIsProgramEnded())
        {
            string s = Console.ReadLine();
        }
    }

    public override void HandleInvalidUserRequest()
    {
        // Handle when user asks for something not in command list
    }

    private void _SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        Program.ProcessInput(e.Result.Text);
        Console.WriteLine($"Heard \"{e.Result.Text}\"");
    }
}