using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap k: ");
            int k = int.Parse(Console.ReadLine());

            int ketQua = TinhToHop_DP_CaiTien(n, k);
            Console.WriteLine("To hop chap {0} cua {1} la: {2}", k, n, ketQua);
            Console.ReadLine();
        }

        static int TinhToHop_DP_CaiTien(int n, int k) //khai báo hàm. Hàm này nhận vào hai tham số nguyên n và k, và trả về một số nguyên (kết quả tổ hợp).
        {
            int[] V = new int[n + 1]; // ****VD như em nhập n = 3, k = 5, thì n + 1 = 4, (nghĩa là sẽ lấy khoảng từ 0-3)***, Tạo một mảng số nguyên V có kích thước n+1. Mảng này sẽ lưu các giá trị tổ hợp.    
            int p1, p2;

            V[0] = 1; //
            V[1] = 1; //Khởi tạo hai phần tử đầu tiên của mảng V. V[0] và V[1] đều bằng 1 vì C(n,0) = C(n,1) = 1 với mọi n.

            for (int i = 2; i <= n; i++) //Bắt đầu vòng lặp ngoài, chạy từ i = 2 đến n. Mỗi lần lặp tính toán các giá trị tổ hợp cho một hàng mới
            {
                p1 = V[0]; //Gán giá trị của V[0] (luôn bằng 1) cho biến p1. p1 sẽ lưu giá trị "trên trái"
                for (int j = 1; j < i; j++) //Bắt đầu vòng lặp trong, chạy từ j = 1 đến i-1. Vòng lặp này cập nhật các giá trị trong hàng hiện tại
                {
                    p2 = V[j]; //Lưu giá trị hiện tại của V[j] vào p2 trước khi cập nhật. p2 sẽ lưu giá trị "trên"
                    V[j] = p1 + p2; //Cập nhật V[j] bằng tổng của p1 (giá trị trên trái) và p2 (giá trị trên). Đây là công thức: C(n,k) = C(n-1,k-1) + C(n-1,k).
                    p1 = p2; //Cập nhật p1 cho lần lặp tiếp theo. Giá trị "trên" hiện tại sẽ trở thành giá trị "trên trái" cho phần tử tiếp theo.
                }
                V[i] = 1; //Sau khi kết thúc vòng lặp trong, gán V[i] = 1. Đây là phần tử cuối cùng của mỗi hàng(C(n,n) = 1).
            }

            return V[k];//Trả về giá trị V[k], đây chính là kết quả của tổ hợp chập k của n (C(n,k)). ****ở đây hàm trả về nghĩa là V[5] là nó vượt quá kích thước đưa ra ở trên là trong khoảng 0-3 ớ.****
        }
    }
}
