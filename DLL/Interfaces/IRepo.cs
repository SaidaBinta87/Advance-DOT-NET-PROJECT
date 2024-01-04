using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IRepo<CLASS,ID,RET,ID2>
    {
        List<CLASS> Get();
        RET Create(CLASS obj);
        

        List<CLASS> Get(ID id);
        CLASS Read(ID2 id);
       
        RET Update(CLASS obj);

        RET Authenticate(string email, string password);
        bool Delete(ID2 id);
    }
}
