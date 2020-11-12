using MyHomeMVC.Controllers;

namespace MyHomeMVC.Views
{
    public abstract class ViewBase
    {
        public abstract ControllerRequest View(object model);
    }
}