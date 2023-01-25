using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using PP03Korsun.DataFolder;

namespace PP03Korsun.ClassFolder
{
    class ImageClass
    {
        /// <summary>
        /// Метод для конвертации из БД изображения в Image на окне
        /// </summary>
        /// <param name="array">Поле из БД</param>
        /// <returns>изображение</returns>
        public static BitmapImage ConvertByteArrayToImage(byte[] array)
        {
            if (array != null) //если байтовый массив не пустой
            {
                using (var ms = new MemoryStream(array, 0, array.Length)) //записываем полученные данные в массив для дальнейшего преобразования
                {
                    var image = new BitmapImage(); //Инициализирует новый экземпляр класса BitmapImage, 
                                                   //который в основном существует для поддержки синтаксиса XAML (XAML) 
                                                   //и предоставляет дополнительные свойства для загрузки битовой карты
                    image.BeginInit(); //Сигнализирует о начале инициализации объекта BitmapImage.
                    image.CacheOption = BitmapCacheOption.OnLoad; //CacheOption Получает BitmapCacheOption для использования данным экземпляром BitmapImage.
                                                                  //BitmapCacheOption.OnLoad Кэширует в памяти все изображение во время загрузки. Все запросы данных изображения выполняются из хранилища в памяти.
                    image.StreamSource = ms; //Получает исходный поток BitmapImage.
                    image.EndInit(); //Сигнализирует о завершении инициализации объекта BitmapImage.
                    return image;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод для конвертирования из Image на окне в массив байтов для БД
        /// </summary>
        /// <param name = "fileName" > строка из диалогового окна</param>
        /// <returns>массив байтов</returns>
        public static byte[] ConvertImageToByteArray(string fileName)
        {
            Bitmap bitMap = new Bitmap(fileName);
            ImageFormat bmpFormat = bitMap.RawFormat;
            var imageToConvert = Image.FromFile(fileName);
            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, bmpFormat);
                return ms.ToArray();
            }
        }




        public static byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        //public static void AddPhoto(Image ImPhoto, )
        //{
        //    OpenFileDialog op = new OpenFileDialog();
        //    op.InitialDirectory = "";
        //    op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        //        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        //        "Portable Network Graphic (*.png)|*.png";

        //    if (op.ShowDialog() == true)
        //    {
        //        string selectedFileName = op.FileName;
        //        user.Image = ClassImage.ConvertImageToByteArray(selectedFileName);
        //        ImPhoto.Source = ClassImage.ConvertByteArrayToImage(user.Image);
        //    }

        //}


        //public byte[] ConvertImageToByteArray(Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, ImageFormat.Gif);

        //        return ms.ToArray();
        //    }
        //}

        //public Image ConvertByteArrayToImage(byte[] byteArrayIn)
        //{
        //    using (var ms = new MemoryStream(byteArrayIn))
        //    {
        //        var returnImage = Image.FromStream(ms);

        //        return returnImage;
        //    }
        //}
    }
}
