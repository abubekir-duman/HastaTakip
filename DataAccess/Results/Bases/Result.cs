using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Results.Bases
{
	/*
	Result result= new Result()
	{
	  IsSuccessful=false,
	  Message="İşlem Başarısız!"

	};

	*/

	public abstract class Result
	{
		

		public bool IsSuccessful { get; private set; }

		public string Message { get; set; }


		public Result(bool isSuccessful, string message)
		{
			IsSuccessful = isSuccessful;
			Message = message;
		}
	}
}
