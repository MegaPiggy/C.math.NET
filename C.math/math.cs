
using System;

// Declare assembly as CLS compliant.
[assembly: System.CLSCompliant(true)]

namespace C
{
	/// <summary>
	/// Implements several <a href="http://en.cppreference.com/w/c/numeric/math">C Standard</a> mathematical functions that are missing from the .NET framework.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Both double and single precision functions are implemented.
	/// All functions are static and their names follow the <a href="http://en.cppreference.com/w/c/numeric/math">C Standard</a>.
	/// The class is named after the C header file where the functions are declared.
	/// </para>
	/// </remarks>
	/// <author email="robert.baron@videotron.ca">Robert Baron</author>
	public static class math
	{

		/// <summary></summary>
		static math()
		{
		}

		#region Root functions
		/// <returns>the cube root of `<paramref name="n"/>`.</returns>
		public static double cbrt(double n)
		{
			double value = n;
			if (value == 0 || double.IsInfinity(value))
				return value;

			var neg = value < 0;
			if (neg)
				value = -value;

			var ret = Math.Exp(Math.Log(value) / 3);
			ret = ((value / (ret * ret)) + (2 * ret)) / 3;

			return neg ? -ret : ret;
		}

		/// <returns>the <paramref name="base"/> root of `<paramref name="n"/>`.</returns>
		public static double root(double n, double @base)
		{
			if (@base < 1 || n % 2 == 0 && n < 0)
				return double.NaN;
			else
				return Math.Pow(n, (1 / @base));
		}
		#endregion

		#region "The values returned by "ilogb" for 0, NaN, and infinity respectively."

		/// <summary>
		/// Value returned by <see cref="math.ilogb(double)"/> or <see cref="ilogb(float)"/> when its input argument is <c>±0</c>.
		/// </summary>
		public const int FP_ILOGB0 = (-2147483647);

		/// <summary>
		/// Value returned by <see cref="math.ilogb(double)"/> or <see cref="ilogb(float)"/> when its input argument is <see cref="System.Double.NaN"/> or <see cref="System.Single.NaN"/> respectively.
		/// </summary>
		public const int FP_ILOGBNAN = (2147483647);

		/// <summary>
		/// Value returned by <see cref="math.ilogb(double)"/> or <see cref="ilogb(float)"/> when its input argument is <c>±infinity</c>.
		/// </summary>
		public const int INT_MAX = (32767);

		#endregion

		#region "Floating-point number categories."

		/// <summary>
		/// Indicates that a floating-point value is normal, i.e. not infinity, subnormal, NaN (not-a-number) or zero. 
		/// </summary>
		/// <seealso cref="math.fpclassify(double)"/>
		/// <seealso cref="math.fpclassify(float)"/>
		public const FloatingPointCategory FP_NORMAL = FloatingPointCategory.Normal;

		/// <summary>
		/// Indicates that a floating-point value is subnormal. 
		/// </summary>
		/// <seealso cref="math.fpclassify(double)"/>
		/// <seealso cref="math.fpclassify(float)"/>
		public const FloatingPointCategory FP_SUBNORMAL = FloatingPointCategory.Subnormal;

		/// <summary>
		/// Indicates that a floating-point value is positive or negative zero. 
		/// </summary>
		/// <seealso cref="math.fpclassify(double)"/>
		/// <seealso cref="math.fpclassify(float)"/>
		public const FloatingPointCategory FP_ZERO = FloatingPointCategory.Zero;

		/// <summary>
		/// Indicates that the value is not representable by the underlying type (positive or negative infinity)  
		/// </summary>
		/// <seealso cref="math.fpclassify(double)"/>
		/// <seealso cref="math.fpclassify(float)"/>
		public const FloatingPointCategory FP_INFINITE = FloatingPointCategory.Infinite;

		/// <summary>
		/// Indicates that the value is not representable by the underlying type (positive or negative infinity)  
		/// </summary>
		/// <seealso cref="math.fpclassify(double)"/>
		/// <seealso cref="math.fpclassify(float)"/>
		public const FloatingPointCategory FP_NAN = FloatingPointCategory.NaN;

		/// <summary>
		/// floating point categories
		/// </summary>
		public enum FloatingPointCategory
		{
			/// <summary>
			/// Indicates that the value is not representable by the underlying type (positive or negative infinity)  
			/// </summary>
			NaN = 0,
			/// <summary>
			/// Indicates that the value is not representable by the underlying type (positive or negative infinity)  
			/// </summary>
			Infinite = 1,
			/// <summary>
			/// Indicates that a floating-point value is positive or negative zero. 
			/// </summary>
			Zero = 2,
			/// <summary>
			/// Indicates that a floating-point value is subnormal. 
			/// </summary>
			Subnormal = 3,
			/// <summary>
			/// Indicates that a floating-point value is normal, i.e. not infinity, subnormal, NaN (not-a-number) or zero. 
			/// </summary>
			Normal = 4,
		}

		#endregion

		#region "Properties of floating-point types."

		/// <summary>
		/// The exponent bias of a <see cref="Double"/>, i.e. value to subtract from the stored exponent to get the real exponent (<c>1023</c>).
		/// </summary>
		public const int DBL_EXP_BIAS = 1023;

		/// <summary>
		/// The number of bits in the exponent of a <see cref="Double"/> (<c>11</c>).
		/// </summary>
		public const int DBL_EXP_BITS = 11;

		/// <summary>
		/// The maximum (unbiased) exponent of a <see cref="Double"/> (<c>1023</c>).
		/// </summary>
		public const int DBL_EXP_MAX = 1023;

		/// <summary>
		/// The minimum (unbiased) exponent of a <see cref="Double"/> (<c>-1022</c>).
		/// </summary>
		public const int DBL_EXP_MIN = -1022;

		/// <summary>
		/// Bit-mask used for clearing the exponent bits of a <see cref="Double"/> (<c>0x800fffffffffffff</c>).
		/// </summary>
		public const long DBL_EXP_CLR_MASK = DBL_SGN_MASK | DBL_MANT_MASK;

		/// <summary>
		/// Bit-mask used for extracting the exponent bits of a <see cref="Double"/> (<c>0x7ff0000000000000</c>).
		/// </summary>
		public const long DBL_EXP_MASK = 0x7ff0000000000000L;

		/// <summary>
		/// The number of bits in the mantissa of a <see cref="Double"/>, excludes the implicit leading <c>1</c> bit (<c>52</c>).
		/// </summary>
		public const int DBL_MANT_BITS = 52;

		/// <summary>
		/// Bit-mask used for clearing the mantissa bits of a <see cref="Double"/> (<c>0xfff0000000000000</c>).
		/// </summary>
		public const long DBL_MANT_CLR_MASK = DBL_SGN_MASK | DBL_EXP_MASK;

		/// <summary>
		/// Bit-mask used for extracting the mantissa bits of a <see cref="Double"/> (<c>0x000fffffffffffff</c>).
		/// </summary>
		public const long DBL_MANT_MASK = 0x000fffffffffffffL;

		/// <summary>
		/// Maximum positive, normal value of a <see cref="Double"/> (<c>1.7976931348623157E+308</c>).
		/// </summary>
		public const double DBL_MAX = System.Double.MaxValue;

		/// <summary>
		/// Minimum positive, normal value of a <see cref="Double"/> (<c>2.2250738585072014e-308</c>).
		/// </summary>
		public const double DBL_MIN = 2.2250738585072014e-308D;

		/// <summary>
		/// Maximum positive, subnormal value of a <see cref="Double"/> (<c>2.2250738585072009e-308</c>).
		/// </summary>
		public const double DBL_DENORM_MAX = DBL_MIN - DBL_DENORM_MIN;

		/// <summary>
		/// Minimum positive, subnormal value of a <see cref="Double"/> (<c>4.94065645841247E-324</c>).
		/// </summary>
		public const double DBL_DENORM_MIN = System.Double.Epsilon;

		/// <summary>
		/// Bit-mask used for clearing the sign bit of a <see cref="Double"/> (<c>0x7fffffffffffffff</c>).
		/// </summary>
		public const long DBL_SGN_CLR_MASK = 0x7fffffffffffffffL;

		/// <summary>
		/// Bit-mask used for extracting the sign bit of a <see cref="Double"/> (<c>0x8000000000000000</c>).
		/// </summary>
		public const long DBL_SGN_MASK = -1 - 0x7fffffffffffffffL;

		/// <summary>
		/// The exponent bias of a <see cref="Single"/>, i.e. value to subtract from the stored exponent to get the real exponent (<c>127</c>).
		/// </summary>
		public const int FLT_EXP_BIAS = 127;

		/// <summary>
		/// The number of bits in the exponent of a <see cref="Single"/> (<c>8</c>).
		/// </summary>
		public const int FLT_EXP_BITS = 8;

		/// <summary>
		/// The maximum (unbiased) exponent of a <see cref="Single"/> (<c>127</c>).
		/// </summary>
		public const int FLT_EXP_MAX = 127;

		/// <summary>
		/// The minimum (unbiased) exponent of a <see cref="Single"/> (<c>-126</c>).
		/// </summary>
		public const int FLT_EXP_MIN = -126;

		/// <summary>
		/// Bit-mask used for clearing the exponent bits of a <see cref="Single"/> (<c>0x807fffff</c>).
		/// </summary>
		public const int FLT_EXP_CLR_MASK = FLT_SGN_MASK | FLT_MANT_MASK;

		/// <summary>
		/// Bit-mask used for extracting the exponent bits of a <see cref="Single"/> (<c>0x7f800000</c>).
		/// </summary>
		public const int FLT_EXP_MASK = 0x7f800000;

		/// <summary>
		/// The number of bits in the mantissa of a <see cref="Single"/>, excludes the implicit leading <c>1</c> bit (<c>23</c>).
		/// </summary>
		public const int FLT_MANT_BITS = 23;

		/// <summary>
		/// Bit-mask used for clearing the mantissa bits of a <see cref="Single"/> (<c>0xff800000</c>).
		/// </summary>
		public const int FLT_MANT_CLR_MASK = FLT_SGN_MASK | FLT_EXP_MASK;

		/// <summary>
		/// Bit-mask used for extracting the mantissa bits of a <see cref="Single"/> (<c>0x007fffff</c>).
		/// </summary>
		public const int FLT_MANT_MASK = 0x007fffff;

		/// <summary>
		/// Maximum positive, normal value of a <see cref="Single"/> (<c>3.40282347e+38</c>).
		/// </summary>
		public const float FLT_MAX = System.Single.MaxValue;

		/// <summary>
		/// Minimum positive, normal value of a <see cref="Single"/> (<c>1.17549435e-38</c>).
		/// </summary>
		public const float FLT_MIN = 1.17549435e-38F;

		/// <summary>
		/// Maximum positive, subnormal value of a <see cref="Single"/> (<c>1.17549421e-38</c>).
		/// </summary>
		public const float FLT_DENORM_MAX = FLT_MIN - FLT_DENORM_MIN;

		/// <summary>
		/// Minimum positive, subnormal value of a <see cref="Single"/> (<c>1.401298E-45</c>).
		/// </summary>
		public const float FLT_DENORM_MIN = System.Single.Epsilon;

		/// <summary>
		/// Bit-mask used for clearing the sign bit of a <see cref="Single"/> (<c>0x7fffffff</c>).
		/// </summary>
		public const int FLT_SGN_CLR_MASK = 0x7fffffff;

		/// <summary>
		/// Bit-mask used for extracting the sign bit of a <see cref="Single"/> (<c>0x80000000</c>).
		/// </summary>
		public const int FLT_SGN_MASK = -1 - 0x7fffffff;

		#endregion

		#region "Classification."

		#region "fpclassify"

		/// <summary>
		/// Categorizes the given floating point <paramref name="number"/> into the categories: zero, subnormal, normal, infinite or NAN.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>One of <see cref="math.FP_INFINITE"/>, <see cref="math.FP_NAN"/>, <see cref="math.FP_NORMAL"/>, <see cref="math.FP_SUBNORMAL"/> or <see cref="math.FP_ZERO"/>, specifying the category of <paramref name="number"/>.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/fpclassify">fpclassify</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static FloatingPointCategory fpclassify(double number)
		{
			long bits = System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK;
			if (bits >= 0x7ff0000000000000L)
				return (bits & math.DBL_MANT_MASK) == 0 ? math.FP_INFINITE : math.FP_NAN;
			else if (bits < 0x0010000000000000L)
				return bits == 0 ? math.FP_ZERO : math.FP_SUBNORMAL;
			return math.FP_NORMAL;
		}

		/// <summary>
		/// Categorizes the given floating point <paramref name="number"/> into the categories: zero, subnormal, normal, infinite or NAN.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>One of <see cref="math.FP_INFINITE"/>, <see cref="math.FP_NAN"/>, <see cref="math.FP_NORMAL"/>, <see cref="math.FP_SUBNORMAL"/> or <see cref="math.FP_ZERO"/>, specifying the category of <paramref name="number"/>.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/fpclassify">fpclassify</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static FloatingPointCategory fpclassify(float number)
		{
			int bits = SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK;
			if (bits >= 0x7f800000)
				return (bits & math.FLT_MANT_MASK) == 0 ? math.FP_INFINITE : math.FP_NAN;
			else if (bits < 0x00800000)
				return bits == 0 ? math.FP_ZERO : math.FP_SUBNORMAL;
			return math.FP_NORMAL;
		}

		#endregion

		#region "isfinite"

		/// <summary>
		/// Checks if the given <paramref name="number"/> has finite value.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is finite, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// A floating-point number is finite if it zero, normal, or subnormal, but not infinite or NaN.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isfinite">isfinite</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isfinite(double number)
		{
			// Check the exponent part. If it is all 1"s then we have infinity/NaN, i.e., not a finite value.
			return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_EXP_MASK) != math.DBL_EXP_MASK;
		}

		/// <summary>
		/// Checks if the given <paramref name="number"/> has finite value.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is finite, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// A floating-point number is finite if it zero, normal, or subnormal, but not infinite or NaN.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isfinite">isfinite</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isfinite(float number)
		{
			// Check the exponent part. If it is all 1"s then we have infinity/NaN, i.e., not a finite value.
			return (SingleToInt32Bits(number) & math.FLT_EXP_MASK) != math.FLT_EXP_MASK;
		}

		#endregion

		#region "isinf"

