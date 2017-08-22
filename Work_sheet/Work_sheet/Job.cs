using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_sheet
{
    public class Job
    {
        public DateTime Started { get; private set; }
        public DateTime Finished { get; private set; }
        public string Total { get; private set; }
        public string Assigned_by { get; private set; }
        public string Comment { get; private set; }

        public Job(DateTime started, DateTime finished, string total, string assigned_by, string comment)
        {
            Started = started;
            Finished = finished;
            Total = total;
            Assigned_by = assigned_by;
            Comment = comment;
        }
    }
    public class Table_Id
    {
        public List<int> Id { get; private set; }

        public Table_Id(List<int> id) { Id = id; }
    }
}
