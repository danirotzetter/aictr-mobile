using System;

namespace aictr.data
{
	[Serializable]
	public class Student
	{
		public int Id{ get; private set; }
		public String FirstName{get;set;}
		public String LastName{ get; set; }

		public Student ()
		{
		}

	}
}