		/// <summary>
		/// Checks if the given <paramref name="number"/> is positive or negative infinity.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> has an infinite value, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isinf">isinf</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isinf(double number)
		{
			return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK) == 0x7ff0000000000000L;
		}

		/// <summary>
		/// Checks if the given <paramref name="number"/> is positive or negative infinity.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> has an infinite value, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isinf">isinf</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isinf(float number)
		{
			return (SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK) == 0x7f800000;
		}

		#endregion

		#region "isnan"

		/// <summary>
		/// Checks if the given <paramref name="number"/> is NaN (Not A Number).
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is NaN, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isnan">isnan</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isnan(double number)
		{
			return (System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK) > 0x7ff0000000000000L;
		}

		/// <summary>
		/// Checks if the given <paramref name="number"/> is NaN (Not A Number).
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is NaN, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isnan">isnan</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isnan(float number)
		{
			return (SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK) > 0x7f800000;
		}

		#endregion

		#region "isnormal"

		/// <summary>
		/// Checks if the given <paramref name="number"/> is normal.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is normal, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// A floating-point number is normal if it is neither zero, subnormal, infinite, nor NaN.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isnormal">isnormal</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isnormal(double number)
		{
			long bits = System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_CLR_MASK;
			// Not infinity or NaN and greater than zero or subnormal.
			return (bits < 0x7ff0000000000000L) && (bits >= 0x0010000000000000L);
		}

		/// <summary>
		/// Checks if the given <paramref name="number"/> is normal.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns><c>true</c> if <paramref name="number"/> is normal, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// A floating-point number is normal if it is neither zero, subnormal, infinite, nor NaN.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isnormal">isnormal</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isnormal(float number)
		{
			int bits = SingleToInt32Bits(number) & math.FLT_SGN_CLR_MASK;
			// Not infinity or NaN and greater than zero or subnormal.
			return (bits < 0x7f800000) && (bits >= 0x00800000);
		}

		#endregion

		#region "signbit"

		/// <summary>
		/// Gets the sign bit of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The sign bit of the specified floating-point <paramref name="number"/>.</returns>
		/// <remarks>
		/// <para>
		/// The function detects the sign bit of zeroes, infinities, and NaN. Along with
		/// <see cref="math.copysign(double, double)"/>, <see cref="math.signbit(double)"/> is one
		/// of the only two portable ways to examine the sign of NaN. 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/signbit">signbit</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static int signbit(double number)
		{
			if (System.Double.IsNaN(number))
				return ((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_MASK) != 0) ? 0 : 1;
			else
				return ((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_SGN_MASK) != 0) ? 1 : 0;
		}

		/// <summary>
		/// Gets the sign bit of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The sign bit of the specified floating-point <paramref name="number"/>.</returns>
		/// <remarks>
		/// <para>
		/// The function detects the sign bit of zeroes, infinities, and NaN. Along with
		/// <see cref="math.copysign(float, float)"/>, <see cref="math.signbit(float)"/> is one
		/// of the only two portable ways to examine the sign of NaN. 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/signbit">signbit</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static int signbit(float number)
		{
			if (System.Double.IsNaN(number))
				return ((SingleToInt32Bits(number) & math.FLT_SGN_MASK) != 0) ? 0 : 1;
			else
				return ((SingleToInt32Bits(number) & math.FLT_SGN_MASK) != 0) ? 1 : 0;
		}

		#endregion

		#endregion

		#region "Exponential and logarithmic functions."

		#region "frexp"

		/// <summary>
		/// Decomposes the given floating-point <paramref name="number"/> into a normalized fraction and an integral power of two.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">Reference to an <see cref="int"/> value to store the exponent to.</param>
		/// <returns>A <c>fraction</c> in the range <c>[0.5, 1)</c> so that <c><paramref name="number"/> = fraction * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet" >
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned, and <c>0</c> is returned in <paramref name="exponent"/>.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned, and an undefined value is returned in <paramref name="exponent"/>.</item>
		/// <item>If <paramref name="number"/> is NaN, it is returned, and an undefined value is returned in <paramref name="exponent"/>.</item>
		/// </list>
		/// <para>
		/// </para>
		/// <para>
		/// The function <see cref="math.frexp(double, out int)"/>, together with its dual, <see cref="math.ldexp(double, int)"/>,
		/// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
		/// </para>
		/// <para>
		/// The relation of <see cref="math.frexp(double, out int)"/> to <see cref="math.logb(double)"/> and <see cref="math.scalbn(double, int)"/> is:
		/// </para>
		/// <para>
		/// <c><paramref name="exponent"/> = (<paramref name="number"/> == 0) ? 0 : (int)(1 + <see cref="math.logb(double)">logb</see>(<paramref name="number"/>))</c><br/>
		/// <c>fraction = <see cref="math.scalbn(double, int)">scalbn</see>(<paramref name="number"/>, -<paramref name="exponent"/>)</c>
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/frexp">frexp</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.frexp(12.8D, ref exponent) = 0.8D);
		/// Assert.IsTrue(exponent = 4);
		/// 
		/// Assert.IsTrue(math.frexp(0.25D, ref exponent) == 0.5D);
		/// Assert.IsTrue(exponent == -1);
		/// 
		/// Assert.IsTrue(math.frexp(System.Math.Pow(2D, 1023), ref exponent) == 0.5D);
		/// Assert.IsTrue(exponent == 1024);
		/// 
		/// Assert.IsTrue(math.frexp(-System.Math.Pow(2D, -1074), ref exponent) == -0.5D);
		/// Assert.IsTrue(exponent == -1073);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.frexp(12.8D, exponent) = 0.8D);
		/// Assert.IsTrue(exponent = 4);
		/// 
		/// Assert.IsTrue(math.frexp(0.25D, exponent) = 0.5D);
		/// Assert.IsTrue(exponent = -1);
		/// 
		/// Assert.IsTrue(math.frexp(System.Math.Pow(2D, 1023), exponent) = 0.5D);
		/// Assert.IsTrue(exponent = 1024);
		/// 
		/// Assert.IsTrue(math.frexp(-System.Math.Pow(2D, -1074), exponent) = -0.5D);
		/// Assert.IsTrue(exponent = -1073);
		/// </code> 
		/// </example>
		public static double frexp(double number, out int exponent)
		{
			long bits = System.BitConverter.DoubleToInt64Bits(number);
			int exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
			exponent = 0;

			if (exp == 0x7ff || number == 0D)
				number += number;
			else
			{
				// Not zero and finite.
				exponent = exp - 1022;
				if (exp == 0)
				{
					// Subnormal, scale number so that it is in [1, 2).
					number *= System.BitConverter.Int64BitsToDouble(0x4350000000000000L); // 2^54
					bits = System.BitConverter.DoubleToInt64Bits(number);
					exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
					exponent = exp - 1022 - 54;
				}
				// Set exponent to -1 so that number is in [0.5, 1).
				number = System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | 0x3fe0000000000000L);
			}

			return number;
		}

		/// <summary>
		/// Decomposes the given floating-point <paramref name="number"/> into a normalized fraction and an integral power of two.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">Reference to an <see cref="int"/> value to store the exponent to.</param>
		/// <returns>A <c>fraction</c> in the range <c>[0.5, 1)</c> so that <c><paramref name="number"/> = fraction * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet" >
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned, and <c>0</c> is returned in <paramref name="exponent"/>.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned, and an undefined value is returned in <paramref name="exponent"/>.</item>
		/// <item>If <paramref name="number"/> is NaN, it is returned, and an undefined value is returned in <paramref name="exponent"/>.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.frexp(float, out int)"/>, together with its dual, <see cref="math.ldexp(float, int)"/>,
		/// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
		/// </para>
		/// <para>
		/// The relation of <see cref="math.frexp(float, out int)"/> to <see cref="math.logb(float)"/> and <see cref="math.scalbn(float, int)"/> is:
		/// </para>
		/// <para>
		/// <c><paramref name="exponent"/> = (<paramref name="number"/> == 0) ? 0 : (int)(1 + <see cref="math.logb(float)">logb</see>(<paramref name="number"/>))</c><br/>
		/// <c>fraction = <see cref="math.scalbn(float, int)">scalbn</see>(<paramref name="number"/>, -<paramref name="exponent"/>)</c>
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/frexp">frexp</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.frexp(12.8F, ref exponent) = 0.8F);
		/// Assert.IsTrue(exponent = 4);
		/// 
		/// Assert.IsTrue(math.frexp(0.25F, ref exponent) == 0.5F);
		/// Assert.IsTrue(exponent == -1);
		/// 
		/// Assert.IsTrue(math.frexp(System.Math.Pow(2F, 127F), ref exponent) == 0.5F);
		/// Assert.IsTrue(exponent == 128);
		/// 
		/// Assert.IsTrue(math.frexp(-System.Math.Pow(2F, -149F), ref exponent) == -0.5F);
		/// Assert.IsTrue(exponent == -148);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.frexp(12.8F, exponent) = 0.8F);
		/// Assert.IsTrue(exponent = 4);
		/// 
		/// Assert.IsTrue(math.frexp(0.25F, exponent) = 0.5F);
		/// Assert.IsTrue(exponent = -1);
		/// 
		/// Assert.IsTrue(math.frexp(System.Math.Pow(2F, 127F), exponent) = 0.5F);
		/// Assert.IsTrue(exponent = 128);
		/// 
		/// Assert.IsTrue(math.frexp(-System.Math.Pow(2F, -149F), exponent) = -0.5F);
		/// Assert.IsTrue(exponent = -148);
		/// </code> 
		/// </example>
		public static float frexp(float number, out int exponent)
		{
			int bits = math.SingleToInt32Bits(number);
			int exp = (int)((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
			exponent = 0;

			if (exp == 0xff || number == 0F)
				number += number;
			else
			{
				// Not zero and finite.
				exponent = exp - 126;
				if (exp == 0)
				{
					// Subnormal, scale number so that it is in [1, 2).
					number *= math.Int32BitsToSingle(0x4c000000); // 2^25
					bits = math.SingleToInt32Bits(number);
					exp = (int)((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
					exponent = exp - 126 - 25;
				}
				// Set exponent to -1 so that number is in [0.5, 1).
				number = math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | 0x3f000000);
			}

			return number;
		}

		#endregion

		#region "ilogb"

		/// <summary>
		/// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
		/// The unbiased exponent is such that:
		/// </para>
		/// <para>
		/// <c><paramref name="number"/> = <see cref="math.significand(double)">significand</see>(<paramref name="number"/>) * 2^<see cref="math.ilogb(double)">ilogb</see>(<paramref name="number"/>)</c>.
		/// </para>
		/// <para>
		/// The return unbiased exponent is valid for all normal and subnormal numbers. Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, <see cref="math.FP_ILOGB0"/> is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, <see cref="math.INT_MAX"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="math.FP_ILOGBNAN"/> is returned.</item>
		/// </list>
		/// <para>
		/// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
		/// <c>(<see cref="int"/>)<see cref="math.logb(double)">logb</see>(<paramref name="number"/>)</c>. 
		/// </para>
		/// <para>
		/// The value of the exponent returned by <see cref="math.ilogb(double)"/> is always <c>1</c> less than the exponent retuned by
		/// <see cref="math.frexp(double, out int)"/> because of the different normalization requirements:
		/// for <see cref="math.ilogb(double)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
		/// but for <see cref="math.frexp(double, out int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/ilogb">ilogb</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.ilogb(1D) == 0);
		/// Assert.IsTrue(math.ilogb(System.Math.E) == 1);
		/// Assert.IsTrue(math.ilogb(1024D) == 10);
		/// Assert.IsTrue(math.ilogb(-2000D) == 10);
		/// 
		/// Assert.IsTrue(math.ilogb(2D) == 1);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 56D)) == 56);
		/// Assert.IsTrue(math.ilogb(1.1D * Math.Pow(2D, -1074D)) == -1074);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, -1075D)) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 1024D)) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 1023D)) == 1023);
		/// Assert.IsTrue(math.ilogb(2D * Math.Pow(2D, 102D)) == 103);
		/// 
		/// Assert.IsTrue(math.ilogb(math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
		/// Assert.IsTrue(math.ilogb(math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);
		/// Assert.IsTrue(math.ilogb(math.DBL_MIN) == math.DBL_EXP_MIN);
		/// Assert.IsTrue(math.ilogb(math.DBL_MAX) == math.DBL_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.ilogb(System.Double.PositiveInfinity) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(System.Double.NegativeInfinity) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(0D) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(-0D) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(System.Double.NaN) == math.FP_ILOGBNAN);
		/// Assert.IsTrue(math.ilogb(-System.Double.NaN) == math.FP_ILOGBNAN);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.ilogb(1D) = 0);
		/// Assert.IsTrue(math.ilogb(System.Math.E) = 1);
		/// Assert.IsTrue(math.ilogb(1024D) = 10);
		/// Assert.IsTrue(math.ilogb(-2000D) = 10);
		/// 
		/// Assert.IsTrue(math.ilogb(2D) = 1);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 56D)) = 56);
		/// Assert.IsTrue(math.ilogb(1.1D * Math.Pow(2D, -1074D)) = -1074);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, -1075D)) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 1024D)) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(Math.Pow(2D, 1023D)) = 1023);
		/// Assert.IsTrue(math.ilogb(2D * Math.Pow(2D, 102D)) = 103);
		/// 
		/// Assert.IsTrue(math.ilogb(math.DBL_DENORM_MIN) = math.DBL_EXP_MIN - math.DBL_MANT_BITS);
		/// Assert.IsTrue(math.ilogb(math.DBL_DENORM_MAX) = math.DBL_EXP_MIN - 1);
		/// Assert.IsTrue(math.ilogb(math.DBL_MIN) = math.DBL_EXP_MIN);
		/// Assert.IsTrue(math.ilogb(math.DBL_MAX) = math.DBL_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.ilogb(System.Double.PositiveInfinity) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(System.Double.NegativeInfinity) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(0D) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(-0D) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(System.Double.NaN) = math.FP_ILOGBNAN);
		/// Assert.IsTrue(math.ilogb(-System.Double.NaN) = math.FP_ILOGBNAN);
		/// </code> 
		/// </example>
		public static int ilogb(double number)
		{
			long bits = System.BitConverter.DoubleToInt64Bits(number) & (math.DBL_EXP_MASK | math.DBL_MANT_MASK);
			if (bits == 0L)
				return math.FP_ILOGB0;
			int exp = (int)(bits >> math.DBL_MANT_BITS);
			if (exp == 0x7ff)
				return (bits & math.DBL_MANT_MASK) == 0L ? math.INT_MAX : math.FP_ILOGBNAN;
			if (exp == 0)
				exp -= (_leadingZeroesCount(bits) - (DBL_EXP_BITS + 1));
			return exp - math.DBL_EXP_BIAS;
		}

		/// <summary>
		/// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
		/// The unbiased exponent is such that:
		/// </para>
		/// <para>
		/// <c><paramref name="number"/> = <see cref="math.significand(float)">significand</see>(<paramref name="number"/>) * 2^<see cref="math.ilogb(float)">ilogb</see>(<paramref name="number"/>)</c>.
		/// </para>
		/// <para>
		/// The return unbiased exponent is valid for all normal and subnormal numbers. Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, <see cref="math.FP_ILOGB0"/> is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, <see cref="math.INT_MAX"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="math.FP_ILOGBNAN"/> is returned.</item>
		/// </list>
		/// <para>
		/// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
		/// <c>(<see cref="int"/>)<see cref="math.logb(float)">logb</see>(<paramref name="number"/>)</c>. 
		/// </para>
		/// <para>
		/// The value of the exponent returned by <see cref="math.ilogb(float)"/> is always <c>1</c> less than the exponent retuned by
		/// <see cref="math.frexp(float, out int)"/> because of the different normalization requirements:
		/// for <see cref="math.ilogb(float)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
		/// but for <see cref="math.frexp(float, out int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/ilogb">ilogb</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.ilogb(1F) == 0);
		/// Assert.IsTrue(math.ilogb((float)System.Math.E) == 1);
		/// Assert.IsTrue(math.ilogb(1024F) == 10);
		/// Assert.IsTrue(math.ilogb(-2000F) == 10);
		/// 
		/// Assert.IsTrue(math.ilogb(2F) == 1);
		/// Assert.IsTrue(math.ilogb((float)Math.Pow(2F, 56F)) == 56);
		/// Assert.IsTrue(math.ilogb(1.1F * (float)Math.Pow(2F, -149F)) == -149);
		/// Assert.IsTrue(math.ilogb((float)Math.Pow(2F, -150F)) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb((float)Math.Pow(2F, 128F)) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb((float)Math.Pow(2D, 127F)) == 127);
		/// Assert.IsTrue(math.ilogb(2F * (float)Math.Pow(2F, 102F)) == 103);
		/// 
		/// Assert.IsTrue(math.ilogb(math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
		/// Assert.IsTrue(math.ilogb(math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);
		/// Assert.IsTrue(math.ilogb(math.FLT_MIN) == math.FLT_EXP_MIN);
		/// Assert.IsTrue(math.ilogb(math.FLT_MAX) == math.FLT_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.ilogb(System.Single.PositiveInfinity) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(System.Single.NegativeInfinity) == math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(0F) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(-0F) == math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(System.Single.NaN) == math.FP_ILOGBNAN);
		/// Assert.IsTrue(math.ilogb(-System.Single.NaN) == math.FP_ILOGBNAN);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.ilogb(1F) = 0);
		/// Assert.IsTrue(math.ilogb(CSng(System.Math.E)) = 1);
		/// Assert.IsTrue(math.ilogb(1024F) = 10);
		/// Assert.IsTrue(math.ilogb(-2000F) = 10);
		/// 
		/// Assert.IsTrue(math.ilogb(2F) = 1);
		/// Assert.IsTrue(math.ilogb(CSng(Math.Pow(2F, 56F))) = 56);
		/// Assert.IsTrue(math.ilogb(1.1F * CSng(Math.Pow(2F, -149F))) = -149);
		/// Assert.IsTrue(math.ilogb(CSng(Math.Pow(2F, -150F))) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(CSng(Math.Pow(2F, 128F))) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(CSng(Math.Pow(2D, 127F))) = 127);
		/// Assert.IsTrue(math.ilogb(2F * CSng(Math.Pow(2F, 102F))) = 103);
		/// 
		/// Assert.IsTrue(math.ilogb(math.FLT_DENORM_MIN) = math.FLT_EXP_MIN - math.FLT_MANT_BITS);
		/// Assert.IsTrue(math.ilogb(math.FLT_DENORM_MAX) = math.FLT_EXP_MIN - 1);
		/// Assert.IsTrue(math.ilogb(math.FLT_MIN) = math.FLT_EXP_MIN);
		/// Assert.IsTrue(math.ilogb(math.FLT_MAX) = math.FLT_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.ilogb(System.Single.PositiveInfinity) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(System.Single.NegativeInfinity) = math.INT_MAX);
		/// Assert.IsTrue(math.ilogb(0F) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(-0F) = math.FP_ILOGB0);
		/// Assert.IsTrue(math.ilogb(System.Single.NaN) = math.FP_ILOGBNAN);
		/// Assert.IsTrue(math.ilogb(-System.Single.NaN) = math.FP_ILOGBNAN);
		/// </code> 
		/// </example>
		public static int ilogb(float number)
		{
			int bits = math.SingleToInt32Bits(number) & (math.FLT_EXP_MASK | math.FLT_MANT_MASK);
			if (bits == 0L)
				return math.FP_ILOGB0;
			int exp = (bits >> math.FLT_MANT_BITS);
			if (exp == 0xff)
				return (bits & math.FLT_MANT_MASK) == 0L ? math.INT_MAX : math.FP_ILOGBNAN;
			if (exp == 0)
				exp -= (_leadingZeroesCount(bits) - (FLT_EXP_BITS + 1));
			return exp - math.FLT_EXP_BIAS;
		}

		#endregion

		#region "ldexp"

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.ldexp(double, int)"/> ("load exponent"), together with its dual, <see cref="math.frexp(double, out int)"/>,
		/// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
		/// </para>
		/// <para>
		/// The function <see cref="math.ldexp(double, int)"/> is equivalent to <see cref="math.scalbn(double, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/ldexp">ldexp</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.ldexp(0.8D, 4) == 12.8D);
		/// Assert.IsTrue(math.ldexp(-0.854375D, 5) == -27.34D);
		/// Assert.IsTrue(math.ldexp(1D, 0) == 1D);
		/// 
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 0) == math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 1) == math.DBL_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.ldexp(1D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.ldexp(1D, System.Int32.MinValue) == 0D);
		/// Assert.IsTrue(math.ldexp(-1D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.ldexp(-1D, System.Int32.MinValue) == -0D);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.ldexp(0.8D, 4) = 12.8D);
		/// Assert.IsTrue(math.ldexp(-0.854375D, 5) = -27.34D);
		/// Assert.IsTrue(math.ldexp(1D, 0) = 1D);
		/// 
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 0) = math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN / 2D, 1) = math.DBL_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) = 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.ldexp(1D, System.Int32.MaxValue) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.ldexp(1D, System.Int32.MinValue) = 0D);
		/// Assert.IsTrue(math.ldexp(-1D, System.Int32.MaxValue) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.ldexp(-1D, System.Int32.MinValue) = -0D);
		/// </code> 
		/// </example>
		public static double ldexp(double number, int exponent)
		{
			return scalbn(number, exponent);
		}

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.ldexp(float, int)"/> ("load exponent"), together with its dual, <see cref="math.frexp(float, out int)"/>,
		/// can be used to manipulate the representation of a floating-point number without direct bit manipulations.
		/// </para>
		/// <para>
		/// The function <see cref="math.ldexp(float, int)"/> is equivalent to <see cref="math.scalbn(float, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/ldexp">ldexp</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.ldexp(0.8F, 4) == 12.8F);
		/// Assert.IsTrue(math.ldexp(-0.854375F, 5) == -27.34F);
		/// Assert.IsTrue(math.ldexp(1F, 0) == 1F);
		/// 
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 0) == math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 1) == math.FLT_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.ldexp(1F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.ldexp(1F, System.Int32.MinValue) == 0F);
		/// Assert.IsTrue(math.ldexp(-1F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.ldexp(-1F, System.Int32.MinValue) == -0F);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.ldexp(0.8F, 4) = 12.8F);
		/// Assert.IsTrue(math.ldexp(-0.854375F, 5) = -27.34F);
		/// Assert.IsTrue(math.ldexp(1F, 0) = 1F);
		/// 
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 0) = math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN / 2F, 1) = math.FLT_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) = 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.ldexp(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.ldexp(1F, System.Int32.MaxValue) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.ldexp(1F, System.Int32.MinValue) = 0F);
		/// Assert.IsTrue(math.ldexp(-1F, System.Int32.MaxValue) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.ldexp(-1F, System.Int32.MinValue) = -0F);
		/// </code> 
		/// </example>
		public static float ldexp(float number, int exponent)
		{
			return scalbn(number, exponent);
		}

		#endregion

		#region "logb"

		/// <summary>
		/// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
		/// The unbiased exponent is such that
		/// </para>
		/// <para>
		/// <c><paramref name="number"/> = <see cref="math.significand(double)">significand</see>(<paramref name="number"/>) * 2^<see cref="math.logb(double)">logb</see>(<paramref name="number"/>)</c>.
		/// </para>
		/// <para>
		/// The return unbiased exponent is valid for all normal and subnormal numbers. Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, <see cref="System.Double.NegativeInfinity"/> is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, <see cref="System.Double.PositiveInfinity"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
		/// <c><see cref="math.ilogb(double)">ilogb</see>(<paramref name="number"/>)</c>. 
		/// </para>
		/// <para>
		/// The value of the exponent returned by <see cref="math.logb(double)"/> is always <c>1</c> less than the exponent retuned by
		/// <see cref="math.frexp(double, out int)"/> because of the different normalization requirements:
		/// for <see cref="math.logb(double)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
		/// but for <see cref="math.frexp(double, out int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>. 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/logb">logb</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.logb(1D) == 0D);
		/// Assert.IsTrue(math.logb(System.Math.E) == 1D);
		/// Assert.IsTrue(math.logb(1024D) == 10D);
		/// Assert.IsTrue(math.logb(-2000D) == 10D);
		/// 
		/// Assert.IsTrue(math.logb(2D) == 1D);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 56D)) == 56D);
		/// Assert.IsTrue(math.logb(1.1D * Math.Pow(2D, -1074D)) == -1074D);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, -1075D)) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 1024D)) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 1023D)) == 1023D);
		/// Assert.IsTrue(math.logb(2D * Math.Pow(2D, 102D)) == 103D);
		/// 
		/// Assert.IsTrue(math.logb(math.DBL_DENORM_MIN) == math.DBL_EXP_MIN - math.DBL_MANT_BITS);
		/// Assert.IsTrue(math.logb(math.DBL_DENORM_MAX) == math.DBL_EXP_MIN - 1);
		/// Assert.IsTrue(math.logb(math.DBL_MIN) == math.DBL_EXP_MIN);
		/// Assert.IsTrue(math.logb(math.DBL_MAX) == math.DBL_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.logb(System.Double.PositiveInfinity) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(System.Double.NegativeInfinity) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(0D) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.logb(-0D) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(System.Double.IsNaN(math.logb(System.Double.NaN)));
		/// Assert.IsTrue(System.Double.IsNaN(math.logb(-System.Double.NaN)));
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.logb(1D) = 0D);
		/// Assert.IsTrue(math.logb(System.Math.E) = 1D);
		/// Assert.IsTrue(math.logb(1024D) = 10D);
		/// Assert.IsTrue(math.logb(-2000D) = 10D);
		/// 
		/// Assert.IsTrue(math.logb(2D) = 1D);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 56D)) = 56D);
		/// Assert.IsTrue(math.logb(1.1D * Math.Pow(2D, -1074D)) = -1074D);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, -1075D)) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 1024D)) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(Math.Pow(2D, 1023D)) = 1023D);
		/// Assert.IsTrue(math.logb(2D * Math.Pow(2D, 102D)) = 103D);
		/// 
		/// Assert.IsTrue(math.logb(math.DBL_DENORM_MIN) = math.DBL_EXP_MIN - math.DBL_MANT_BITS);
		/// Assert.IsTrue(math.logb(math.DBL_DENORM_MAX) = math.DBL_EXP_MIN - 1);
		/// Assert.IsTrue(math.logb(math.DBL_MIN) = math.DBL_EXP_MIN);
		/// Assert.IsTrue(math.logb(math.DBL_MAX) = math.DBL_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.logb(System.Double.PositiveInfinity) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(System.Double.NegativeInfinity) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.logb(0D) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.logb(-0D) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(System.Double.IsNaN(math.logb(System.Double.NaN)));
		/// Assert.IsTrue(System.Double.IsNaN(math.logb(-System.Double.NaN)));
		/// </code> 
		/// </example>
		public static double logb(double number)
		{
			int exp = math.ilogb(number);
			switch (exp)
			{
				case math.FP_ILOGB0:
					return System.Double.NegativeInfinity;
				case math.FP_ILOGBNAN:
					return System.Double.NaN;
				case math.INT_MAX:
					return System.Double.PositiveInfinity;
			}
			return exp;
		}

		/// <summary>
		/// Gets the unbiased exponent of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The unbiased exponent of the specified floating-point <paramref name="number"/>, or a special value if <paramref name="number"/> is not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The unbiased exponent is the integral part of the logarithm base 2 of <paramref name="number"/>.
		/// The unbiased exponent is such that
		/// </para>
		/// <para>
		/// <c><paramref name="number"/> = <see cref="math.significand(float)">significand</see>(<paramref name="number"/>) * 2^<see cref="math.logb(float)">logb</see>(<paramref name="number"/>)</c>.
		/// </para>
		/// <para>
		/// The return unbiased exponent is valid for all normal and subnormal numbers. Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, <see cref="System.Single.NegativeInfinity"/> is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, <see cref="System.Single.PositiveInfinity"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// If <paramref name="number"/> is not zero, infinite, or NaN, the value returned is exactly equivalent to
		/// <c><see cref="math.ilogb(float)">ilogb</see>(<paramref name="number"/>)</c>. 
		/// </para>
		/// <para>
		/// The value of the exponent returned by <see cref="math.logb(float)"/> is always <c>1</c> less than the exponent retuned by
		/// <see cref="math.frexp(float, out int)"/> because of the different normalization requirements:
		/// for <see cref="math.logb(float)"/>, the normalized significand is in the interval <c>[1, 2)</c>,
		/// but for <see cref="math.frexp(float, out int)"/>, the normalized significand is in the interval <c>[0.5, 1)</c>. 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/logb">logb</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.logb(1F) == 0F);
		/// Assert.IsTrue(math.logb((float)System.Math.E) == 1F);
		/// Assert.IsTrue(math.logb(1024F) == 10F);
		/// Assert.IsTrue(math.logb(-2000F) == 10F);
		/// 
		/// Assert.IsTrue(math.logb(2F) == 1F);
		/// Assert.IsTrue(math.logb((float)Math.Pow(2F, 56F)) == 56F);
		/// Assert.IsTrue(math.logb(1.1F * (float)Math.Pow(2F, -149F)) == -149F);
		/// Assert.IsTrue(math.logb((float)Math.Pow(2F, -150F)) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.logb((float)Math.Pow(2F, 128F)) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb((float)Math.Pow(2D, 127F)) == 127F);
		/// Assert.IsTrue(math.logb(2F * (float)Math.Pow(2F, 102F)) == 103F);
		/// 
		/// Assert.IsTrue(math.logb(math.FLT_DENORM_MIN) == math.FLT_EXP_MIN - math.FLT_MANT_BITS);
		/// Assert.IsTrue(math.logb(math.FLT_DENORM_MAX) == math.FLT_EXP_MIN - 1);
		/// Assert.IsTrue(math.logb(math.FLT_MIN) == math.FLT_EXP_MIN);
		/// Assert.IsTrue(math.logb(math.FLT_MAX) == math.FLT_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.logb(System.Single.PositiveInfinity) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb(System.Single.NegativeInfinity) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb(0F) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.logb(-0F) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(System.Single.IsNaN(math.logb(System.Single.NaN)));
		/// Assert.IsTrue(System.Single.IsNaN(math.logb(-System.Single.NaN)));
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.logb(1F) = 0F);
		/// Assert.IsTrue(math.logb(CSng(System.Math.E)) = 1F);
		/// Assert.IsTrue(math.logb(1024F) = 10F);
		/// Assert.IsTrue(math.logb(-2000F) = 10F);
		/// 
		/// Assert.IsTrue(math.logb(2F) = 1F);
		/// Assert.IsTrue(math.logb(CSng(Math.Pow(2F, 56F))) = 56F);
		/// Assert.IsTrue(math.logb(1.1F * CSng(Math.Pow(2F, -149F))) = -149F);
		/// Assert.IsTrue(math.logb(CSng(Math.Pow(2F, -150F))) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.logb(CSng(Math.Pow(2F, 128F))) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb(CSng(Math.Pow(2D, 127F))) = 127F);
		/// Assert.IsTrue(math.logb(2F * CSng(Math.Pow(2F, 102F))) = 103F);
		/// 
		/// Assert.IsTrue(math.logb(math.FLT_DENORM_MIN) = math.FLT_EXP_MIN - math.FLT_MANT_BITS);
		/// Assert.IsTrue(math.logb(math.FLT_DENORM_MAX) = math.FLT_EXP_MIN - 1);
		/// Assert.IsTrue(math.logb(math.FLT_MIN) = math.FLT_EXP_MIN);
		/// Assert.IsTrue(math.logb(math.FLT_MAX) = math.FLT_EXP_MAX);
		/// 
		/// Assert.IsTrue(math.logb(System.Single.PositiveInfinity) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb(System.Single.NegativeInfinity) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.logb(0F) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.logb(-0F) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(System.Single.IsNaN(math.logb(System.Single.NaN)));
		/// Assert.IsTrue(System.Single.IsNaN(math.logb(-System.Single.NaN)));
		/// </code> 
		/// </example>
		public static float logb(float number)
		{
			int exp = math.ilogb(number);
			switch (exp)
			{
				case math.FP_ILOGB0:
					return System.Single.NegativeInfinity;
				case math.FP_ILOGBNAN:
					return System.Single.NaN;
				case math.INT_MAX:
					return System.Single.PositiveInfinity;
			}
			return exp;
		}

		#endregion

		#region "scalbn"

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.scalbn(double, int)"/> is equivalent to <see cref="math.ldexp(double, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/scalbn">scalbn</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.scalbn(0.8D, 4) == 12.8D);
		/// Assert.IsTrue(math.scalbn(-0.854375D, 5) == -27.34D);
		/// Assert.IsTrue(math.scalbn(1D, 0) == 1D);
		/// 
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 0) == math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 1) == math.DBL_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbn(1D, System.Int32.MaxValue) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.scalbn(1D, System.Int32.MinValue) == 0D);
		/// Assert.IsTrue(math.scalbn(-1D, System.Int32.MaxValue) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.scalbn(-1D, System.Int32.MinValue) == -0D);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.scalbn(0.8D, 4) = 12.8D);
		/// Assert.IsTrue(math.scalbn(-0.854375D, 5) = -27.34D);
		/// Assert.IsTrue(math.scalbn(1D, 0) = 1D);
		/// 
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 0) = math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN / 2D, 1) = math.DBL_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) = 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbn(1D, System.Int32.MaxValue) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.scalbn(1D, System.Int32.MinValue) = 0D);
		/// Assert.IsTrue(math.scalbn(-1D, System.Int32.MaxValue) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.scalbn(-1D, System.Int32.MinValue) = -0D);
		/// </code> 
		/// </example>
		public static double scalbn(double number, int exponent)
		{
			return math.scalbln(number, exponent);
		}

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.scalbn(float, int)"/> is equivalent to <see cref="math.ldexp(float, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/scalbn">scalbn</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.scalbn(0.8F, 4) == 12.8F);
		/// Assert.IsTrue(math.scalbn(-0.854375F, 5) == -27.34F);
		/// Assert.IsTrue(math.scalbn(1F, 0) == 1F);
		/// 
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 0) == math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 1) == math.FLT_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbn(1F, System.Int32.MaxValue) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.scalbn(1F, System.Int32.MinValue) == 0F);
		/// Assert.IsTrue(math.scalbn(-1F, System.Int32.MaxValue) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.scalbn(-1F, System.Int32.MinValue) == -0F);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.scalbn(0.8F, 4) = 12.8F);
		/// Assert.IsTrue(math.scalbn(-0.854375F, 5) = -27.34F);
		/// Assert.IsTrue(math.scalbn(1F, 0) = 1F);
		/// 
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 0) = math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN / 2F, 1) = math.FLT_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) = 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbn(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbn(1F, System.Int32.MaxValue) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.scalbn(1F, System.Int32.MinValue) = 0F);
		/// Assert.IsTrue(math.scalbn(-1F, System.Int32.MaxValue) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.scalbn(-1F, System.Int32.MinValue) = -0F);
		/// </code> 
		/// </example>
		public static float scalbn(float number, int exponent)
		{
			return math.scalbln(number, exponent);
		}

		#endregion

		#region "scalbln"

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Double.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.scalbln(double, long)"/> is equivalent to <see cref="math.ldexp(double, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/scalbn">scalbln</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.scalbln(0.8D, 4L) == 12.8D);
		/// Assert.IsTrue(math.scalbln(-0.854375D, 5L) == -27.34D);
		/// Assert.IsTrue(math.scalbln(1D, 0L) == 1D);
		/// 
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 0L) == math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 1L) == math.DBL_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) == 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) == math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbln(1D, System.Int64.MaxValue) == System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.scalbln(1D, System.Int64.MinValue) == 0D);
		/// Assert.IsTrue(math.scalbln(-1D, System.Int64.MaxValue) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.scalbln(-1D, System.Int64.MinValue) == -0D);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.scalbln(0.8D, 4L) = 12.8D);
		/// Assert.IsTrue(math.scalbln(-0.854375D, 5L) = -27.34D);
		/// Assert.IsTrue(math.scalbln(1D, 0L) = 1D);
		/// 
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 0L) = math.DBL_MIN / 2D);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN / 2D, 1L) = math.DBL_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS) = 2D * math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.5D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.DBL_MIN * 1.25D, -math.DBL_MANT_BITS - 1) = math.DBL_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbln(1D, System.Int64.MaxValue) = System.Double.PositiveInfinity);
		/// Assert.IsTrue(math.scalbln(1D, System.Int64.MinValue) = 0D);
		/// Assert.IsTrue(math.scalbln(-1D, System.Int64.MaxValue) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.scalbln(-1D, System.Int64.MinValue) = -0D);
		/// </code> 
		/// </example>
		public static double scalbln(double number, long exponent)
		{
			long bits = System.BitConverter.DoubleToInt64Bits(number);
			int exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
			// Check for infinity or NaN.
			if (exp == 0x7ff)
				return number;
			// Check for 0 or subnormal.
			if (exp == 0)
			{
				// Check for 0.
				if ((bits & math.DBL_MANT_MASK) == 0)
					return number;
				// Subnormal, scale number so that it is in [1, 2).
				number *= System.BitConverter.Int64BitsToDouble(0x4350000000000000L); // 2^54
				bits = System.BitConverter.DoubleToInt64Bits(number);
				exp = (int)((bits & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS) - 54;
			}
			// Check for underflow.
			if (exponent < -50000)
				return math.copysign(0D, number);
			// Check for overflow.
			if (exponent > 50000 || (long)exp + exponent > 0x7feL)
				return math.copysign(System.Double.PositiveInfinity, number);
			exp += (int)exponent;
			// Check for normal.
			if (exp > 0)
				return System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | ((long)exp << math.DBL_MANT_BITS));
			// Check for underflow.
			if (exp <= -54)
				return math.copysign(0D, number);
			// Subnormal.
			exp += 54;
			number = System.BitConverter.Int64BitsToDouble((bits & math.DBL_EXP_CLR_MASK) | ((long)exp << math.DBL_MANT_BITS));
			return number * System.BitConverter.Int64BitsToDouble(0x3c90000000000000L); // 2^-54
		}

		/// <summary>
		/// Scales the specified floating-point <paramref name="number"/> by 2^<paramref name="exponent"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <param name="exponent">The exponent of the power of two.</param>
		/// <returns>The value <c><paramref name="number"/> * 2^<paramref name="exponent"/></c>.</returns>
		/// <remarks>
		/// <para>
		/// Special values are treated as follows.
		/// </para>
		/// <list type="bullet">
		/// <item>If <paramref name="number"/> is <c>±0</c>, it is returned.</item>
		/// <item>If <paramref name="number"/> is infinite, it is returned.</item>
		/// <item>If <paramref name="exponent"/> is <c>0</c>, <paramref name="number"/> is returned.</item>
		/// <item>If <paramref name="number"/> is NaN, <see cref="System.Single.NaN"/> is returned.</item>
		/// </list>
		/// <para>
		/// The function <see cref="math.scalbln(float, long)"/> is equivalent to <see cref="math.ldexp(float, int)"/>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/scalbn">scalbln</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.scalbln(0.8F, 4L) == 12.8F);
		/// Assert.IsTrue(math.scalbln(-0.854375F, 5L) == -27.34F);
		/// Assert.IsTrue(math.scalbln(1F, 0L) == 1F);
		/// 
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 0L) == math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 1L) == math.FLT_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) == 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) == math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbln(1F, System.Int64.MaxValue) == System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.scalbln(1F, System.Int64.MinValue) == 0F);
		/// Assert.IsTrue(math.scalbln(-1F, System.Int64.MaxValue) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.scalbln(-1F, System.Int64.MinValue) == -0F);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.scalbln(0.8F, 4L) = 12.8F);
		/// Assert.IsTrue(math.scalbln(-0.854375F, 5L) = -27.34F);
		/// Assert.IsTrue(math.scalbln(1F, 0L) = 1F);
		/// 
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 0L) = math.FLT_MIN / 2F);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN / 2F, 1L) = math.FLT_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS) = 2F * math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.5F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.scalbln(math.FLT_MIN * 1.25F, -math.FLT_MANT_BITS - 1) = math.FLT_DENORM_MIN);
		/// 
		/// Assert.IsTrue(math.scalbln(1F, System.Int64.MaxValue) = System.Single.PositiveInfinity);
		/// Assert.IsTrue(math.scalbln(1F, System.Int64.MinValue) = 0F);
		/// Assert.IsTrue(math.scalbln(-1F, System.Int64.MaxValue) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.scalbln(-1F, System.Int64.MinValue) = -0F);
		/// </code> 
		/// </example>
		public static float scalbln(float number, long exponent)
		{
			int bits = math.SingleToInt32Bits(number);
			int exp = (bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS;
			// Check for infinity or NaN.
			if (exp == 0xff)
				return number;
			// Check for 0 or subnormal.
			if (exp == 0)
			{
				// Check for 0.
				if ((bits & math.FLT_MANT_MASK) == 0)
					return number;
				// Subnormal, scale number so that it is in [1, 2).
				number *= math.Int32BitsToSingle(0x4c000000); // 2^25
				bits = math.SingleToInt32Bits(number);
				exp = ((bits & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS) - 25;
			}
			// Check for underflow.
			if (exponent < -50000)
				return math.copysign(0F, number);
			// Check for overflow.
			if (exponent > 50000 || exp + exponent > 0xfe)
				return math.copysign(System.Single.PositiveInfinity, number);
			exp += (int)exponent;
			// Check for normal.
			if (exp > 0)
				return math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | (exp << math.FLT_MANT_BITS));
			// Check for underflow.
			if (exp <= -25)
				return math.copysign(0F, number);
			// Subnormal.
			exp += 25;
			number = math.Int32BitsToSingle((bits & math.FLT_EXP_CLR_MASK) | (exp << math.FLT_MANT_BITS));
			return number * math.Int32BitsToSingle(0x33000000); // 2^-25
		}

		#endregion

		#region "log1p"
		/// <returns>the natural logarithm of one plus <paramref name="x"/>.</returns>
		public static double log1p(double x) => Math.Abs(x) > 1e-4 ? Math.Log(1.0 + x) : (-0.5 * x + 1.0) * x;
		#endregion

		#endregion

		#region "Floating-point manipulation functions."

		#region "copysign"

		/// <summary>
		/// Copies the sign of <paramref name="number2"/> to <paramref name="number1"/>.
		/// </summary>
		/// <param name="number1">A floating-point number.</param>
		/// <param name="number2">A floating-point number.</param>
		/// <returns>The floating-point number whose absolute value is that of <paramref name="number1"/> with the sign of <paramref name="number2"/>.</returns>
		/// <remarks>
		/// <para>
		/// <see cref="math.copysign(double, double)"/> is the only portable way to manipulate the sign of a <see cref="System.Double.NaN"/> value (to examine
		/// the sign of a <see cref="System.Double.NaN"/>, <see cref="math.signbit(double)"/> may also be used). 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/copysign">copysign</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.copysign(0D, -0D) == -0D);
		/// Assert.IsTrue(math.copysign(0D, -4D) == -0D);
		/// Assert.IsTrue(math.copysign(2D, -0D) == -2D);
		/// Assert.IsTrue(math.copysign(-2D, 0D) == 2D);
		/// Assert.IsTrue(math.copysign(System.Double.PositiveInfinity, -2D) == System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.copysign(2D, System.Double.NegativeInfinity) == -2D);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.copysign(0D, -0D) = -0D);
		/// Assert.IsTrue(math.copysign(0D, -4D) = -0D);
		/// Assert.IsTrue(math.copysign(2D, -0D) = -2D);
		/// Assert.IsTrue(math.copysign(-2D, 0D) = 2D);
		/// Assert.IsTrue(math.copysign(System.Double.PositiveInfinity, -2D) = System.Double.NegativeInfinity);
		/// Assert.IsTrue(math.copysign(2D, System.Double.NegativeInfinity) = -2D);
		/// </code> 
		/// </example>
		public static double copysign(double number1, double number2)
		{
			// If number1 is NaN, we have to store in it the opposite of the sign bit.
			long sign = (math.signbit(number2) == 1 ? math.DBL_SGN_MASK : 0L) ^ (System.Double.IsNaN(number1) ? math.DBL_SGN_MASK : 0L);
			return System.BitConverter.Int64BitsToDouble((System.BitConverter.DoubleToInt64Bits(number1) & math.DBL_SGN_CLR_MASK) | sign);
		}

		/// <summary>
		/// Copies the sign of <paramref name="number2"/> to <paramref name="number1"/>.
		/// </summary>
		/// <param name="number1">A floating-point number.</param>
		/// <param name="number2">A floating-point number.</param>
		/// <returns>The floating-point number whose absolute value is that of <paramref name="number1"/> with the sign of <paramref name="number2"/>.</returns>
		/// <remarks>
		/// <para>
		/// <see cref="math.copysign(float, float)"/> is the only portable way to manipulate the sign of a <see cref="System.Single.NaN"/> value (to examine
		/// the sign of a <see cref="System.Single.NaN"/>, <see cref="math.signbit(float)"/> may also be used). 
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/copysign">copysign</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.copysign(0F, -0F) == -0F);
		/// Assert.IsTrue(math.copysign(0F, -4F) == -0F);
		/// Assert.IsTrue(math.copysign(2F, -0F) == -2F);
		/// Assert.IsTrue(math.copysign(-2F, 0F) == 2F);
		/// Assert.IsTrue(math.copysign(System.Single.PositiveInfinity, -2F) == System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.copysign(2F, System.Single.NegativeInfinity) == -2F);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.copysign(0F, -0F) = -0F);
		/// Assert.IsTrue(math.copysign(0F, -4F) = -0F);
		/// Assert.IsTrue(math.copysign(2F, -0F) = -2F);
		/// Assert.IsTrue(math.copysign(-2F, 0F) = 2F);
		/// Assert.IsTrue(math.copysign(System.Single.PositiveInfinity, -2F) = System.Single.NegativeInfinity);
		/// Assert.IsTrue(math.copysign(2F, System.Single.NegativeInfinity) = -2F);
		/// </code> 
		/// </example>
		public static float copysign(float number1, float number2)
		{
			// If number1 is NaN, we have to store in it the opposite of the sign bit.
			int sign = (math.signbit(number2) == 1 ? math.FLT_SGN_MASK : 0) ^ (System.Double.IsNaN(number1) ? math.FLT_SGN_MASK : 0);
			return math.Int32BitsToSingle((math.SingleToInt32Bits(number1) & math.FLT_SGN_CLR_MASK) | sign);
		}

		#endregion

		#region "nextafter"

		/// <summary>
		/// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
		/// </summary>
		/// <param name="fromNumber">A floating-point number.</param>
		/// <param name="towardNumber">A floating-point number.</param>
		/// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
		/// <remarks>
		/// <para>
		/// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
		/// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nextafter(double, double)">nextafter</see>(-0.0, +0.0)</c>
		/// returns <c>+0.0</c> and <c><see cref="math.nextafter(double, double)">nextafter</see>(+0.0, -0.0)</c> returns <c>–0.0</c>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/nextafter">nextafter</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.nextafter(0D, 0D) == 0D);
		/// Assert.IsTrue(math.nextafter(-0D, 0D) == 0D;
		/// Assert.IsTrue(math.nextafter(0D, -0D) == -0D);
		/// 
		/// Assert.IsTrue(math.nextafter(math.DBL_MIN, 0D) == math.DBL_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, 0D) == 0D);
		/// Assert.IsTrue(math.nextafter(math.DBL_MIN, -0D) == math.DBL_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, -0D) == 0D);
		/// 
		/// Assert.IsTrue(math.nextafter(0D, System.Double.PositiveInfinity) == math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.nextafter(-0D, System.Double.NegativeInfinity) == -math.DBL_DENORM_MIN);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.nextafter(0D, 0D) = 0D);
		/// Assert.IsTrue(math.nextafter(-0D, 0D) = 0D);
		/// Assert.IsTrue(math.nextafter(0D, -0D) = -0D);
		/// 
		/// Assert.IsTrue(math.nextafter(math.DBL_MIN, 0D) = math.DBL_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, 0D) = 0D);
		/// Assert.IsTrue(math.nextafter(math.DBL_MIN, -0D) = math.DBL_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.DBL_DENORM_MIN, -0D) = 0D);
		/// 
		/// Assert.IsTrue(math.nextafter(0D, System.Double.PositiveInfinity) = math.DBL_DENORM_MIN);
		/// Assert.IsTrue(math.nextafter(-0D, System.Double.NegativeInfinity) = -math.DBL_DENORM_MIN);
		/// </code> 
		/// </example>
		public static double nextafter(double fromNumber, double towardNumber)
		{
			// If either fromNumber or towardNumber is NaN, return NaN.
			if (System.Double.IsNaN(towardNumber) || System.Double.IsNaN(fromNumber))
			{
				return System.Double.NaN;
			}
			// If no direction.
			if (fromNumber == towardNumber)
			{
				return towardNumber;
			}
			// If fromNumber is zero, return smallest subnormal.
			if (fromNumber == 0)
			{
				return (towardNumber > 0) ? System.Double.Epsilon : -System.Double.Epsilon;
			}
			// All other cases are handled by incrementing or decrementing the bits value.
			// Transitions to infinity, to subnormal, and to zero are all taken care of this way.
			long bits = System.BitConverter.DoubleToInt64Bits(fromNumber);
			// A xor here avoids nesting conditionals. We have to increment if fromValue lies between 0 and toValue.
			if ((fromNumber > 0) ^ (fromNumber > towardNumber))
			{
				bits += 1;
			}
			else
			{
				bits -= 1;
			}
			return System.BitConverter.Int64BitsToDouble(bits);
		}

		/// <summary>
		/// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
		/// </summary>
		/// <param name="fromNumber">A floating-point number.</param>
		/// <param name="towardNumber">A floating-point number.</param>
		/// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
		/// <remarks>
		/// <para>
		/// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
		/// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nextafter(float, float)">nextafter</see>(-0.0, +0.0)</c>
		/// returns <c>+0.0</c> and <c><see cref="math.nextafter(float, float)">nextafter</see>(+0.0, -0.0)</c> returns <c>–0.0</c>.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/nextafter">nextafter</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.nextafter(0F, 0F) == 0F);
		/// Assert.IsTrue(math.nextafter(-0F, 0F) == 0F;
		/// Assert.IsTrue(math.nextafter(0F, -0F) == -0F);
		/// 
		/// Assert.IsTrue(math.nextafter(math.FLT_MIN, 0D) == math.FLT_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, 0F) == 0F);
		/// Assert.IsTrue(math.nextafter(math.FLT_MIN, -0F) == math.FLT_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, -0F) == 0F);
		/// 
		/// Assert.IsTrue(math.nextafter(0F, System.Single.PositiveInfinity) == math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.nextafter(-0F, System.Single.NegativeInfinity) == -math.FLT_DENORM_MIN);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.nextafter(0F, 0F) = 0F);
		/// Assert.IsTrue(math.nextafter(-0F, 0F) = 0F);
		/// Assert.IsTrue(math.nextafter(0F, -0F) = -0F);
		/// 
		/// Assert.IsTrue(math.nextafter(math.FLT_MIN, 0F) = math.FLT_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, 0F) = 0F);
		/// Assert.IsTrue(math.nextafter(math.FLT_MIN, -0F) = math.FLT_DENORM_MAX);
		/// Assert.IsTrue(math.nextafter(math.FLT_DENORM_MIN, -0F) = 0F);
		/// 
		/// Assert.IsTrue(math.nextafter(0F, System.Single.PositiveInfinity) = math.FLT_DENORM_MIN);
		/// Assert.IsTrue(math.nextafter(-0F, System.Single.NegativeInfinity) = -math.FLT_DENORM_MIN);
		/// </code> 
		/// </example>
		public static float nextafter(float fromNumber, float towardNumber)
		{
			// If either fromNumber or towardNumber is NaN, return NaN.
			if (System.Single.IsNaN(towardNumber) || System.Single.IsNaN(fromNumber))
			{
				return System.Single.NaN;
			}
			// If no direction or if fromNumber is infinity or is not a number, return fromNumber.
			if (fromNumber == towardNumber)
			{
				return towardNumber;
			}
			// If fromNumber is zero, return smallest subnormal.
			if (fromNumber == 0)
			{
				return (towardNumber > 0) ? System.Single.Epsilon : -System.Single.Epsilon;
			}
			// All other cases are handled by incrementing or decrementing the bits value.
			// Transitions to infinity, to subnormal, and to zero are all taken care of this way.
			int bits = SingleToInt32Bits(fromNumber);
			// A xor here avoids nesting conditionals. We have to increment if fromValue lies between 0 and toValue.
			if ((fromNumber > 0) ^ (fromNumber > towardNumber))
			{
				bits += 1;
			}
			else
			{
				bits -= 1;
			}
			return Int32BitsToSingle(bits);
		}

		#endregion

		#region "nexttoward"

		/// <summary>
		/// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
		/// </summary>
		/// <param name="fromNumber">A floating-point number.</param>
		/// <param name="towardNumber">A floating-point number.</param>
		/// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
		/// <remarks>
		/// <para>
		/// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
		/// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nexttoward(double, double)">nexttoward</see>(-0.0, +0.0)</c>
		/// returns <c>+0.0</c> and <c><see cref="math.nexttoward(double, double)">nexttoward</see>(+0.0, -0.0)</c> returns <c>–0.0</c>.
		/// </para>
		/// <para>
		/// The <see cref="math.nexttoward(double, double)"/> function is equivalent to the <see cref="math.nextafter(double, double)"/> function.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/nextafter">nexttoward</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static double nexttoward(double fromNumber, double towardNumber)
		{
			return math.nextafter(fromNumber, towardNumber);
		}

		/// <summary>
		/// Gets the floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.
		/// </summary>
		/// <param name="fromNumber">A floating-point number.</param>
		/// <param name="towardNumber">A floating-point number.</param>
		/// <returns>The floating-point number that is next after <paramref name="fromNumber"/> in the direction of <paramref name="towardNumber"/>.</returns>
		/// <remarks>
		/// <para>
		/// IEC 60559 recommends that <paramref name="fromNumber"/> be returned whenever <c><paramref name="fromNumber"/> == <paramref name="towardNumber"/></c>.
		/// These functions return <paramref name="towardNumber"/> instead, which makes the behavior around zero consistent: <c><see cref="math.nexttoward(float, float)">nexttoward</see>(-0.0, +0.0)</c>
		/// returns <c>+0.0</c> and <c><see cref="math.nexttoward(float, float)">nexttoward</see>(+0.0, -0.0)</c> returns <c>–0.0</c>.
		/// </para>
		/// <para>
		/// The <see cref="math.nexttoward(float, float)"/> function is equivalent to the <see cref="math.nextafter(float, float)"/> function.
		/// </para>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/nextafter">nexttoward</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static float nexttoward(float fromNumber, float towardNumber)
		{
			return math.nextafter(fromNumber, towardNumber);
		}

		#endregion

		#region "exponent"

		/// <summary>
		/// Gets the exponent bits of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The exponent bits of the specified floating-point <paramref name="number"/>; i.e. the biased exponent.</returns>
		/// <remarks>
		/// <list type="table">
		///     <listheader>
		///        <term><paramref name="number"/></term> 
		///        <description>Biased Exponent</description> 
		///        <description>Unbiased Exponent</description> 
		///     </listheader>
		///     <item>
		///         <term><c>±<see cref="System.Double.NaN"/></c></term>
		///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c><see cref="System.Double.PositiveInfinity"/></c></term>
		///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c><see cref="System.Double.NegativeInfinity"/></c></term>
		///         <description><c>2047</c> (<c><see cref="math.DBL_EXP_MAX"/> + 1 + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.DBL_MAX"/></c></term>
		///         <description><c>2046</c> (<c><see cref="math.DBL_EXP_MAX"/> + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
		///         <description><c>1023</c> (<c><see cref="math.DBL_EXP_MAX"/></c>)</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.DBL_MIN"/></c></term>
		///         <description><c>1</c> (<c><see cref="math.DBL_EXP_MIN"/> + <see cref="math.DBL_EXP_BIAS"/></c>)</description>
		///         <description><c>-1022</c> (<c><see cref="math.DBL_EXP_MIN"/></c>)</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.DBL_DENORM_MAX"/></c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.DBL_DENORM_MIN"/></c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		///     <item>
		///         <term><c>±0</c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		/// </list>
		/// </remarks>
		public static int exponent(double number)
		{
			return System.Convert.ToInt32((System.BitConverter.DoubleToInt64Bits(number) & math.DBL_EXP_MASK) >> math.DBL_MANT_BITS);
		}

		/// <summary>
		/// Gets the exponent bits of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The exponent bits of the specified floating-point <paramref name="number"/>; i.e. the biased exponent.</returns>
		/// <remarks>
		/// <list type="table">
		///     <listheader>
		///        <term><paramref name="number"/></term> 
		///        <description>Biased Exponent</description> 
		///        <description>Unbiased Exponent</description> 
		///     </listheader>
		///     <item>
		///         <term><c>±<see cref="System.Single.NaN"/></c></term>
		///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c><see cref="System.Single.PositiveInfinity"/></c></term>
		///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c><see cref="System.Single.NegativeInfinity"/></c></term>
		///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
		///         <description>N/A</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.FLT_MAX"/></c></term>
		///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
		///         <description><c>128</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1</c>)</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.FLT_MIN"/></c></term>
		///         <description><c>255</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1 + <see cref="math.FLT_EXP_BIAS"/></c>)</description>
		///         <description><c>-127</c> (<c><see cref="math.FLT_EXP_MAX"/> + 1</c>)</description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.FLT_DENORM_MAX"/></c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		///     <item>
		///         <term><c>±<see cref="math.FLT_DENORM_MIN"/></c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		///     <item>
		///         <term><c>±0</c></term>
		///         <description><c>0</c></description>
		///         <description><c>0</c></description>
		///     </item>
		/// </list>
		/// </remarks>
		public static int exponent(float number)
		{
			return System.Convert.ToInt32((math.SingleToInt32Bits(number) & math.FLT_EXP_MASK) >> math.FLT_MANT_BITS);
		}

		#endregion

		#region "mantissa"

		/// <summary>
		/// Gets the mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.</returns>
		/// <remarks></remarks>
		public static long mantissa(double number)
		{
			return System.BitConverter.DoubleToInt64Bits(number) & math.DBL_MANT_MASK;
		}

		/// <summary>
		/// Gets the mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The mantissa bits of the specified floating-point <paramref name="number"/> without the implicit leading <c>1</c> bit.</returns>
		/// <remarks></remarks>
		public static int mantissa(float number)
		{
			return math.SingleToInt32Bits(number) & math.FLT_MANT_MASK;
		}

		#endregion

		#region "significand"

		/// <summary>
		/// Gets the significand of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The significand of the specified floating-point <paramref name="number"/>, or <paramref name="number"/> if it not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The significand is a number in the interval <c>[1, 2)</c> so that 
		/// <c><paramref name="number"/> = <see cref="math.significand(double)">significand</see>(<paramref name="number"/>) * 2^<see cref="math.logb(double)">logb</see>(<paramref name="number"/>)</c>.
		/// If <paramref name="number"/> is subnormal, it is normalized so that the significand falls in the interval <c>[1, 2)</c>.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.significand(0D) == 0D);
		/// Assert.IsTrue(math.significand(-0D) == -0D);
		/// Assert.IsTrue(math.significand(1D) == 1D);
		/// Assert.IsTrue(math.significand(4D) == 1D);
		/// Assert.IsTrue(math.significand(6D) == 1.5D);
		/// Assert.IsTrue(math.significand(7D) == 1.75D);
		/// Assert.IsTrue(math.significand(8D) == 1D);
		/// Assert.IsTrue(math.significand(math.DBL_DENORM_MIN) == 1D);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.significand(0D) = 0D);
		/// Assert.IsTrue(math.significand(-0D) = -0D);
		/// Assert.IsTrue(math.significand(1D) = 1D);
		/// Assert.IsTrue(math.significand(4D) = 1D);
		/// Assert.IsTrue(math.significand(6D) = 1.5D);
		/// Assert.IsTrue(math.significand(7D) = 1.75D);
		/// Assert.IsTrue(math.significand(8D) = 1D);
		/// Assert.IsTrue(math.significand(math.DBL_DENORM_MIN) = 1D);
		/// </code> 
		/// </example>
		public static double significand(double number)
		{
			// If not-a-numbner or infinity, simply return number.
			if (System.Double.IsNaN(number) || System.Double.IsInfinity(number))
				return number;
			// Get the mantissa bits.
			long mantissa = math.mantissa(number);
			// If the unbiased exponent is 0, we have either 0 or a subnormal number.
			if (math.exponent(number) == 0)
			{
				// If number is zero, return zero.
				if (mantissa == 0L)
					return number;
				// Otherwise, shift the mantissa to the left until its first 1-bit makes
				// the mantissa larger than or equal to the mantissa mask, and reset the
				// the leading 1 bit. This yields a "normalized" number.
				while (mantissa < math.DBL_MANT_MASK)
				{
					mantissa <<= 1;
				}
				mantissa &= math.DBL_MANT_MASK;
			}
			// Build new double with exponent 0 and the normalized mantissa.
			return System.BitConverter.Int64BitsToDouble((System.Convert.ToInt64(math.DBL_EXP_BIAS) << math.DBL_MANT_BITS) | mantissa | (math.signbit(number) == 1 ? math.DBL_SGN_MASK : 0L));
		}

		/// <summary>
		/// Gets the significand of the specified floating-point <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A floating-point number.</param>
		/// <returns>The significand of the specified floating-point <paramref name="number"/>, or <paramref name="number"/> if it not normal or subnormal.</returns>
		/// <remarks>
		/// <para>
		/// The significand is a number in the interval <c>[1, 2)</c> so that 
		/// <c><paramref name="number"/> = <see cref="math.significand(float)"/>(<paramref name="number"/>) * 2^<see cref="math.logb(float)"/>(<paramref name="number"/>)</c>.
		/// If <paramref name="number"/> is subnormal, it is normalized so that the significand falls in the interval <c>[1, 2)</c>.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code language="C#">
		/// Assert.IsTrue(math.significand(0F) == 0F);
		/// Assert.IsTrue(math.significand(-0F) == -0F);
		/// Assert.IsTrue(math.significand(1F) == 1F);
		/// Assert.IsTrue(math.significand(4F) == 1F);
		/// Assert.IsTrue(math.significand(6F) == 1.5F);
		/// Assert.IsTrue(math.significand(7F) == 1.75F);
		/// Assert.IsTrue(math.significand(8F) == 1F);
		/// Assert.IsTrue(math.significand(math.FLT_DENORM_MIN) == 1F);
		/// </code> 
		/// <code language="VB.NET">
		/// Assert.IsTrue(math.significand(0F) = 0F);
		/// Assert.IsTrue(math.significand(-0F) = -0F);
		/// Assert.IsTrue(math.significand(1F) = 1F);
		/// Assert.IsTrue(math.significand(4F) = 1F);
		/// Assert.IsTrue(math.significand(6F) = 1.5F);
		/// Assert.IsTrue(math.significand(7F) = 1.75F);
		/// Assert.IsTrue(math.significand(8F) = 1F);
		/// Assert.IsTrue(math.significand(math.FLT_DENORM_MIN) = 1F);
		/// </code> 
		/// </example>
		public static float significand(float number)
		{
			// If not-a-numbner or infinity, simply return number.
			if (System.Single.IsNaN(number) || System.Single.IsInfinity(number))
				return number;
			// Get the mantissa bits.
			int mantissa = math.mantissa(number);
			// If the unbiased exponent is 0, we have either 0 or a subnormal number.
			if (math.exponent(number) == 0)
			{
				// If number is zero, return zero.
				if (mantissa == 0F)
					return number;
				// Otherwise, shift the mantissa to the left until its first 1-bit makes
				// the mantissa larger than or equal to the mantissa mask, and reset the
				// the leading 1 bit. This yields a "normalized" number.
				while (mantissa < math.FLT_MANT_MASK)
				{
					mantissa <<= 1;
				}
				mantissa &= math.FLT_MANT_MASK;
			}
			// Build new float with exponent 0 and the normalized mantissa.
			return math.Int32BitsToSingle((System.Convert.ToInt32(math.FLT_EXP_BIAS) << math.FLT_MANT_BITS) | mantissa | (math.signbit(number) == 1 ? math.FLT_SGN_MASK : 0));
		}

		#endregion

		#endregion

		#region "Comparison functions."

		#region "isunordered"

		/// <summary>
		/// Gets a value that indicates whether two floating-point numbers are unordered.
		/// </summary>
		/// <param name="number1">A floating-point number.</param>
		/// <param name="number2">A floating-point number.</param>
		/// <returns><c>true</c> if either <paramref name="number1"/> or <paramref name="number1"/> is <see cref="System.Double.NaN"/>, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isunordered">isunordered</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isunordered(double number1, double number2)
		{
			return System.Double.IsNaN(number1) || System.Double.IsNaN(number2);
		}

		/// <summary>
		/// Gets a value that indicates whether two floating-point numbers are unordered.
		/// </summary>
		/// <param name="number1">A floating-point number.</param>
		/// <param name="number2">A floating-point number.</param>
		/// <returns><c>true</c> if either <paramref name="number1"/> or <paramref name="number1"/> is <see cref="System.Single.NaN"/>, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// See <a href="http://en.cppreference.com/w/c/numeric/math/isunordered">isunordered</a> in the C standard documentation.
		/// </para>
		/// </remarks>
		public static bool isunordered(float number1, float number2)
		{
			return System.Single.IsNaN(number1) || System.Single.IsNaN(number2);
		}

		#endregion

		#endregion

		#region "Miscellaneous functions."

		/// <summary>
		/// Converts the specified single-precision floating point number to a 32-bit signed integer.
		/// </summary>
		/// <param name="value">The number to convert.</param>
		/// <returns>A 32-bit signed integer whose value is equivalent to <paramref name="value"/>.</returns>
		public static unsafe int SingleToInt32Bits(float value)
		{
			return *((int*)&value);
		}

		/// <summary>
		/// Converts the specified 32-bit signed integer to a single-precision floating point number.
		/// </summary>
		/// <param name="value">The number to convert.</param>
		/// <returns>A double-precision floating point number whose value is equivalent to <paramref name="value"/>.</returns>
		public static unsafe float Int32BitsToSingle(int value)
		{
			return *((float*)&value);
		}

		private static int _leadingZeroesCount(int x)
		{
			int y;
			int n = 32;
			y = x >> 16; if (y != 0) { n -= 16; x = y; }
			y = x >> 8; if (y != 0) { n -= 8; x = y; }
			y = x >> 4; if (y != 0) { n -= 4; x = y; }
			y = x >> 2; if (y != 0) { n -= 2; x = y; }
			y = x >> 1; if (y != 0) return n - 2;
			return n - x;
		}

		private static int _leadingZeroesCount(long x)
		{
			long y;
			int n = 64;
			y = x >> 32; if (y != 0) { n -= 32; x = y; }
			y = x >> 16; if (y != 0) { n -= 16; x = y; }
			y = x >> 8; if (y != 0) { n -= 8; x = y; }
			y = x >> 4; if (y != 0) { n -= 4; x = y; }
			y = x >> 2; if (y != 0) { n -= 2; x = y; }
			y = x >> 1; if (y != 0) return n - 2;
			return n - (int)x;
		}


		/// <summary>
		/// Repeat
		/// </summary>
		public static float rep(float t, float length) => System.Convert.ToSingle(t - (Math.Floor(t / length) * length));
		/// <summary>
		/// Repeat
		/// </summary>
		public static double rep(double t, double length) => t - (Math.Floor(t / length) * length);


		/// <returns><see langword="true"/> if and only if integer <paramref name="m"/> is below integer <paramref name="n"/> when they are compared as unsigned integers (<see cref="uint"/>).</returns>
		public static bool ult(int m, int n) => (uint)m < (uint)n;

		/// <returns><see langword="true"/> if and only if integer <paramref name="m"/> is below integer <paramref name="n"/> when they are compared as unsigned integers (<see cref="ulong"/>).</returns>
		public static bool ult(long m, long n) => (ulong)m < (ulong)n;

		/// <summary>
		/// The function returns what would be the square root of the sum of the squares of <paramref name="x"/> and <paramref name="y"/> (as per the Pythagorean theorem), but without incurring in undue overflow or underflow of intermediate values.
		/// </summary>
		/// <param name="x">one leg of the right-angled triangle</param>
		/// <param name="y">one leg of the right-angled triangle</param>
		/// <returns>the hypotenuse of a right-angled triangle whose legs are <paramref name="x"/> and <paramref name="y"/>.</returns>
		public static float hypot(float x, float y) => System.Convert.ToSingle(Math.Sqrt(x * x + y * y));

		/// <summary>
		/// The function returns what would be the square root of the sum of the squares of <paramref name="x"/> and <paramref name="y"/> (as per the Pythagorean theorem), but without incurring in undue overflow or underflow of intermediate values.
		/// </summary>
		/// <param name="x">one leg of the right-angled triangle</param>
		/// <param name="y">one leg of the right-angled triangle</param>
		/// <returns>the hypotenuse of a right-angled triangle whose legs are <paramref name="x"/> and <paramref name="y"/>.</returns>
		public static double hypot(double x, double y) => Math.Sqrt(x * x + y * y);
		#endregion

		#region "radians and degrees"

		/// <summary>
		/// Used for converting from degrees to radians.
		/// </summary>
		/// <seealso cref="math.deg(double)"/>
		/// <seealso cref="math.rad(double)"/>
		public const double RADIANS_PER_DEGREES = Math.PI / 180;

		#region "degrees"
		/// <summary>
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="x">radians to convert to degrees</param>
		/// <returns>the angle <paramref name="x"/> (given in radians) in degrees.</returns>
		public static float deg(float x) => System.Convert.ToSingle(x / RADIANS_PER_DEGREES);

		/// <summary>
		/// Converts radians to degrees.
		/// </summary>
		/// <param name="x">radians to convert to degrees</param>
		/// <returns>the angle <paramref name="x"/> (given in radians) in degrees.</returns>
		public static double deg(double x) => x / RADIANS_PER_DEGREES;
		#endregion

		#region "radians"
		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="x">degrees to convert to radians</param>
		/// <returns>the angle <paramref name="x"/> (given in degrees) in radians.</returns>
		public static float rad(float x) => System.Convert.ToSingle(x * RADIANS_PER_DEGREES);

		/// <summary>
		/// Converts degrees to radians.
		/// </summary>
		/// <param name="x">degrees to convert to radians</param>
		/// <returns>the angle <paramref name="x"/> (given in degrees) in radians.</returns>
		public static double rad(double x) => x * RADIANS_PER_DEGREES;
		#endregion

		#endregion

		#region "fuzzy functions"

		#region "fuzzy epsilon"
		/// <summary>
		/// Represents an appropriate <see cref="double"/> for comparing a number to zero. This field is constant.
		/// </summary>
		public const double FUZZY_EPSILON = 1e-30;
		/// <summary>
		/// Represents an appropriate <see cref="float"/> for comparing a number to zero. This field is constant.
		/// </summary>
		public const float FUZZY_EPSILONF = 1e-6f;
		#endregion

		#region "eps"
		/// <summary>
		/// Computes an appropriate epsilon for comparing two numbers <paramref name="a"/> and <paramref name="b"/>.
		/// <para>
		/// For <paramref name="a"/> and <paramref name="b"/> to be nearly equal, they must have nearly the same magnitude. 
		/// This means that we can ignore <paramref name="b"/> since it either has the same magnitude or the comparison will fail anyway.
		/// </para>
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b">ignored</param>
		/// <param name="e">tolerance</param>
		public static float eps(float a, float b, float e = FUZZY_EPSILONF)
		{
			float aa = Math.Abs(a) + 1;
			if (float.IsInfinity(aa))
				return e;
			else
				return e * aa;
		}

		/// <summary>
		/// Computes an appropriate epsilon for comparing two numbers <paramref name="a"/> and <paramref name="b"/>.
		/// <para>
		/// For <paramref name="a"/> and <paramref name="b"/> to be nearly equal, they must have nearly the same magnitude. 
		/// This means that we can ignore <paramref name="b"/> since it either has the same magnitude or the comparison will fail anyway.
		/// </para>
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b">ignored</param>
		/// <param name="e">tolerance</param>
		public static double eps(double a, double b, double e = FUZZY_EPSILON)
		{
			double aa = Math.Abs(a) + 1;
			if (double.IsInfinity(aa))
				return e;
			else
				return e * aa;
		}
		#endregion

		#region "fuzzy equal"
		/// <summary>
		/// Check if <paramref name="a"/> is approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyEq(float a, float b, float e = FUZZY_EPSILONF) => a == b || Math.Abs(a - b) <= eps(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyEq(double a, double b, double e = FUZZY_EPSILON) => a == b || Math.Abs(a - b) <= eps(a, b, e);
		#endregion

		#region "fuzzy not equal"
		/// <summary>
		/// Check if <paramref name="a"/> is not approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyNe(float a, float b, float e = FUZZY_EPSILONF) => !fuzzyEq(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is not approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyNe(double a, double b, double e = FUZZY_EPSILON) => !fuzzyEq(a, b, e);
		#endregion

		#region "fuzzy strictly greater than"
		/// <summary>
		/// Check if <paramref name="a"/> is strictly greater than <paramref name="b"/> by at least a minimum value, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyGt(float a, float b, float e = FUZZY_EPSILONF) => a > b + eps(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is strictly greater than <paramref name="b"/> by at least a minimum value, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyGt(double a, double b, double e = FUZZY_EPSILON) => a > b + eps(a, b, e);
		#endregion

		#region "fuzzy approximately greater than"
		/// <summary>
		/// Check if <paramref name="a"/> is greater than or approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		/// <returns>Guaranteed <see langword="false"/> if <paramref name="a"/> &gt;= <paramref name="b"/>, possibly <see langword="false"/> if <paramref name="a"/> &lt; <paramref name="b"/>.</returns>
		public static bool fuzzyGe(float a, float b, float e = FUZZY_EPSILONF) => a > b - eps(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is greater than or approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		/// <returns>Guaranteed <see langword="false"/> if <paramref name="a"/> &gt;= <paramref name="b"/>, possibly <see langword="false"/> if <paramref name="a"/> &lt; <paramref name="b"/>.</returns>
		public static bool fuzzyGe(double a, double b, double e = FUZZY_EPSILON) => a > b - eps(a, b, e);
		#endregion

		#region "fuzzy strictly less than"
		/// <summary>
		/// Check if <paramref name="a"/> is strictly less than <paramref name="b"/> by at least a minimum value, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyLt(float a, float b, float e = FUZZY_EPSILONF) => a < b - eps(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is strictly less than <paramref name="b"/> by at least a minimum value, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyLt(double a, double b, double e = FUZZY_EPSILON) => a < b - eps(a, b, e);
		#endregion

		#region "fuzzy approximately less than"
		/// <summary>
		/// Check if <paramref name="a"/> is less than or approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyLe(float a, float b, float e = FUZZY_EPSILONF) => a < b + eps(a, b, e);
		/// <summary>
		/// Check if <paramref name="a"/> is less than or approximately equal to <paramref name="b"/>, with a given tolerance <paramref name="e"/>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="e">tolerance</param>
		public static bool fuzzyLe(double a, double b, double e = FUZZY_EPSILON) => a < b + eps(a, b, e);
		#endregion

		#region "approximately"
		/// <summary>
		/// Compares two floating point values.
		/// <para>Floating point imprecision makes comparing <see cref="float"/>s using the equals operator inaccurate. For example, (1.0 == 10.0 / 10.0) might not return <see langword="true"/>  every time. <see cref="approximately(float,float)"/> compares two <see cref="float"/>s and returns <see langword="true"/>  if they are within a small value (0.000001) of each other.</para>
		/// </summary>
		/// <returns><see langword="true"/> if they are similar.</returns>
		public static bool approximately(float a, float b) => Math.Abs(a - b) < FUZZY_EPSILONF;

		/// <summary>
		/// Compares two floating point values.
		/// <para>Floating point imprecision makes comparing <see cref="double"/>s using the equals operator inaccurate. For example, (1.0 == 10.0 / 10.0) might not return <see langword="true"/>  every time. <see cref="approximately(double,double)"/> compares two <see cref="double"/>s and returns <see langword="true"/>  if they are within a small value (0.000001) of each other.</para>
		/// </summary>
		/// <returns><see langword="true"/> if they are similar.</returns>
		public static bool approximately(double a, double b) => Math.Abs(a - b) < FUZZY_EPSILON;
		#endregion

		#endregion

		#region "error functions"

		#region "erf"
		/// <summary>
		/// Returns the value of the gaussian error function at <paramref name="x"/>.
		/// </summary>
		public static double erf(double x)
		{
			#region Constants

			const double tiny = 1e-300;
			const double erx = 8.45062911510467529297e-01;

			// Coefficients for approximation to erf on [0, 0.84375]
			const double efx = 1.28379167095512586316e-01; /* 0x3FC06EBA; 0x8214DB69 */
			const double efx8 = 1.02703333676410069053e+00; /* 0x3FF06EBA; 0x8214DB69 */
			const double pp0 = 1.28379167095512558561e-01; /* 0x3FC06EBA; 0x8214DB68 */
			const double pp1 = -3.25042107247001499370e-01; /* 0xBFD4CD7D; 0x691CB913 */
			const double pp2 = -2.84817495755985104766e-02; /* 0xBF9D2A51; 0xDBD7194F */
			const double pp3 = -5.77027029648944159157e-03; /* 0xBF77A291; 0x236668E4 */
			const double pp4 = -2.37630166566501626084e-05; /* 0xBEF8EAD6; 0x120016AC */
			const double qq1 = 3.97917223959155352819e-01; /* 0x3FD97779; 0xCDDADC09 */
			const double qq2 = 6.50222499887672944485e-02; /* 0x3FB0A54C; 0x5536CEBA */
			const double qq3 = 5.08130628187576562776e-03; /* 0x3F74D022; 0xC4D36B0F */
			const double qq4 = 1.32494738004321644526e-04; /* 0x3F215DC9; 0x221C1A10 */
			const double qq5 = -3.96022827877536812320e-06; /* 0xBED09C43; 0x42A26120 */

			// Coefficients for approximation to erf in [0.84375, 1.25]
			const double pa0 = -2.36211856075265944077e-03; /* 0xBF6359B8; 0xBEF77538 */
			const double pa1 = 4.14856118683748331666e-01; /* 0x3FDA8D00; 0xAD92B34D */
			const double pa2 = -3.72207876035701323847e-01; /* 0xBFD7D240; 0xFBB8C3F1 */
			const double pa3 = 3.18346619901161753674e-01; /* 0x3FD45FCA; 0x805120E4 */
			const double pa4 = -1.10894694282396677476e-01; /* 0xBFBC6398; 0x3D3E28EC */
			const double pa5 = 3.54783043256182359371e-02; /* 0x3FA22A36; 0x599795EB */
			const double pa6 = -2.16637559486879084300e-03; /* 0xBF61BF38; 0x0A96073F */
			const double qa1 = 1.06420880400844228286e-01; /* 0x3FBB3E66; 0x18EEE323 */
			const double qa2 = 5.40397917702171048937e-01; /* 0x3FE14AF0; 0x92EB6F33 */
			const double qa3 = 7.18286544141962662868e-02; /* 0x3FB2635C; 0xD99FE9A7 */
			const double qa4 = 1.26171219808761642112e-01; /* 0x3FC02660; 0xE763351F */
			const double qa5 = 1.36370839120290507362e-02; /* 0x3F8BEDC2; 0x6B51DD1C */
			const double qa6 = 1.19844998467991074170e-02; /* 0x3F888B54; 0x5735151D */

			// Coefficients for approximation to erfc in [1.25, 1/0.35]
			const double ra0 = -9.86494403484714822705e-03; /* 0xBF843412; 0x600D6435 */
			const double ra1 = -6.93858572707181764372e-01; /* 0xBFE63416; 0xE4BA7360 */
			const double ra2 = -1.05586262253232909814e+01; /* 0xC0251E04; 0x41B0E726 */
			const double ra3 = -6.23753324503260060396e+01; /* 0xC04F300A; 0xE4CBA38D */
			const double ra4 = -1.62396669462573470355e+02; /* 0xC0644CB1; 0x84282266 */
			const double ra5 = -1.84605092906711035994e+02; /* 0xC067135C; 0xEBCCABB2 */
			const double ra6 = -8.12874355063065934246e+01; /* 0xC0545265; 0x57E4D2F2 */
			const double ra7 = -9.81432934416914548592e+00; /* 0xC023A0EF; 0xC69AC25C */
			const double sa1 = 1.96512716674392571292e+01; /* 0x4033A6B9; 0xBD707687 */
			const double sa2 = 1.37657754143519042600e+02; /* 0x4061350C; 0x526AE721 */
			const double sa3 = 4.34565877475229228821e+02; /* 0x407B290D; 0xD58A1A71 */
			const double sa4 = 6.45387271733267880336e+02; /* 0x40842B19; 0x21EC2868 */
			const double sa5 = 4.29008140027567833386e+02; /* 0x407AD021; 0x57700314 */
			const double sa6 = 1.08635005541779435134e+02; /* 0x405B28A3; 0xEE48AE2C */
			const double sa7 = 6.57024977031928170135e+00; /* 0x401A47EF; 0x8E484A93 */
			const double sa8 = -6.04244152148580987438e-02; /* 0xBFAEEFF2; 0xEE749A62 */

			// Coefficients for approximation to erfc in [1/0.35, 28]
			const double rb0 = -9.86494292470009928597e-03; /* 0xBF843412; 0x39E86F4A */
			const double rb1 = -7.99283237680523006574e-01; /* 0xBFE993BA; 0x70C285DE */
			const double rb2 = -1.77579549177547519889e+01; /* 0xC031C209; 0x555F995A */
			const double rb3 = -1.60636384855821916062e+02; /* 0xC064145D; 0x43C5ED98 */
			const double rb4 = -6.37566443368389627722e+02; /* 0xC083EC88; 0x1375F228 */
			const double rb5 = -1.02509513161107724954e+03; /* 0xC0900461; 0x6A2E5992 */
			const double rb6 = -4.83519191608651397019e+02; /* 0xC07E384E; 0x9BDC383F */
			const double sb1 = 3.03380607434824582924e+01; /* 0x403E568B; 0x261D5190 */
			const double sb2 = 3.25792512996573918826e+02; /* 0x40745CAE; 0x221B9F0A */
			const double sb3 = 1.53672958608443695994e+03; /* 0x409802EB; 0x189D5118 */
			const double sb4 = 3.19985821950859553908e+03; /* 0x40A8FFB7; 0x688C246A */
			const double sb5 = 2.55305040643316442583e+03; /* 0x40A3F219; 0xCEDF3BE6 */
			const double sb6 = 4.74528541206955367215e+02; /* 0x407DA874; 0xE79FE763 */
			const double sb7 = -2.24409524465858183362e+01; /* 0xC03670E2; 0x42712D62 */

			#endregion

			if (double.IsNaN(x))
				return double.NaN;

			if (double.IsNegativeInfinity(x))
				return -1.0;

			if (double.IsPositiveInfinity(x))
				return 1.0;

			int n0, hx, ix;//, i;
			double R, S, P, Q, s, y, z, r;
			unsafe
			{
				double one = 1.0;
				n0 = ((*(int*)&one) >> 29) ^ 1;
				hx = *(n0 + (int*)&x);
			}
			ix = hx & 0x7FFFFFFF;

			if (ix < 0x3FEB0000) // |x| < 0.84375
			{
				if (ix < 0x3E300000) // |x| < 2**-28
				{
					if (ix < 0x00800000)
						return 0.125 * (8.0 * x + efx8 * x); // avoid underflow
					return x + efx * x;
				}
				z = x * x;
				r = pp0 + z * (pp1 + z * (pp2 + z * (pp3 + z * pp4)));
				s = 1.0 + z * (qq1 + z * (qq2 + z * (qq3 + z * (qq4 + z * qq5))));
				y = r / s;
				return x + x * y;
			}
			if (ix < 0x3FF40000) // 0.84375 <= |x| < 1.25
			{
				s = Math.Abs(x) - 1.0;
				P = pa0 + s * (pa1 + s * (pa2 + s * (pa3 + s * (pa4 + s * (pa5 + s * pa6)))));
				Q = 1.0 + s * (qa1 + s * (qa2 + s * (qa3 + s * (qa4 + s * (qa5 + s * qa6)))));
				if (hx >= 0)
					return erx + P / Q;
				else
					return -erx - P / Q;
			}
			if (ix >= 0x40180000) // inf > |x| >= 6
			{
				if (hx >= 0)
					return 1.0 - tiny;
				else
					return tiny - 1.0;
			}
			x = Math.Abs(x);
			s = 1.0 / (x * x);
			if (ix < 0x4006DB6E) // |x| < 1/0.35
			{
				R = ra0 + s * (ra1 + s * (ra2 + s * (ra3 + s * (ra4 + s * (ra5 + s * (ra6 + s * ra7))))));
				S = 1.0 + s * (sa1 + s * (sa2 + s * (sa3 + s * (sa4 + s * (sa5 + s * (sa6 + s * (sa7 + s * sa8)))))));
			}
			else // |x| >= 1/0.35
			{
				R = rb0 + s * (rb1 + s * (rb2 + s * (rb3 + s * (rb4 + s * (rb5 + s * rb6)))));
				S = 1.0 + s * (sb1 + s * (sb2 + s * (sb3 + s * (sb4 + s * (sb5 + s * (sb6 + s * sb7))))));
			}
			z = x;
			unsafe { *(1 - n0 + (int*)&z) = 0; }
			r = Math.Exp(-z * z - 0.5625) * Math.Exp((z - x) * (z + x) + R / S);
			if (hx >= 0)
				return 1.0 - r / x;
			else
				return r / x - 1.0;
		}
		#endregion

		#region "erfc"
		/// <summary>
		/// Returns the value of the complementary error function at <paramref name="x"/>.
		/// </summary>
		public static double erfc(double x)
		{
			#region Constants

			const double tiny = 1e-300;
			const double erx = 8.45062911510467529297e-01;

			// Coefficients for approximation to erf on [0, 0.84375]
			//const double efx = 1.28379167095512586316e-01; /* 0x3FC06EBA; 0x8214DB69 */
			//const double efx8 = 1.02703333676410069053e+00; /* 0x3FF06EBA; 0x8214DB69 */
			const double pp0 = 1.28379167095512558561e-01; /* 0x3FC06EBA; 0x8214DB68 */
			const double pp1 = -3.25042107247001499370e-01; /* 0xBFD4CD7D; 0x691CB913 */
			const double pp2 = -2.84817495755985104766e-02; /* 0xBF9D2A51; 0xDBD7194F */
			const double pp3 = -5.77027029648944159157e-03; /* 0xBF77A291; 0x236668E4 */
			const double pp4 = -2.37630166566501626084e-05; /* 0xBEF8EAD6; 0x120016AC */
			const double qq1 = 3.97917223959155352819e-01; /* 0x3FD97779; 0xCDDADC09 */
			const double qq2 = 6.50222499887672944485e-02; /* 0x3FB0A54C; 0x5536CEBA */
			const double qq3 = 5.08130628187576562776e-03; /* 0x3F74D022; 0xC4D36B0F */
			const double qq4 = 1.32494738004321644526e-04; /* 0x3F215DC9; 0x221C1A10 */
			const double qq5 = -3.96022827877536812320e-06; /* 0xBED09C43; 0x42A26120 */

			// Coefficients for approximation to erf in [0.84375, 1.25]
			const double pa0 = -2.36211856075265944077e-03; /* 0xBF6359B8; 0xBEF77538 */
			const double pa1 = 4.14856118683748331666e-01; /* 0x3FDA8D00; 0xAD92B34D */
			const double pa2 = -3.72207876035701323847e-01; /* 0xBFD7D240; 0xFBB8C3F1 */
			const double pa3 = 3.18346619901161753674e-01; /* 0x3FD45FCA; 0x805120E4 */
			const double pa4 = -1.10894694282396677476e-01; /* 0xBFBC6398; 0x3D3E28EC */
			const double pa5 = 3.54783043256182359371e-02; /* 0x3FA22A36; 0x599795EB */
			const double pa6 = -2.16637559486879084300e-03; /* 0xBF61BF38; 0x0A96073F */
			const double qa1 = 1.06420880400844228286e-01; /* 0x3FBB3E66; 0x18EEE323 */
			const double qa2 = 5.40397917702171048937e-01; /* 0x3FE14AF0; 0x92EB6F33 */
			const double qa3 = 7.18286544141962662868e-02; /* 0x3FB2635C; 0xD99FE9A7 */
			const double qa4 = 1.26171219808761642112e-01; /* 0x3FC02660; 0xE763351F */
			const double qa5 = 1.36370839120290507362e-02; /* 0x3F8BEDC2; 0x6B51DD1C */
			const double qa6 = 1.19844998467991074170e-02; /* 0x3F888B54; 0x5735151D */

			// Coefficients for approximation to erfc in [1.25, 1/0.35]
			const double ra0 = -9.86494403484714822705e-03; /* 0xBF843412; 0x600D6435 */
			const double ra1 = -6.93858572707181764372e-01; /* 0xBFE63416; 0xE4BA7360 */
			const double ra2 = -1.05586262253232909814e+01; /* 0xC0251E04; 0x41B0E726 */
			const double ra3 = -6.23753324503260060396e+01; /* 0xC04F300A; 0xE4CBA38D */
			const double ra4 = -1.62396669462573470355e+02; /* 0xC0644CB1; 0x84282266 */
			const double ra5 = -1.84605092906711035994e+02; /* 0xC067135C; 0xEBCCABB2 */
			const double ra6 = -8.12874355063065934246e+01; /* 0xC0545265; 0x57E4D2F2 */
			const double ra7 = -9.81432934416914548592e+00; /* 0xC023A0EF; 0xC69AC25C */
			const double sa1 = 1.96512716674392571292e+01; /* 0x4033A6B9; 0xBD707687 */
			const double sa2 = 1.37657754143519042600e+02; /* 0x4061350C; 0x526AE721 */
			const double sa3 = 4.34565877475229228821e+02; /* 0x407B290D; 0xD58A1A71 */
			const double sa4 = 6.45387271733267880336e+02; /* 0x40842B19; 0x21EC2868 */
			const double sa5 = 4.29008140027567833386e+02; /* 0x407AD021; 0x57700314 */
			const double sa6 = 1.08635005541779435134e+02; /* 0x405B28A3; 0xEE48AE2C */
			const double sa7 = 6.57024977031928170135e+00; /* 0x401A47EF; 0x8E484A93 */
			const double sa8 = -6.04244152148580987438e-02; /* 0xBFAEEFF2; 0xEE749A62 */

			// Coefficients for approximation to erfc in [1/0.35, 28]
			const double rb0 = -9.86494292470009928597e-03; /* 0xBF843412; 0x39E86F4A */
			const double rb1 = -7.99283237680523006574e-01; /* 0xBFE993BA; 0x70C285DE */
			const double rb2 = -1.77579549177547519889e+01; /* 0xC031C209; 0x555F995A */
			const double rb3 = -1.60636384855821916062e+02; /* 0xC064145D; 0x43C5ED98 */
			const double rb4 = -6.37566443368389627722e+02; /* 0xC083EC88; 0x1375F228 */
			const double rb5 = -1.02509513161107724954e+03; /* 0xC0900461; 0x6A2E5992 */
			const double rb6 = -4.83519191608651397019e+02; /* 0xC07E384E; 0x9BDC383F */
			const double sb1 = 3.03380607434824582924e+01; /* 0x403E568B; 0x261D5190 */
			const double sb2 = 3.25792512996573918826e+02; /* 0x40745CAE; 0x221B9F0A */
			const double sb3 = 1.53672958608443695994e+03; /* 0x409802EB; 0x189D5118 */
			const double sb4 = 3.19985821950859553908e+03; /* 0x40A8FFB7; 0x688C246A */
			const double sb5 = 2.55305040643316442583e+03; /* 0x40A3F219; 0xCEDF3BE6 */
			const double sb6 = 4.74528541206955367215e+02; /* 0x407DA874; 0xE79FE763 */
			const double sb7 = -2.24409524465858183362e+01; /* 0xC03670E2; 0x42712D62 */

			#endregion

			if (double.IsNaN(x))
				return double.NaN;

			if (double.IsNegativeInfinity(x))
				return 2.0;

			if (double.IsPositiveInfinity(x))
				return 0.0;

			int n0, hx, ix;
			double R, S, P, Q, s, y, z, r;
			unsafe
			{
				double one = 1.0;
				n0 = ((*(int*)&one) >> 29) ^ 1;
				hx = *(n0 + (int*)&x);
			}
			ix = hx & 0x7FFFFFFF;

			if (ix < 0x3FEB0000) // |x| < 0.84375
			{
				if (ix < 0x3C700000) // |x| < 2**-56
					return 1.0 - x;
				z = x * x;
				r = pp0 + z * (pp1 + z * (pp2 + z * (pp3 + z * pp4)));
				s = 1.0 + z * (qq1 + z * (qq2 + z * (qq3 + z * (qq4 + z * qq5))));
				y = r / s;
				if (hx < 0x3FD00000) // x < 1/4
					return 1.0 - (x + x * y);
				else
				{
					r = x * y;
					r += (x - 0.5);
					return 0.5 - r;
				}
			}
			if (ix < 0x3FF40000) // 0.84375 <= |x| < 1.25
			{
				s = Math.Abs(x) - 1.0;
				P = pa0 + s * (pa1 + s * (pa2 + s * (pa3 + s * (pa4 + s * (pa5 + s * pa6)))));
				Q = 1.0 + s * (qa1 + s * (qa2 + s * (qa3 + s * (qa4 + s * (qa5 + s * qa6)))));
				if (hx >= 0)
				{
					z = 1.0 - erx;
					return z - P / Q;
				}
				else
				{
					z = erx + P / Q;
					return 1.0 + z;
				}
			}
			if (ix < 0x403C0000) // |x| < 28
			{
				x = Math.Abs(x);
				s = 1.0 / (x * x);
				if (ix < 0x4006DB6D) // |x| < 1/.35 ~ 2.857143
				{
					R = ra0 + s * (ra1 + s * (ra2 + s * (ra3 + s * (ra4 + s * (ra5 + s * (ra6 + s * ra7))))));
					S = 1.0 + s * (sa1 + s * (sa2 + s * (sa3 + s * (sa4 + s * (sa5 + s * (sa6 + s * (sa7 + s * sa8)))))));
				}
				else // |x| >= 1/.35 ~ 2.857143
				{
					if (hx < 0 && ix >= 0x40180000)
						return 2.0 - tiny; // x < -6
					R = rb0 + s * (rb1 + s * (rb2 + s * (rb3 + s * (rb4 + s * (rb5 + s * rb6)))));
					S = 1.0 + s * (sb1 + s * (sb2 + s * (sb3 + s * (sb4 + s * (sb5 + s * (sb6 + s * sb7))))));
				}
				z = x;
				unsafe { *(1 - n0 + (int*)&z) = 0; }
				r = Math.Exp(-z * z - 0.5625) *
				Math.Exp((z - x) * (z + x) + R / S);
				if (hx > 0)
					return r / x;
				else
					return 2.0 - r / x;
			}
			else
			{
				if (hx > 0)
					return tiny * tiny;
				else
					return 2.0 - tiny;
			}
		}
		#endregion

		#endregion

		#region "16"
		private const double TWO_PI = Math.PI * 2;
		private const double HALF_PI = Math.PI / 2;

		/// <summary>
		/// 16-bit approximation of <see cref="Math.Sin(double)"/>.
		/// </summary>
		public static double sin16(double a)
		{
			double s;

			if (a < 0 || a >= TWO_PI)
				a -= Math.Floor(a / TWO_PI) * TWO_PI;

			if (a < Math.PI)
			{
				if (a > HALF_PI)
					a = Math.PI - a;
			}
			else
			{
				if (a > Math.PI + HALF_PI)
					a -= TWO_PI;
				else
					a = Math.PI - a;
			}

			s = a * a;
			return a * (((((-2.39e-8 * s + 2.7526e-6) * s - 1.98409e-4) * s + 8.3333315e-3) * s - 1.666666664e-1) * s + 1);
		}

		/// <summary>
		/// 16-bit approximation of <see cref="Math.Atan(double)"/>.
		/// </summary>
		public static double atan16(double a)
		{
			double s;

			if (Math.Abs(a) > 1)
			{
				a = 1 / a;
				s = a * a;
				s = -(((((((((0.0028662257 * s - 0.0161657367) * s + 0.0429096138) * s - 0.0752896400)
					* s + 0.1065626393) * s - 0.1420889944) * s + 0.1999355085) * s - 0.3333314528) * s) + 1.0) * a;

				if (math.signbit(a) == 1)
					return s - HALF_PI;
				else
					return s + HALF_PI;
			}
			else
			{
				s = a * a;
				return (((((((((0.0028662257 * s - 0.0161657367) * s + 0.0429096138) * s - 0.0752896400)
					* s + 0.1065626393) * s - 0.1420889944) * s + 0.1999355085) * s - 0.3333314528) * s) + 1.0) * a;
			}
		}
		#endregion

		#region "converters"
		/// <summary>
		/// Different measurements.
		/// </summary>
		public enum Measurement
		{
			/// <summary>
			/// <aliases>km, kilometers, kilometre, kilometres</aliases>
			/// <para>Converts to <see cref="Mile"/></para>
			/// </summary>
			Kilometer,
			/// <summary>
			/// <aliases>m, meters, metre, metres</aliases>
			/// <para>Converts to <see cref="Foot"/></para>
			/// </summary>
			Meter,
			/// <summary>
			/// <aliases>mi, miles</aliases>
			/// <para>Converts to <see cref="Kilometer"/></para>
			/// </summary>
			Mile,
			/// <summary>
			/// <aliases>ft, feet</aliases>
			/// <para>Converts to <see cref="Meter"/></para>
			/// </summary>
			Foot,
			/// <summary>
			/// <aliases>in, inches</aliases>
			/// <para>Converts to <see cref="Centimeter"/></para>
			/// </summary>
			Inch,
			/// <summary>
			/// <aliases>cm, centimeters, centimetre, centimetres</aliases>
			/// <para>Converts to <see cref="Inch"/></para>
			/// </summary>
			Centimeter,
			/// <summary>
			/// <aliases>kg, kilograms</aliases>
			/// <para>Converts to <see cref="Pound"/></para>
			/// </summary>
			Kilogram,
			/// <summary>
			/// <aliases>lb, pounds, lbs</aliases>
			/// <para>Converts to <see cref="Kilogram"/></para>
			/// </summary>
			Pound,
			/// <summary>
			/// <aliases>F, degF, °F, degreesF, *F</aliases>
			/// <para>Converts to <see cref="Celsius"/></para>
			/// </summary>
			Fahrenheit,
			/// <summary>
			/// <aliases>C, degC, °C, degreesC, *C, celcius, centigrade</aliases>
			/// <para>Converts to <see cref="Fahrenheit"/></para>
			/// </summary>
			Celsius
		}

		/// <summary>
		/// Converts <paramref name="n"/> from <paramref name="u"/> to <paramref name="t"/>.
		/// </summary>
		/// <param name="n">this is what gets converted</param>
		/// <param name="u">starting unit</param>
		/// <param name="t">converted unit</param>
		/// <returns>the converted <paramref name="n"/></returns>
		public static double convert(double n, Measurement u, out Measurement t)
		{
			switch (u)
			{
				case Measurement.Kilometer:
					t = Measurement.Mile;
					return n * 0.621;
				case Measurement.Mile:
					t = Measurement.Kilometer;
					return n * 1.61;
				case Measurement.Meter:
					t = Measurement.Foot;
					return n * 3.28;
				case Measurement.Foot:
					t = Measurement.Meter;
					return n * 0.3048;
				case Measurement.Inch:
					t = Measurement.Centimeter;
					return n * 2.54;
				case Measurement.Centimeter:
					t = Measurement.Inch;
					return n * 0.394;
				case Measurement.Kilogram:
					t = Measurement.Pound;
					return n * 2.2;
				case Measurement.Pound:
					t = Measurement.Kilogram;
					return n * 0.45;
				case Measurement.Fahrenheit:
					t = Measurement.Celsius;
					return (n - 32) * 5 / 9;
				case Measurement.Celsius:
					t = Measurement.Fahrenheit;
					return n * 9 / 5 + 32;
				default:
					t = u;
					return n;
			}
		}

		#endregion
	}
}
