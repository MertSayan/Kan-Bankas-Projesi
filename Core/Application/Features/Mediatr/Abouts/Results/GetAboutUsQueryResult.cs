using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Abouts.Results
{
    public class GetAboutUsQueryResult
    {
        public int AboutId { get; set; }
        public string Misyon { get; set; }
        public string Vizyon { get; set; }
        public string KanBagisiOnemi { get; set; }
        public string Ekip { get; set; }
        public string Adres { get; set; }
        public string TelefonNo { get; set; }
        public string Email { get; set; }
    }
}
