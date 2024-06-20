using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.BusinessEntity
{
	public class RegistrestionForm
	{
		public int UserId { get; set; }

		public string FName { get; set; }

		public string Email { get; set; } = null!;

		public string Password{ get; set; } = null!;
        public string CounfirmPassword { get; set; } = null!;

        public DateOnly Dob { get; set; } 

		public string Mobile { get; set; } = null!;

		public string Gender { get; set; } = null;

		public int RoleName { get; set; }



	}
}
