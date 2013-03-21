using System;
using Microsoft.Xna.Framework;

namespace MatrixLib
{
	/// <summary>
	/// A super simple 2d matrix class.
	/// </summary>
	public struct Matrix2
	{
		#region Members

		/// <summary>
		/// 0 1 2
		/// 3 4 5
		/// 6 7 8
		/// </summary>
		public float[] m_fE = { 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f };

		#endregion

		#region Properties

		/// <summary>
		/// The x componenet of the position
		/// </summary>
		public float XPos
		{
			get { return m_fE[2]; }
			set { m_fE[2] = value; }
		}

		/// <summary>
		/// The y component of the position
		/// </summary>
		public float YPos
		{
			get { return m_fE[5]; }
			set { m_fE[5] = value; }
		}

		/// <summary>
		/// Get or set the position component of this matrix
		/// </summary>
		public Vector2 Pos
		{
			get { return new Vector2(XPos, YPos); }
			set { XPos = value.X; YPos = value.Y; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// contructor
		/// </summary>
		public Matrix2()
		{
		}

		/// <summary>
		/// Another constructor that sets all the values of the matrix
		/// </summary>
		/// <param name="fValue0"></param>
		/// <param name="fValue1"></param>
		/// <param name="fValue2"></param>
		/// <param name="fValue3"></param>
		/// <param name="fValue4"></param>
		/// <param name="fValue5"></param>
		/// <param name="fValue6"></param>
		/// <param name="fValue7"></param>
		/// <param name="fValue8"></param>
		public Matrix2(float fValue0,
			float fValue1,
			float fValue2,
			float fValue3,
			float fValue4,
			float fValue5,
			float fValue6,
			float fValue7,
			float fValue8)
		{
			m_fE = new float[9] { fValue0, fValue1, fValue2, fValue3, fValue4, fValue5, fValue6, fValue7, fValue8 };
		}

		/// <summary>
		/// Matrix multiply
		/// </summary>
		/// <param name="mat1">the first matrix</param>
		/// <param name="mat2">the second matrix</param>
		/// <returns>a new matrix that is the result of the first * second matrix</returns>
		public static Matrix2 operator *(Matrix2 mat1, Matrix2 mat2)
		{
			return new Matrix2(
				(mat1.m_fE[0] * mat2.m_fE[0]) + (mat1.m_fE[1] * mat2.m_fE[3]) + (mat1.m_fE[2] * mat2.m_fE[6]),
				(mat1.m_fE[0] * mat2.m_fE[1]) + (mat1.m_fE[1] * mat2.m_fE[4]) + (mat1.m_fE[2] * mat2.m_fE[7]),
				(mat1.m_fE[0] * mat2.m_fE[2]) + (mat1.m_fE[1] * mat2.m_fE[5]) + (mat1.m_fE[2] * mat2.m_fE[8]),
				(mat1.m_fE[3] * mat2.m_fE[0]) + (mat1.m_fE[4] * mat2.m_fE[3]) + (mat1.m_fE[5] * mat2.m_fE[6]),
				(mat1.m_fE[3] * mat2.m_fE[1]) + (mat1.m_fE[4] * mat2.m_fE[4]) + (mat1.m_fE[5] * mat2.m_fE[7]),
				(mat1.m_fE[3] * mat2.m_fE[2]) + (mat1.m_fE[4] * mat2.m_fE[5]) + (mat1.m_fE[5] * mat2.m_fE[8]),
				(mat1.m_fE[6] * mat2.m_fE[0]) + (mat1.m_fE[7] * mat2.m_fE[3]) + (mat1.m_fE[8] * mat2.m_fE[6]),
				(mat1.m_fE[6] * mat2.m_fE[1]) + (mat1.m_fE[7] * mat2.m_fE[4]) + (mat1.m_fE[8] * mat2.m_fE[7]),
				(mat1.m_fE[6] * mat2.m_fE[2]) + (mat1.m_fE[7] * mat2.m_fE[5]) + (mat1.m_fE[8] * mat2.m_fE[8]));
		}

		/// <summary>
		/// Create an orientation matrix
		/// </summary>
		/// <param name="fAng">the angle of the orientaion matrix</param>
		/// <returns>a new matrxi with the orientation set to the corect angle</returns>
		public static Matrix2 Orientation(double fAng)
		{
			float myCos = (float)Math.Cos(fAng);
			float mySin = (float)Math.Sin(fAng);
			return new Matrix2(
				myCos,
				-mySin,
				0.0f,
				mySin,
				myCos,
				0.0f,
				0.0f,
				0.0f,
				1.0f);
		}

		/// <summary>
		/// vector multipl
		/// </summary>
		/// <param name="mat1">the matrix to multiply</param>
		/// <param name="vect1">the vector to multiply by</param>
		/// <returns>a new matrix that is the result of the matrix * vector</returns>
		public static Vector2 operator *(Matrix2 mat1, Vector2 vect1)
		{
			return new Vector2(
				((mat1.m_fE[0] * vect1.X) + (mat1.m_fE[1] * vect1.Y) + mat1.m_fE[2]),
				((mat1.m_fE[3] * vect1.X) + (mat1.m_fE[4] * vect1.Y) + mat1.m_fE[5]));
		}

		/// <summary>
		/// Set this matrix to be an orientation matrix
		/// </summary>
		/// <param name="fAng">the angle to set this dude to</param>
		public void SetOrientation(float fAng)
		{
			m_fE[0] = (float)Math.Cos((double)fAng);
			m_fE[3] = (float)Math.Sin((double)fAng);

			m_fE[4] = m_fE[0];
			m_fE[1] = -m_fE[3];

			m_fE[2] = 0.0f;
			m_fE[5] = 0.0f;
			m_fE[6] = 0.0f;
			m_fE[7] = 0.0f;
			m_fE[8] = 1.0f;
		}

		#endregion
	}
}