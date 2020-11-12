using MyHomeMVC.Views;

namespace MyHomeMVC.Controllers
{
    public abstract class ControllerBase
    {
        public abstract ViewRequest Run(ViewResult viewResult);
    }
}
