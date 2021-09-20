using System;
using Xunit;
using static Assign2.Student.StudentStatus;

namespace Assign2.Test
{
	public class StudentTests
	{
		#region Get_Status
		[Theory]
		[InlineData(-1, New)]
		[InlineData(1, Active)]
		[InlineData(3, Active)]
		[InlineData(6, Graduated)]
		public void Get_Status(int dayOffset, Student.StudentStatus expected)
		{
			// Arrange
			var now = DateTime.Now;
			var st = new Student("Bent", "Kenneth")
			{
				StartDate = now.AddDays(0 - dayOffset),
				EndDate = now.AddDays(5 - dayOffset),
				GraduationDate = now.AddDays(5 - dayOffset)
			};

			// Act
			var actual = st.Status;

			// Assert
			Assert.Equal(expected, actual);
		}
        
		[Theory]
		[InlineData(-1, New)]
		[InlineData(1, Active)]
		[InlineData(3, Active)]
		[InlineData(6, Dropout)]
		public void Get_Status_Dropout(int dayOffset, Student.StudentStatus expected)
		{
			// Arrange
			var now = DateTime.Now;
			var st = new Student("Bent", "Kenneth")
			{
				StartDate = now.AddDays(0 - dayOffset),
				EndDate = now.AddDays(4 - dayOffset),
				GraduationDate = now.AddDays(5 - dayOffset)
			};

			// Act
			var actual = st.Status;

			// Assert
			Assert.Equal(expected, actual);
		}
		#endregion
	}
}
