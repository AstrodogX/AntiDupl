using System;
using System.Linq;
using System.Drawing;

namespace AntiDupl.NET
{
	class Highlight
	{
		public static Color ColorParity   = Color.Blue;
		public static Color ColorSuperior = Color.Green;
		public static Color ColorInferior = Color.Red;

		private static readonly CoreDll.ImageType[] LosslessTypes = { 
			CoreDll.ImageType.Png, CoreDll.ImageType.Bmp, CoreDll.ImageType.Gif,
			CoreDll.ImageType.Psd, CoreDll.ImageType.Tga, CoreDll.ImageType.Tiff
		};

		public static Color ImageType(CoreDll.ImageType type, CoreDll.ImageType opposite, Color defaultColor)
		{
			if (type == opposite) {
				return defaultColor;
			}

			if (LosslessTypes.Contains(opposite)) {
				if (LosslessTypes.Contains(type)) {
					return ColorParity;
				} else {
					return ColorInferior;
				}
			} else if (LosslessTypes.Contains(type)) {
				return ColorSuperior;
			}

			return ColorParity;
		}

		public static Color ImageType(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return ImageType(info.type, opposite.type, defaultColor);
		}

		private static bool IsExifsEqual(CoreDll.adImageExifW exif1, CoreDll.adImageExifW exif2)
		{
			if (exif1.isEmpty != exif2.isEmpty) {
				return false;
			}

			if (exif1.isEmpty == CoreDll.TRUE) {
				return true;
			}

			if (
				exif1.artist.CompareTo(exif2.artist) == 0 &&
				exif1.dateTime.CompareTo(exif2.dateTime) == 0 &&
				exif1.equipMake.CompareTo(exif2.equipMake) == 0 &&
				exif1.equipModel.CompareTo(exif2.equipModel) == 0 &&
				exif1.imageDescription.CompareTo(exif2.imageDescription) == 0 &&
				exif1.softwareUsed.CompareTo(exif2.softwareUsed) == 0 &&
				exif1.userComment.CompareTo(exif2.userComment) == 0
			) {
				return true;
			}
			return false;
		}

		public static Color ImageExif(CoreDll.adImageExifW exif, CoreDll.adImageExifW opposite, Color defaultColor)
		{
			if (IsExifsEqual(exif, opposite)) {
				return defaultColor;
			}
			if (exif.isEmpty == CoreDll.FALSE) {
				if (opposite.isEmpty == CoreDll.FALSE) {
					return ColorParity;
				} else {
					return ColorSuperior;
				}
			}
			return ColorInferior;
		}

		public static Color ImageExif(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return ImageExif(info.exifInfo, opposite.exifInfo, defaultColor);
		}
		
		public static Color ImageSize(ulong size, ulong opposite, Color defaultColor)
		{
			return size < opposite ? ColorInferior : defaultColor;
		}

		public static Color ImageSize(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return ImageSize(info.size, opposite.size, defaultColor);
		}

		public static Color ImageDimension(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return info.height * info.width < opposite.height * opposite.width ? ColorInferior : defaultColor;
		}

		public static Color ImageBlockiness(double blockiness, double opposite, Color defaultColor)
		{
			return blockiness > opposite ? ColorInferior : defaultColor;
		}

		public static Color ImageBlockiness(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return ImageBlockiness(info.blockiness, opposite.blockiness, defaultColor);
		}

		public static Color ImageBlurring(double blurring, double opposite, Color defaultColor)
		{
			return blurring > opposite ? ColorInferior : defaultColor;
		}

		public static Color ImageBlurring(CoreImageInfo info, CoreImageInfo opposite, Color defaultColor)
		{
			return ImageBlurring(info.blurring, opposite.blurring, defaultColor);
		}

		public CoreImageInfo First  { get; set; }
		public CoreImageInfo Second { get; set; }
		public Color DefaultColor { get; set; }

		public Highlight(CoreImageInfo first, CoreImageInfo second, Color defaultColor)
		{
			First = first;
			Second = second;
			DefaultColor = defaultColor;
		}

		public Color ImageType(bool reverse = false)
		{
			return reverse ? ImageType(Second, First, DefaultColor) : ImageType(First, Second, DefaultColor);
		}

		public Color ImageExif(bool reverse = false)
		{
			return reverse ? ImageExif(Second, First, DefaultColor) : ImageExif(First, Second, DefaultColor);
		}

		public Color ImageSize(bool reverse = false)
		{
			return reverse ? ImageSize(Second, First, DefaultColor) : ImageSize(First, Second, DefaultColor);
		}

		public Color ImageDimension(bool reverse = false)
		{
			return reverse ? ImageDimension(Second, First, DefaultColor) : ImageDimension(First, Second, DefaultColor);
		}

		public Color ImageBlockiness(bool reverse = false)
		{
			return reverse ? ImageBlockiness(Second, First, DefaultColor) : ImageBlockiness(First, Second, DefaultColor);
		}

		public Color ImageBlurring(bool reverse = false)
		{
			return reverse ? ImageBlurring(Second, First, DefaultColor) : ImageBlurring(First, Second, DefaultColor);
		}
	}
}
