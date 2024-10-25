using UnityEditor.Scripting.Python;
using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using System.IO;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using System;

public class Generation : MonoBehaviour
{
    jsonLoad load = new jsonLoad();
    jsonLoad.Map objets = new jsonLoad.Map();
    GameObject objet;
    public TextAsset jsonFile;
    string path = "";
    public GameObject initialObjects;
    public GameObject toActivate;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        /*  Create buttons for each png sprite (map) in the Maps folder
         *  Mettre l'action du script sur RunMainPython2 avec le nom du fichier en paramètres

        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Maps");
        FileInfo[] info = dir.GetFiles("*.png");
        info.Select(f => f.FullName).ToList();
        foreach (FileInfo file in info)
        {
            UnityEngine.Debug.Log(file.FullName);
        }*/
    }

    private void Awake()
    {
        //Task task = RunMainPython2(/*"test.PNG"*/);
        /*loadJson();
        generateMap();*/

    }
    // Update is called once per frame
    void Update()
    {
        
            
    }

    [MenuItem("Python/mainRunner")]
    static void RunMainPython3(/*string filename*/)
    {
        UnityEngine.Debug.Log(PythonRunner.PythonInterpreter);
        UnityEngine.Debug.Log(System.IO.Directory.GetCurrentDirectory());
        PythonRunner.RunFile("Assets/main.py");/*{filename}*/
        //PythonRunner.RunFile($"{Application.dataPath}/main.py");

        /*Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = "python.exe";
        startInfo.Arguments = $"/C python {Application.dataPath}/main.py";
        process.StartInfo = startInfo;
        process.Start();*/

        /*Process p = new Process();
        p.StartInfo = new ProcessStartInfo("C:\\Program Files\\WindowsApps\\PythonSoftwareFoundation.Python.3.10_3.10.3056.0_x64__qbz5n2kfra8p0\\python3.10.exe", "C:\\Users\\maior\\Unity\\PST 5A\\Assets\\main.py")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        Console.InputEncoding = Encoding.UTF8;
        p.Start();

        UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());
        //p.StandardInput.WriteLine("\n hi \n");
        UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());

        p.WaitForExit();*/
    }

    [MenuItem("Python/main")]
    static async private Task RunMainPython2(string filename)
    {
        UnityEngine.Debug.Log("RunMainPython");

        string[] packages = PythonSettings.GetSitePackages();

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = $"{System.IO.Directory.GetCurrentDirectory()}\\Library\\PythonInstall\\python.exe"; // Ensure python is in your system's PATH
        startInfo.Arguments = $"{Application.dataPath}/main.py {Application.dataPath}/Resources/Maps/" + filename; // Add filename if needed
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;

        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();

            

            // Reading standard output (optional)
            string output = await process.StandardOutput.ReadToEndAsync();
            UnityEngine.Debug.Log(output);

            // Reading standard error (optional)
            string error = await process.StandardError.ReadToEndAsync();
            if (!string.IsNullOrEmpty(error))
            {
                UnityEngine.Debug.LogError(error);
            }

            
        }
        AssetDatabase.Refresh();
        
    }

    public void RunMainPython()
    {
        string[] packages = PythonSettings.GetSitePackages();

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = $"{System.IO.Directory.GetCurrentDirectory()}\\Library\\PythonInstall\\python.exe"; // Ensure python is in your system's PATH
        startInfo.Arguments = $"{Application.dataPath}/main.py"; // Add filename if needed
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;

        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.Start();



            /*// Reading standard output (optional)
            string output = await process.StandardOutput.ReadToEndAsync();
            UnityEngine.Debug.Log(output);

            // Reading standard error (optional)
            string error = await process.StandardError.ReadToEndAsync();
            if (!string.IsNullOrEmpty(error))
            {
                UnityEngine.Debug.LogError(error);
            }*/



        }
        AssetDatabase.Refresh();
    }
    public void loadJson()
    {
        objets = load.createJson(jsonFile);
        UnityEngine.Debug.Log("Load OK");
    }

    public void generateMap()
    {
        toActivate.SetActive(true);
        foreach (jsonLoad.mapData map in objets.area)
        {
            UnityEngine.Debug.Log(map.shape);
            UnityEngine.Debug.Log(map.color);
            generateObject(map.X, map.Y, map.color, map.angle, map.shape);
        }
        initialObjects.SetActive(false);
    }

    public void generateObject(float xPos, float yPos, string color, float angle, string shape)
    {
        Vector3 position = new Vector3(xPos/10, 0, yPos/10);
        Quaternion rotation = Quaternion.identity;
        path = "";
        //path = shapePath(shape);
        path = colorPath(color);
        if(color == "red")
        {
            position.y = 2;
            UnityEngine.Debug.Log(position);
        }
        path += "Player";

        /*switch (marque)
        {
            case "player":
                objet = Resources.Load("Player") as GameObject;
                break;

            case "triangle":
                objet = Resources.Load("None/") as GameObject;
                break;

            case "star":
                objet = Resources.Load("None/") as GameObject;
                break;

            case "small star":
                objet = Resources.Load("None/") as GameObject;
                break;

            case "circle": 
                objet = Resources.Load("Circle/") as GameObject;
                break;

            case "rectangle": 
                objet = Resources.Load("Square/") as GameObject;
                break;

            case "pentagon":
                objet = Resources.Load("Square/") as GameObject;
                break;

            case "hexagon":
                objet = Resources.Load("Square/") as GameObject;
                break;

            default: break;
        }*/

        objet = Resources.Load(path) as GameObject;
        GameObject spawnedObject = Instantiate(objet, position, Quaternion.identity) as GameObject;
        if(color == "red")
        {
            GameObject cam = spawnedObject.gameObject.GetNamedChild("XR Origin (XR Rig)");
            cam.transform.position = new Vector3(0,0,0);
        }
    }

    public string shapePath(string shape)
    {
        path += shape + "/";
        return path;
    }

    public string colorPath(string color)
    {
        path += color + "/";
        return path;
    }

    public enum marques
    {
        None, Circle, Square, Angle, Player
    }

    public enum couleurs
    {
        gris, vert, bleu, rouge, jaune, orange, noir, blanc,
    }

    public void clickDemo()
    {
        Task task = RunMainPython2("Test.png");
    }
    public void clickTestPixel()
    {
        Task task = RunMainPython2("Test2.png");
    }

    public void pregen()
    {
        loadJson();
        generateMap();
    }

    public void fadeBeforePregen(Animator anim)
    {
        anim.SetBool("Fade", true);
        pregen();
    }
}
