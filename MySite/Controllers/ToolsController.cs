using Microsoft.AspNetCore.Mvc;
using MySite.Models.Tools;
using Tools.qiming.Class;

namespace MySite.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Qiming()
        {
            var model = new QimingModel();
            return View(model);
        }
        [HttpPost]
        
        
        public IActionResult Ceming([FromBody]QimingModel model)
        {
            var info = new BasicInfo();
            info.FirstName = model.FirstName;
            info.Words = model.Words;
            info.BirthDay = model.Birthday;
            info.AllowReduplication = model.AllowReduplication;
            info.Gender = model.Gender ? Gender.Boy : Gender.Girl;
            info.IsLunar = model.TimeType ? TimeType.Nongli : TimeType.Gongli;
            info.WordNum = model.numWord;
            var qiming =new Tools.qiming.qiming(info);
            return Json(qiming.GetResult());
        }
    }
}