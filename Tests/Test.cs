using NUnit.Framework;
using System;
using MatrixExtensions;
using Microsoft.Xna.Framework;

namespace MatrixExtensions
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase()
		{
		}

		[Test()]
		public void Orientation()
		{

		}

		[Test()]
		public void VectMultiply()
		{
			//create a scale matrix
			Matrix scale = Matrix.CreateScale(2.0f, 1.0f, 100.0f);

			//multiply a vector
			Vector2 result = scale.Mutliply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(6.0f, result.X);
			Assert.AreEqual(2.0f, result.Y);
		}

		[Test()]
		public void VectMultiply2()
		{
			//create a scale matrix
			Matrix scale = Matrix.CreateScale(4.0f, 3.0f, 100.0f);

			//multiply a vector
			Vector2 result = scale.Mutliply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(12.0f, result.X);
			Assert.AreEqual(6.0f, result.Y);
		}
	}
}

