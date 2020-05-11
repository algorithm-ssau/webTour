using System;
using System.Collections.Generic;
using System.Text;

namespace WebTour.BLL.DTO
{
    public class OperationDetailDTO
    {
        public bool Succeeded { get; set; }

        public List<string> ErrorMessages { get; set; }

        public OperationDetailDTO()
        {
            ErrorMessages = new List<string>();
        }
    }

    public class OperationDetailDTO<T> : OperationDetailDTO
    {
        public T Data { get; set; }
    }
}
