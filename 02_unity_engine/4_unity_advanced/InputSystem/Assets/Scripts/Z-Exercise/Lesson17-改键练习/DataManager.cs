using UnityEngine;
using UnityEngine.InputSystem;
using Z_Exercise;

public class DataManager
{
    public static DataManager Instance { get; } = new();

    public InputInfo InputInfo { get; }

    private string jsonStr;

    private DataManager()
    {
        InputInfo = new InputInfo();
        jsonStr = Resources.Load<TextAsset>("Lesson17").text;
    }

    public InputActionAsset GetActionAsset()
    {
        var str = jsonStr.Replace("<up>", InputInfo.up);
        str = str.Replace("<down>", InputInfo.down);
        str = str.Replace("<left>", InputInfo.left);
        str = str.Replace("<right>", InputInfo.right);
        str = str.Replace("<fire>", InputInfo.fire);
        str = str.Replace("<jump>", InputInfo.jump);

        return InputActionAsset.FromJson(str);
    }
}
