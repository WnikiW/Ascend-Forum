using Ascend_Forum.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Areas.Administrator.Controllers
{
    [Area(RoleType.Administrator)]
    [Authorize(Roles = RoleType.Administrator)]
    public abstract class BaseAdminController : Controller
    {
    }
}
