using System;

namespace Assign2
{
	public class Student
	{
		private static int LastId = 0;

		public int Id { get; init; }
		public string GivenName { get; set; }
		public string Surname { get; set; }
		public StudentStatus Status
		{
			get
			{
				DateTime now = DateTime.Now;
				if (StartDate <= now && now <= EndDate)
					return StudentStatus.Active;
				if (EndDate < now)
					if (EndDate >= GraduationDate)
						return StudentStatus.Graduated;
					else
						return StudentStatus.Dropout;
				return StudentStatus.New;
			}
		}
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime GraduationDate { get; set; }

		public Student(string givenName, string surname)
		{
			Id = LastId++;
			GivenName = givenName;
			Surname = surname;
		}

		public override string ToString()
		{
			return $"Id: {Id}; Name: {Surname}, {GivenName}; Status: {Status}";
		}

		public enum StudentStatus
		{
			New, Active, Dropout, Graduated
		}
	}
}
