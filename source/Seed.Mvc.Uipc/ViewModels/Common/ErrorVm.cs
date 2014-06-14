namespace Seed.Web.Uipc.ViewModels
{
    public class ErrorVm
    {
        public string ErrorMessage { get; set; }

        public ErrorType Type { get; set; }
    }

    public enum ErrorType
    {
        PageNotFound,
        ServerError
    }
}