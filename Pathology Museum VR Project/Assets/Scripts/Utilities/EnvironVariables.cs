using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironVariables : Singleton<EnvironVariables>
{
    // (Optional) Prevent non-singleton constructor use.
    protected EnvironVariables() { }

    // Then add whatever code to the class you need as you normally would.
    public string address = "http://127.0.0.1:10070/assets/";
}
