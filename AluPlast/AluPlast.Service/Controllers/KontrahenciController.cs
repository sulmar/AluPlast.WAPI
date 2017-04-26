using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Service.Controllers
{
    public class KontrahenciController : BaseController<Kontrahent, string, IKontrahenciService>
    {


        public KontrahenciController(IKontrahenciService service) : base(service)
        {
        }
    }
}
