using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodJOB.DAO
{
    internal class ChartDAO
    {
        ConnectSql sql = new ConnectSql();

        public ChartDAO() { }

        public List<int> GetLikeCompnay()
        {
            List<int> list = sql.GetLikeCompnay();
            return list;
        }

        public List<string> LoadNameCompnay()
        {
            List<string> list = sql.LoadNameCompnay();
            return list;
        }

        public List<Tuple<string, int>> LoadNumRecrui()
        {
            List<Tuple<string, int>> list = sql.LoadNumRecrui();
            return list;
        }
    }
}
