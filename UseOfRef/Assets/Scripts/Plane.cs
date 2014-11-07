using UnityEngine;
using System.Collections;
using System.Threading;
using System.Diagnostics;

public class Plane : MonoBehaviour {

    public static string InfoStr;

    private GameObject _camera;
    private GameObject _sphere;

	// Use this for initialization
	void Start () {
        _camera = UnityEngine.GameObject.Find("Main Camera");
        _sphere = UnityEngine.GameObject.Find("Sphere");
        var text = UnityEngine.GameObject.Find("Text");
        var bc = text.AddComponent<BoxCollider>();
        bc.center = new Vector3(0, 0, 0);
        bc.size = new Vector3(7, 1, 1);
        bc.transform.parent = text.transform;
        Plane.InfoStr += "\n";
	}
	
	// Update is called once per frame
	void Update () {

        HandleTouch();
        


        _sphere.transform.position = 
            RotateAbout(
                _sphere.transform.position, 
                new Vector3(0, 1, 0), // rotate about this point
                new Vector3(0, 1, 0), // on a plane with this normal
                30 * Time.smoothDeltaTime);// 30 degrees per second

	}

    private void OnTouched()
    {
    
        var withRef = 0L;
        var noRef = 0L;
    
        for(var i = 0; i < 30; ++i){
        
          var sw1 = Stopwatch.StartNew();
          TestWithRef();
          sw1.Stop();
          withRef += sw1.ElapsedMilliseconds;
        
          var sw2 = Stopwatch.StartNew();
          TestWithNoRef();
          sw2.Stop();
          noRef += sw2.ElapsedMilliseconds;  
        }
        
        var perc = (withRef * 100f)/noRef;
        Plane.InfoStr += " With Ref:" + withRef + " ms; No Ref:" + noRef + "; With ref is " + perc + "% of no ref \n";
    }
    
    private void TestWithRef(){
        for(var i = 0; i < 100000; ++i){
          var a = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var b = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var c = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var d = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var e = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var f = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var g = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var h = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var j = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var k = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var l = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var m = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var n = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var o = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          
          WithRef(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h, ref j, ref k, ref l, ref m, ref n, ref o);
        }
    }
    private void TestWithNoRef(){
        for(var i = 0; i < 100000; ++i){
          var a = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var b = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var c = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var d = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var e = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var f = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var g = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var h = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var j = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var k = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var l = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var m = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var n = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          var o = new Vector3(1000/(float)i,1000/(float)i,1000/(float)i);
          
          WithNoRef(a, b, c, d, e, f, g, h, j, k, l, m, n, o);
        }
    }
    
    float WithRef(
          ref Vector3 a,
          ref Vector3 b,
          ref Vector3 c,
          ref Vector3 d,
          ref Vector3 e,
          ref Vector3 f,
          ref Vector3 g,
          ref Vector3 h, 
          ref Vector3 j, 
          ref Vector3 k, 
          ref Vector3 l, 
          ref Vector3 m, 
          ref Vector3 n, 
          ref Vector3 o){
         return a.x+b.x+c.x+d.x+e.x+f.x+g.x+
                 h.x+j.x+k.x+l.x+m.x+n.x+o.x;
    }
    float WithNoRef(
          Vector3 a,
          Vector3 b,
          Vector3 c,
          Vector3 d,
          Vector3 e,
          Vector3 f,
          Vector3 g,
          Vector3 h, 
          Vector3 j, 
          Vector3 k, 
          Vector3 l, 
          Vector3 m, 
          Vector3 n, 
          Vector3 o){
         return a.x+b.x+c.x+d.x+e.x+f.x+g.x+
                 h.x+j.x+k.x+l.x+m.x+n.x+o.x; 
    }

    #region utils
    private bool _touching;
    private void HandleTouch()
    {
        var touches = Input.touches;
        var len = touches.Length;
        Vector2 pos2d = new Vector2(0, 0);
        if (len == 0)
        {
            if (Input.GetMouseButton(0))
            {
                pos2d = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
                len = 1;
            }
        }
        else
        {
            pos2d = new Vector2(touches[0].position.x, Screen.height - touches[0].position.y);
        }


        if (len > 0)
        {
            if (!_touching)
            {
                var ray = _camera.camera.ViewportPointToRay(new Vector3(pos2d.x / Screen.width, 1f - pos2d.y / Screen.height, 1f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var hitName = hit.transform.name;
                    if (hitName == "Text")
                    {
                        _touching = true;
                        OnTouched();
                    }
                }
            }            
            return;
        }
        if (_touching)
        {
            _touching = false;
        }
        
    }

    public static Vector3 RotateAbout(Vector3 point, Vector3 pivot, Vector3 axis, float degrees)
    {
        return (Quaternion.AngleAxis(degrees, axis) * (point - pivot)) + pivot;
    }
    #endregion
}
