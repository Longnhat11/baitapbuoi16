using baitapbuoi16.Models;

namespace baitapbuoi16.DataAccess.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }
    public class ReturnDataReturnStudent:ReturnData 
    {
        public Student ReturnStudent { get; set; }
    }
}
