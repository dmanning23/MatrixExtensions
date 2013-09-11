using System;
using Microsoft.Xna.Framework;

namespace MatrixExtensions
{
	/// <summary>
	/// A super simple 2d matrix class.
	/// </summary>
	public static class MatrixExt
	{
		#region Methods

		public static Matrix Orientation(float radians)
		{
			Matrix result = Matrix.CreateRotationZ(radians);
			return result;
		}

		public static void Orientation(float radians, out Matrix result)
		{
			Matrix.CreateRotationZ(radians, out result);
		}

		/// <summary>
		/// vector multipl
		/// </summary>
		/// <param name="mat1">the matrix to multiply</param>
		/// <param name="vect1">the vector to multiply by</param>
		/// <returns>a new matrix that is the result of the matrix * vector</returns>
		public static Vector2 Mutliply(this Matrix mat1, Vector2 vect1)
		{
			return new Vector2(
				((mat1.M11 * vect1.X) + (mat1.M21 * vect1.Y) + mat1.M41),
				((mat1.M12 * vect1.X) + (mat1.M22 * vect1.Y) + mat1.M42));
		}

		public static void XPos(this Matrix mat1, float x)
		{
			mat1.M41 = x;
		}

		public static void YPos(this Matrix mat1, float y)
		{
			mat1.M42 = y;
		}

		#endregion
	}
}