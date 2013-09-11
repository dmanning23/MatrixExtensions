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
			Matrix rotation = MatrixExt.Orientation(MathHelper.ToRadians(90));

			Vector2 dude = new Vector2(1.0f, 0.0f);
			Vector2 result = rotation.Mutliply(dude);
			Assert.AreEqual(0, (int)(result.X + 0.5f));
			Assert.AreEqual(1, (int)(result.Y + 0.5f));
		}

		[Test()]
		public void Orientation2()
		{
			Matrix rotation = MatrixExt.Orientation(MathHelper.ToRadians(-90));

			Vector2 dude = new Vector2(1.0f, 0.0f);
			Vector2 result = rotation.Mutliply(dude);
			Assert.AreEqual(0, Convert.ToInt32(result.X));
			Assert.AreEqual(-1, Convert.ToInt32(result.Y));
		}

		[Test()]
		public void Orientation3()
		{
			Matrix rotation = Matrix.Identity;
			MatrixExt.Orientation(MathHelper.ToRadians(-90), out rotation);

			Vector2 dude = new Vector2(1.0f, 0.0f);
			Vector2 result = rotation.Mutliply(dude);
			Assert.AreEqual(0, Convert.ToInt32(result.X));
			Assert.AreEqual(-1, Convert.ToInt32(result.Y));
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

		[Test()]
		public void TranslationMultiply()
		{
			//create a scale matrix
			Matrix translation = Matrix.CreateTranslation(2.0f, 1.0f, 100.0f);

			//multiply a vector
			Vector2 result = translation.Mutliply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(5.0f, result.X);
			Assert.AreEqual(3.0f, result.Y);
		}

		[Test()]
		public void TranslateScaleMultiply()
		{
			//create a scale matrix
			Matrix translation = Matrix.CreateTranslation(2.0f, 1.0f, 100.0f);

			//create a scale matrix
			Matrix scale = Matrix.CreateScale(4.0f, 3.0f, 100.0f);

			//multiply a vector
			Vector2 result = (translation * scale).Mutliply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(20.0f, result.X);
			Assert.AreEqual(9.0f, result.Y);
		}
	}
}

