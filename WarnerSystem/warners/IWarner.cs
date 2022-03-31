using System.Threading.Tasks;

namespace WarnerSystem.warners
{
    public interface IWarner
    {

        public string GetTitle();

        public Task StartWarner();
        public void StopWarner();
        public string GetWarnerStatus();
        public void InfoWindowFillout();
        public void InfoWindowUpdate();
        public void InfoWindowClear();
    }
}
