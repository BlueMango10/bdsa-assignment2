using System;
using Xunit;
using static Assign2.Student.StudentStatus;

namespace Assign2.Test
{
	public class ImmutableStudentTests
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
			var st = new ImmutableStudent(0, "Bent", "Kenneth")
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
			var st = new ImmutableStudent(0, "Bent", "Kenneth")
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
	
		#region To_String
		[Fact]
		public void To_String()
		{
			// Arrange
			var now = DateTime.Now;
			var st = new ImmutableStudent(0, "Bent", "Kenneth")
			{
				StartDate = now.AddDays(0),
				EndDate = now.AddDays(4),
				GraduationDate = now.AddDays(5)
			};

			// Act
			var actual = st.ToString();

			// Assert
			var expected = $"{st.GetType().Name} {{ Id = {st.Id}, GivenName = {st.GivenName}, Surname = {st.Surname}, Status = {st.Status}, StartDate = {now.AddDays(0)}, EndDate = {now.AddDays(4)}, GraduationDate = {now.AddDays(5)} }}";
			Assert.Equal(expected, actual);
		}
		#endregion

		#region ==
		[Fact]
		public void Equality_On_Equal()
		{
			// Arrange
			var now = DateTime.Now;
			var st1 = new ImmutableStudent(0, "Bent", "Kenneth")
			{
				StartDate = now.AddDays(0),
				EndDate = now.AddDays(4),
				GraduationDate = now.AddDays(5)
			};
			
			var st2 = new ImmutableStudent(0, "Bent", "Kenneth")
			{
				StartDate = now.AddDays(0),
				EndDate = now.AddDays(4),
				GraduationDate = now.AddDays(5)
			};

			// Act
			var actual = st1 == st2;

			// Assert
			var expected = true;
			Assert.Equal(expected, actual);
		}
		[Fact]

		public void Equality_On_Not_Equal()
		{
			// Arrange
			var now = DateTime.Now;
			var st1 = new ImmutableStudent(0, "Bent", "Kenneth")
			{
				StartDate = now.AddDays(0),
				EndDate = now.AddDays(4),
				GraduationDate = now.AddDays(5)
			};
			
			var st2 = new ImmutableStudent(5, "Børge", "Olsen")
			{
				StartDate = now.AddDays(0),
				EndDate = now.AddDays(4),
				GraduationDate = now.AddDays(5)
			};
			
			// Act
			var actual = st1 == st2;

			// Assert
			var expected = false;
			Assert.Equal(expected, actual);
		}
		#endregion
	}
}
