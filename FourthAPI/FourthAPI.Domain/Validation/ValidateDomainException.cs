using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthAPI.Domain.Validation {
    public class ValidateDomainException : Exception {

        public ValidateDomainException(string error) : base(error)
        {
            
        }


        public static void When(bool condition, string messageError) {

            if (condition) {
                throw new Exception(messageError);
            }

        }


    }
}
