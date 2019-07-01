using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PaymentBLL
    {
        public PaymentBLL(PaymentsDAL paymentsDAL)
        {
            PaymentID = paymentsDAL.PaymentID;
            UserID = paymentsDAL.UserID;
            Name = paymentsDAL.Name;
            Address = paymentsDAL.Address;
            Ph_num = paymentsDAL.Ph_num;
            Card_num = paymentsDAL.Card_num;
            Security_code = paymentsDAL.Security_code;
            Email = paymentsDAL.Email;
        }         
        public PaymentBLL()
        {

        }

        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ph_num { get; set; }
        public string Card_num { get; set; }
        public int Security_code { get; set; }
        public string Email { get; set; }

    
    }
}
