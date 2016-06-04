using System;
using System.Collections.Generic;

namespace aictr.data
{
	/// <summary>
	/// Contains buffered data
	/// </summary>
	[Serializable]
	public class DataBuffer
	{
		/// <summary>
		/// Gets or sets the grades.
		/// </summary>
		/// <value>The grades.</value>
		List<Grade> Grades{ get; set; }

		public DataBuffer ()
		{
		}
	}
}

