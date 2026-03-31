namespace Editor.UIPanelTool
{
    public class ControlStrInfo
    {
        public string nameStr;
        public string findStr;
        public string listenerStr;
        public string funcStr;

        public static ControlStrInfo operator +(ControlStrInfo one, ControlStrInfo two)
        {
            one.nameStr += two.nameStr;
            one.findStr +=  two.findStr;
            one.listenerStr  += two.listenerStr;
            one.funcStr  += two.funcStr;
            return one;
        }
    }
}
