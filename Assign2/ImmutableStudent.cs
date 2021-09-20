using System;

namespace Assign2
{
	public record ImmutableStudent(
		int Id,
		string GivenName,
		string Surname
		)
	{
		public Student.StudentStatus Status
		{
			get
			{
				DateTime now = DateTime.Now;
				if (StartDate <= now && now <= EndDate)
					return Student.StudentStatus.Active;
				if (EndDate < now)
					if (EndDate >= GraduationDate)
						return Student.StudentStatus.Graduated;
					else
						return Student.StudentStatus.Dropout;
				return Student.StudentStatus.New;
			}
		}
		public DateTime StartDate { get; init; }
		public DateTime EndDate { get; init; }
		public DateTime GraduationDate { get; init; }
	}
}
