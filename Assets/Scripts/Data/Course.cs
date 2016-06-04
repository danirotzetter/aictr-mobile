using System;

namespace aictr.data
{
	[Serializable]
	public class Course
	{
		public int Id{ get; private set; }
		public String Name{ get; set; }

		public Course ()
		{
		}
	}
}

