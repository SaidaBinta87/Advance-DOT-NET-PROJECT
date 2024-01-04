using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interfaces
{
    public interface IPRepo<CLASS, ID, RET>
    {
        List<CLASS> Get();

        List<CLASS> GetAll(ID id);
        CLASS Get(ID id);

        RET Update(CLASS obj);

        bool Delete(ID id);
    }
}
