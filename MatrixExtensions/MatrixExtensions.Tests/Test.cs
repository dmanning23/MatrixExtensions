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
			Vector2 result = rotation.Multiply(dude);
			Assert.AreEqual(0, (int)(result.X + 0.5f));
			Assert.AreEqual(1, (int)(result.Y + 0.5f));
		}

		[Test()]
		public void Orientation2()
		{
			Matrix rotation = MatrixExt.Orientation(MathHelper.ToRadians(-90));

			Vector2 dude = new Vector2(1.0f, 0.0f);
			Vector2 result = rotation.Multiply(dude);
			Assert.AreEqual(0, Convert.ToInt32(result.X));
			Assert.AreEqual(-1, Convert.ToInt32(result.Y));
		}

		[Test()]
		public void Orientation3()
		{
			Matrix rotation = Matrix.Identity;
			MatrixExt.Orientation(MathHelper.ToRadians(-90), out rotation);

			Vector2 dude = new Vector2(1.0f, 0.0f);
			Vector2 result = rotation.Multiply(dude);
			Assert.AreEqual(0, Convert.ToInt32(result.X));
			Assert.AreEqual(-1, Convert.ToInt32(result.Y));
		}

		[Test()]
		public void VectMultiply()
		{
			//create a scale matrix
			Matrix scale = Matrix.CreateScale(2.0f, 1.0f, 100.0f);

			//multiply a vector
			Vector2 result = scale.Multiply(new Vector2(3.0f, 2.0f));

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
			Vector2 result = scale.Multiply(new Vector2(3.0f, 2.0f));

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
			Vector2 result = translation.Multiply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(5.0f, result.X);
			Assert.AreEqual(3.0f, result.Y);
		}

		[Test()]
		public void TranslateScaleMultiply()
		{
			//create a scale matrix
			Matrix translation = Matrix.CreateTranslation(2.0f, 1.0f, 0.0f);

			//create a scale matrix
			Matrix scale = Matrix.CreateScale(4.0f, 3.0f, 0.0f);

			//multiply a vector
			Vector2 result = (translation * scale).Multiply(new Vector2(3.0f, 2.0f));

			//check the vect
			Assert.AreEqual(20.0f, result.X);
			Assert.AreEqual(9.0f, result.Y);
		}

		[Test]
		public void Orientations()
		{
			//create his heading 180
			Vector2 dudeHeading = -Vector2.UnitX;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			//that should be identity
			Matrix rotate1 = MatrixExt.Orientation(MathHelper.ToRadians(-180.0f));
			for (int i = 0; i < Matrix.ToFloatArray(rotate).Length; i++)
			{
				float expected = (float)Math.Round(Matrix.ToFloatArray(rotate1)[i], 3);
				float actual = (float)Math.Round(Matrix.ToFloatArray(rotate)[i], 3);
				Assert.AreEqual(expected, actual, string.Format("incorrect index at {0}", i));
			}
		}

		[Test]
		public void Orientations_1()
		{
			//create his heading -90
			Vector2 dudeHeading = new Vector2(0.0f, 1.0f);

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			//that should be identity
			Matrix rotate1 = MatrixExt.Orientation(MathHelper.ToRadians(-90.0f));
			for (int i = 0; i < Matrix.ToFloatArray(rotate).Length; i++)
			{
				float expected = (float)Math.Round(Matrix.ToFloatArray(rotate1)[i], 3);
				float actual = (float)Math.Round(Matrix.ToFloatArray(rotate)[i], 3);
				Assert.AreEqual(expected, actual, string.Format("incorrect index at {0}", i));
			}
		}

		[Test]
		public void OrientationFromHeadingAndSide()
		{
			//create his heading
			Vector2 dudeHeading = Vector2.UnitX;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			//that should be identity
			Assert.AreEqual(Matrix.Identity, rotate);
		}

		[Test]
		public void OrientationFromHeadingAndSide_1()
		{
			//create his heading
			Vector2 dudeHeading = -Vector2.UnitY;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			//rotate a point
			Vector2 point = rotate.Multiply(new Vector2(100.0f, 100.0f));
			Assert.AreEqual(-100.0f, Math.Round(point.X, 3));
			Assert.AreEqual(100.0f, Math.Round(point.Y, 3));
		}

		[Test]
		public void OrientationFromHeadingAndSide_2()
		{
			//create his heading
			Vector2 dudeHeading = -Vector2.UnitY;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			//rotate a point
			Vector2 point = rotate.Multiply(new Vector2(100.0f, 110.0f));
			Assert.AreEqual(-110.0f, Math.Round(point.X, 3));
			Assert.AreEqual(100.0f, Math.Round(point.Y, 3));
		}

		[Test]
		public void OrientationFromHeadingAndSide_3()
		{
			//create his heading
			Vector2 dudeHeading = Vector2.UnitX;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);


			//create a dude
			Vector2 dudePos = new Vector2(100.0f, 100.0f);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(100.0f, 110.0f);

			myPoint = myPoint - dudePos;
			myPoint = rotate.Multiply(myPoint);

			Assert.AreEqual(0.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(10.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void OrientationFromHeadingAndSide_4()
		{
			//create his heading
			Vector2 dudeHeading = -Vector2.UnitY;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//create an orientation matrix
			Matrix rotate = MatrixExt.Orientation(dudeHeading, dudeSide);

			Vector2 myPoint = rotate.Multiply(new Vector2(0.0f, 10.0f));

			Assert.AreEqual(-10.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(0.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_Identity()
		{
			//create a dude
			Vector2 dudePos = new Vector2(100.0f, 100.0f);

			//create his heading
			Vector2 dudeHeading = Vector2.UnitX;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(100.0f, 110.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(0.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(10.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_Identity1()
		{
			//create a dude
			Vector2 dudePos = new Vector2(100.0f, 100.0f);

			//create his heading
			Vector2 dudeHeading = Vector2.UnitX;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(100.0f, 90.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(0.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(-10.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_1()
		{
			//create a dude
			Vector2 dudePos = new Vector2(100.0f, 100.0f);

			//create his heading
			Vector2 dudeHeading = -Vector2.UnitY;

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(100.0f, 110.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(-10.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(0.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_2()
		{
			//create a dude
			Vector2 dudePos = new Vector2(100.0f, 100.0f);

			//create his heading
			Vector2 dudeHeading = new Vector2(0.0f, -1.0f);

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(110.0f, 110.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(-10.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(10.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_3()
		{
			//create a dude
			Vector2 dudePos = new Vector2(150.0f, 400.0f);

			//create his heading
			Vector2 dudeHeading = new Vector2(0.0f, -1.0f);

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(200.0f, 300.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(100.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(50.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToLocal_Identity2()
		{
			//create a dude
			Vector2 dudePos = new Vector2(150.0f, 400.0f);

			//create his heading
			Vector2 dudeHeading = new Vector2(1.0f, 0.0f);

			//create his side matrix
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(250.0f, 450.0f);

			myPoint = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			Assert.AreEqual(100.0f, Math.Round(myPoint.X, 3));
			Assert.AreEqual(50.0f, Math.Round(myPoint.Y, 3));
		}

		[Test]
		public void ToWorld_Identity()
		{
			//create a dude
			Vector2 dudePos = new Vector2(150.0f, 400.0f);
			Vector2 dudeHeading = new Vector2(1.0f, 0.0f);
			Vector2 dudeSide = new Vector2(-dudeHeading.Y, dudeHeading.X);

			//convert another point to "local space"
			Vector2 myPoint = new Vector2(250.0f, 450.0f);
			Vector2 local = myPoint.ToLocalSpace(dudeHeading, dudeSide, dudePos);

			//covert back to world space
			Vector2 world = dudePos + local.ToWorldSpace(dudeHeading, dudeSide);

			Assert.AreEqual(myPoint.X, Math.Round(world.X, 3));
			Assert.AreEqual(myPoint.Y, Math.Round(world.Y, 3));
		}
	}
}

