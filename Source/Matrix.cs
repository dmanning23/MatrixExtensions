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
		/// vector multiply
		/// </summary>
		/// <param name="mat1">the matrix to multiply</param>
		/// <param name="vect1">the vector to multiply by</param>
		/// <returns>a new matrix that is the result of the matrix * vector</returns>
		public static Vector2 Multiply(this Matrix mat1, Vector2 vect1)
		{
			return new Vector2(
				((mat1.M11 * vect1.X) + (mat1.M21 * vect1.Y) + mat1.M41),
				((mat1.M12 * vect1.X) + (mat1.M22 * vect1.Y) + mat1.M42));
		}

		public static void SetPosition(ref Matrix mat1, Vector2 pos)
		{
			mat1.M41 = pos.X;
			mat1.M42 = pos.Y;
		}

		/// <summary>
		/// Transforms a vector from world space to the agent's local space
		/// </summary>
		public static Vector2 ToLocalSpace(this Vector2 point, Vector2 agentHeading, Vector2 agentSide, Vector2 agentPosition)
		{
			//create a rotation matrix
			Matrix rotation = Orientation(agentHeading, agentSide);

			//now transform the vertices
			return rotation.Multiply(point - agentPosition);
		}

		/// <summary>
		/// create a rotation matrix from a 2D vector
		/// </summary>
		/// <param name="fwd"></param>
		/// <param name="side"></param>
		public static Matrix Orientation(Vector2 fwd, Vector2 side)
		{
			Matrix result = Matrix.Identity;

			result.M11 = fwd.X;
			result.M21 = fwd.Y;

			result.M12 = side.X;
			result.M22 = side.Y;

			return result;
		}

		/// <summary>
		/// Transforms a vector from the agent's local space into world space
		/// </summary>
		public static Vector2 ToWorldSpace(this Vector2 vec, Vector2 agentHeading, Vector2 agentSide)
		{
			//create a transformation matrix
			Matrix matTransform = Orientation(agentHeading, agentSide);

			//now transform the vertex
			return matTransform.Multiply(vec);
		}

		#endregion
	}
}