using QRMenuMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuMobile.DataServices
{
    public interface IRestDataServices
    {
        Task<QrMenuTree> GetQRMenu(string QRCode);
    }
}
