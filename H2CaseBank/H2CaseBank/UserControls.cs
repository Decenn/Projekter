using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2CaseBank
{
    class UserControls
    {
    }
    interface IControlFeatures
    {
        void UserSorting(List<Bruger> userList);
        void KontiSorting(List<Konto> kontoList);
    }
}
