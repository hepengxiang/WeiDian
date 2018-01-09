using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiDian.Model;

namespace WeiDian.IDAL
{
    public interface IDALUser
    {
        long Insert( User user );

        int Delete( long userID );

        int Update( User user );

        List<User> GetUser( long userID );
    }
}
