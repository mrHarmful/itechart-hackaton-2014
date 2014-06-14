using Seed.Utilities;

namespace Seed.Web.Uipc.ViewModels
{
    public class ImageVm
    {
        private string _src;

        public string Src
        {
            get { return _src = _src.IsNullOrEmpty() ? OnErrorSrc : _src; }
            set { _src = value; }
        }

        public string Alt { get; set; }

        public virtual string OnErrorSrc
        {
            get { return string.Empty; }
        }

        public bool IsStub
        {
            get { return Src.Equals(OnErrorSrc); }
        }
    }
}