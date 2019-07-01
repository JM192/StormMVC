using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PaymentsDAL
    {
        #region Direct mapping
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Card_num { get; set; }
        public int Security_code { get; set; }
        #endregion Direct mapping
        #region Indirect mapping

        public string Email { get; set; }

        #endregion Indirect mapping

        //public override string ToString()
        //{
        //    return $"PaymentID:{PaymentID} UserID:{UserID} Name:{Name} Address:{Address} Ph_num:{Ph_num} " +
        //           $"Card_num:{Card_num} Security_code:{Security_code} Email:{Email}";
        //}
    }
}
