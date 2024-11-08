using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Multiple_choice_test_program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Tạo danh sách câu hỏi
            List<MultipleChoiceQuestion> questions = new List<MultipleChoiceQuestion>       
            {
                new MultipleChoiceQuestion(1, "Số nào sau đây là căn bậc hai số học của số a = 2,25", new List<string> { "1,5", "–1,5 và 1,5", "1,25", "-1,5" }, "1,5"),
                new MultipleChoiceQuestion(2, "Số nào sau đây là căn bậc hai số học của số a = 0,36", new List<string> { "-0,6", "0,6", "0,9", "-0,18" }, "0,6"),
                new MultipleChoiceQuestion(3, "Cho hàm số f(x) = 3 – x^2. Tính f(−1)", new List<string> { "-2", "2", "1", "0" }, "2"),
                new MultipleChoiceQuestion(4, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(5, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(6, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(7, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(8, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(9, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(10, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(11, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(12, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(13, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(14, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(15, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(16, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(17, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(18, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(19, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(20, "Cho hàm số f(x) = x^3 + x. Tính f(2)", new List<string> { "4", "6", "8", "10" }, "10"),
                new MultipleChoiceQuestion(21, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(22, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(23, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(24, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(25, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(26, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(27, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(28, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(29, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(30, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(31, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(32, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(33, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(34, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(35, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(36, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(37, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(38, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(39, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(40, "Đơn vị nào dưới đây là đơn vị của điện trở?", new List<string> { "Ôm", "Oát", "Vôn", "Ampe" }, "Ôm"),
                new MultipleChoiceQuestion(42, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(43, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(44, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(45, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(46, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(47, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(48, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(49, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(50, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(51, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(52, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(53, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(54, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(55, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(56, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(57, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(58, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(59, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(60, "Oxit axit có thể tác dụng được với", new List<string> { "Oxit bazo", "nước", "bazo", "Cả 3 hợp chất trên" }, "Cả 3 hợp chất trên"),
                new MultipleChoiceQuestion(61, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(62, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(63, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(64, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(65, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(66, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(67, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(68, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(69, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(70, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(71, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(72, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(73, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(74, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(75, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(76, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(77, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(78, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(79, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(80, "Theo Menđen, yếu tố di truyền nguyên vẹn từ bố mẹ sang con là gì?", new List<string> { "Alen", "kiểu gen", "tính trạng", "nhân tố di truyền" }, "nhân tố di truyền"),
                new MultipleChoiceQuestion(81, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(82, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(83, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(84, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(85, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(86, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(87, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(88, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(89, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(90, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(91, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(92, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(93, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(94, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(95, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(96, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(97, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(98, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(99, "The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded"),
                new MultipleChoiceQuestion(100,"The doll has been___________out of clay.", new List<string> { "embroidered", "cast", "woven", "moulded" }, "moulded")
            };

            // Tạo đối tượng XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<MultipleChoiceQuestion>), new XmlRootAttribute("Questions"));

            // Ghi vào file XML
            using (FileStream stream = new FileStream("questions.xml", FileMode.Create))
            {
                serializer.Serialize(stream, questions);
            }

            Console.WriteLine("XML file has been created successfully!");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
