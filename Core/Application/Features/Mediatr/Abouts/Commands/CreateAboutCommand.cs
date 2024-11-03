using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Commands
{
    public class CreateAboutCommand:IRequest
    {
        public string Misyon { get; set; }
        public string Vizyon { get; set; }
        public string KanBagisiOnemi { get; set; }
        public string Ekip { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Email { get; set; }
    }
}
