using DataAccess.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Results
{
	public class SuccessResult : Result
	{
		/*
		 Result result= new SuccessResult("işlem başarılı.");
		 Result result= new SuccessResult();
		 */


		public SuccessResult(string message) : base(true, message)
		{
		}

		public SuccessResult() : base(true, "")
		{

		}

	}
}
