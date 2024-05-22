using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grammerGame.Application.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public int Score { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; } // belki kullanmak istemeyiz diye ezilebilir yapıyoruz
    }
}
