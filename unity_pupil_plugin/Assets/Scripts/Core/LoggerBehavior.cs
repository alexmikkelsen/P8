using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoggerBehavior : MonoBehaviour
{

    #region Public editor fields

    //public string PatientName = "control 7";
    public string PatientNameSubjectId = "patient x3";   // Is available in the inspector under the Logger object
    public int SessionNumber = 0;


    #endregion

    public static LoggerBehavior getPatientName;        // So Logger can get PatientNameSubjectID 
                                                        //and Session number through getPatientName


    private static Logger _logger;
    private DateTime _starTime;
    private static List<object> _toLog;
    //private Text dataUItext;

    #region Unity Methods

    private void Start()
    {
        _toLog = new List<object>();
        _starTime = DateTime.Now;

        //dataUItext = GameObject.Find("TextData").GetComponent<Text>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes) == Vector2.zero) return;
        AddToLog();

        //dataUItext.text = PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).x.ToString() + " " +
        PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).y.ToString();

    }

    private void AddToLog()
    {
        var date = DateTime.Now;
        var raycastHit = EyeRay.CurrentlyHit;
        var camera = Camera.main;
        var tmp = new
        {
            a = date.ToString("MM/dd/yy HH:mm:ss"),
            abis = date.Millisecond,
            ater = (date - _starTime).TotalMilliseconds,
            b = PatientNameSubjectId,
            c = SessionNumber,
            cbis = PaintingsSets.CurrentSet.SetName,
            d = camera.transform.position.x,
            e = camera.transform.position.y,
            f = camera.transform.position.z,
            g = camera.transform.rotation.x,
            h = camera.transform.rotation.y,
            i = camera.transform.rotation.z,
            j = PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).x,
            k = PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).y,
            //////////// A VOIR ////////////
            //l = PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).x,
            //m = PupilData._2D.GetEyeGaze(PupilData.GazeSource.BothEyes).y,
            ///////////// ///// //////////// 
            //l = PupilData.
            n = raycastHit.transform != null ? raycastHit.transform.name : "none",
            o = raycastHit.transform != null ? raycastHit.transform.position.x.ToString() : "none",
            p = raycastHit.transform != null ? raycastHit.transform.position.y.ToString() : "none",
            q = raycastHit.transform != null ? raycastHit.transform.position.z.ToString() : "none",
            r = raycastHit.transform != null ? CalculEyeGazeOnObject(raycastHit).x.ToString() : "none",
            s = raycastHit.transform != null ? CalculEyeGazeOnObject(raycastHit).y.ToString() : "none",
            t = raycastHit.transform != null ? CalculEyeGazeOnObject(raycastHit).z.ToString() : "none"
        };
        _toLog.Add(tmp);
    }

    private Vector3 CalculEyeGazeOnObject(RaycastHit hit)
    {
        return hit.transform.InverseTransformPoint(hit.point);
    }

    public static void DoLog()
    {
        _logger = Logger.Instance;
        if (File.ReadAllText(_logger.FullPathLogFile).Equals(""))
        {
            var firstRow = new { a = AppConstants.CsvFirstRow };
            _toLog.Add(firstRow);
        }
        _logger.Log(_toLog.ToArray());
        _toLog.Clear();
        Debug.Log("DoLog");
    }

    #endregion
}
