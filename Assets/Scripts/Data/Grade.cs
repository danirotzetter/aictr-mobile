using System;

namespace aictr.data
{
	[Serializable]
	public class Grade
	{
		public Student Student{get;set;}
		public Course Course{ get; set; }
		public float Score{get;set;}

		public Grade (Student student, Course course, float score)
		{
			Student = student;
			Course = course;
			Score = score;
		}
	}
}

