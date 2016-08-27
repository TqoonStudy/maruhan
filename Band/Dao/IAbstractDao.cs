using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band.Dao
{
    interface IAbstractDao<T>
    {
        int insert(T item);
        T read(int id);
        void update(T item);
        void delete(int id);
        string readStoredFileNameColumn(int id);
        List<string> getColumnListByValue();
    }
}
