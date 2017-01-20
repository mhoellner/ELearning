using System.Web;
using Umbraco.Core;

namespace ELearning.Extensions
{
  public static class UserExtensions
  {
    public static int GetCurrentUserId()
    {
      var userService = ApplicationContext.Current.Services.UserService;
      return userService.GetByUsername(HttpContext.Current.User.Identity.Name).Id;
    }
  }
}