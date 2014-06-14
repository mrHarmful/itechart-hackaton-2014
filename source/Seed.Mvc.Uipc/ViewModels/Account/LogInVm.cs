using System.ComponentModel.DataAnnotations;

namespace Seed.Web.Uipc.ViewModels
{
    public class LogInVm
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public string ErrorMessage { get; set; }
    }
}
