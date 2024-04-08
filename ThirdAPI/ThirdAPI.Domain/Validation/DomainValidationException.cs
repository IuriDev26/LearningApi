using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdAPI.Domain.Validation {
    public class DomainValidationException : Exception {

        public DomainValidationException(string error) : base(error)
        {
            
        }

        public static void When(bool hasError, string error) {

            if (hasError) {
                throw new DomainValidationException(error);
            }
        }
    }
}
