
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;

public class SingleDimensionArrays
{
    public static void Main()
    {

        ex_03();
        Console.ReadKey();
    }
    /// <summary>
    /// Single Dimension Arrays Exercises slide 18 <br />
    /// Create a random integer values array, then create functions that:<br />
    /// 1. to calculate the average value of array elements.<br />
    /// 2. to test if an array contains a specific value.<br />
    /// 3. to find the index of an array element.<br />
    /// 4. to remove a specific element from an array.<br />
    /// 5. to find the maximum and minimum value of an array.<br />
    /// 6. to reverse an array of integer values.<br />
    /// 7. to find duplicate values in an array of values.<br />
    /// 8. to remove duplicate elements from an array.<br />
    /// </summary>
    public static void ex_02()
    {
        //tạo mảng và in mảng vừa tạo
        Console.Write("Nhap so phan tu: "); int n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        nhapthucong(a, n);
        inmang(a);
        //1. Tính trung bình giá trị của mảng
        Console.WriteLine($"Trung binh cac phan tu cua mang: {trungbinh(a)}");
        //2. Kiểm tra một giá trị có xuất hiện trong mảng hay không
        Console.Write("Nhap so can tim: __");
        int socantim = int.Parse(Console.ReadLine());
        if (checkvar(a, socantim) == true)
        {
            Console.WriteLine($"Mang co chua {socantim}");
            Console.WriteLine($"So can tim o vi tri {timvitri(a, socantim)} cua mang. ");
        }
        else { Console.WriteLine($"Mang khong chua {socantim}"); }
        //3. Tìm vị trí một giá trị
        Console.Write("Nhap gia tri phan tu can tim vi tri trong mang:_"); int gtri = int.Parse(Console.ReadLine());
        if (timvitri(a, gtri) == -1)
        {
            Console.WriteLine($"{gtri} khong ton tai trong mang");
        }
        else
        { Console.WriteLine($"{gtri} nam o vi tri {timvitri(a, gtri)}"); }
        //4. Xóa một giá trị cụ thể khỏi mảng
        Console.Write("Nhap phan tu can xoa: "); int key = int.Parse(Console.ReadLine());
        Console.WriteLine($"Mang da xoa {key}: "); inmang(xoaphantu(a, key));
        //5. Tìm Max và Min của mảng
        Console.WriteLine($"Gia tri lon nhat va nho nhat cua mang la {timMaxMin(a)}");
        //6. Chuyển vị
        inmang(daomang(a));
        //7. Tìm các giá trị lặp lại trong mảng
        Console.Write("Gia tri lap lai trong mang: ");
        inmang(timgiatrilaplai(a));
        //8. Xóa các giá trị lặp lại ra khỏi mảng
        Console.WriteLine($"Mang da xoa cac gia tri lap lai: ");
        inmang(xoaphantulap(a));

    }
    public static void nhaptudong(int[] a, int n)
    {
        Random ran = new Random();
        for (int i = 0; i < n; i++)
        {
            a[i] = ran.Next(0, 100) + 1;
        }

    }
    public static void inmang(int[] a)
    {
        foreach (int i in a) Console.Write($"{i}  ");
        Console.WriteLine();
    }
    public static float trungbinh(int[] a)
    {
        int sum = 0;
        for (int i = 0; i < a.Length; i++)
            sum += a[i];
        float tb = sum / a.Length;
        return tb;
    }
    public static bool checkvar(int[] a, int key)
    {
        bool ktra = false;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == key) { ktra = true; break; }
        }
        return ktra;
    }
    public static int timvitri(int[] a, int val)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (val == a[i])
            { return i; }
        }
        return -1;
    }
    public static int[] xoaphantu(int[] a, int val)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (val != a[i])
            {
                count++;
            }
        }
        int[] x = new int[count];
        int index = 0;

        foreach (int item in a)
        {
            if (item != val)
            {
                x[index++] = item;
            }
        }
        return x;
    }
    public static (int max, int min) timMaxMin(int[] a)
    {
        int max = 0;
        int min = 0;
        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] < min)
                min = a[i];
            if (a[i] > max) max = a[i];
        }
        return (max, min);
    }
    public static int[] daomang(int[] a)
    {
        int[] x = new int[a.Length];
        for (int i = 0; i < a.Length; ++i)
        {
            x[x.Length - i] = a[i];
        }
        return x;
    }
    public static int[] timgiatrilaplai(int[] a)
    {
        int count = 0;
        int[] lap = new int[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[i] == a[j])
                {
                    // ktra có chép trùng không
                    bool trung = false;
                    for (int k = 0; k < count; k++)
                    {
                        if (lap[k] == a[i])
                        {
                            trung = true;
                            break;
                        }
                    }

                    if (!trung)
                    {
                        lap[count] = a[i];
                        count++;
                    }

                    break;
                }
            }
        }
        // mảng mới chỉ có gtri lặp
        int[] result = new int[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = lap[i];
        }

        return result;
    }
    public static int[] xoaphantulap(int[] a)
    {
        int n = timgiatrilaplai(a).Length;
        int[] result = a;
        foreach (int i in timgiatrilaplai(a))
        {
            for (int j = 0; j < a.Length; j++)
            {
                result = xoaphantu(result, i);
            }
        }
        return result;
    }

    public static int[] nhapthucong(int[] a, int n)
    {
        for (int i = 0; i < n; ++i)
        {
            Console.Write($"Hay nhap phan tu {i}: ");
            a[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        return a;
    }
    /// <summary>
    ///Create a C# program that <br />
    ///- Requests 10 integers from the user and orders them by implementing the bubble sort algorithm.<br />
    ///- Request a sentence from the user, then ask to enter a word.Search if the word appears in the phrase using the linear search algorithm.
    /// </summary>
    public static void ex_03()
    {
        //yêu cầu 1
        int[] a=new int [10];
        Console.WriteLine("Hay nhap 10 so nguyen: ");
        nhapthucong(a, 10);
        Console.WriteLine("Cac so da duoc sap xep theo thu tu tang dan: ");
        inmang(BubbleSort(a));
        Console.WriteLine("Hay nhap mot cau: ");
        //Yêu cầu 2
        string nhap = Console.ReadLine();
        Console.Write("Nhap tu can tim: "); string tim = Console.ReadLine();

        //string[] sentence = nhap.Split(" ");
        string[] sentence = SentenceToArray(nhap,' ');
        if (LinearSearch(sentence, tim) != -1)
        {
            Console.WriteLine($"Trong cau co tu {tim}, la tu thu {LinearSearch(sentence, tim) + 1} trong cau."); ;
        }
        else
        {
            Console.WriteLine($"Trong cau khong co tu {tim}.");
        }
    }
    public static int[] BubbleSort(int[]a)
    {
        for (int i = 0;i < a.Length-1; ++i)
        {
            for (int j = 0;j<a.Length-i-1; ++j)
            {
                if (a[j] > a[j+1])
                {
                    int tam = a[j];
                    a[j] = a[j+1];
                    a[j+1] = tam;
                }    
            }    
        }   
        return a;
    }
    /// <summary>
    /// Chuyển câu thành mảng, tách các từ
    /// </summary>
    /// <param name="sentence">câu được nhập từ bàn phím</param>
    /// <param name="tach"> ký tự giữa các từ</param>
    /// <returns></returns>
    public static string[] SentenceToArray(string sentence, char tach)
    {
        //xóa khoảng trắng bằng split
        //string[] cau=sentence.Split(" ");
        string[] cau = new string[sentence.Length];
        int vitri = 0;
        //Chứa từ trong lúc duyệt
        string tu = "";
        foreach (char a in sentence)
        {
            if (a==tach)
            {
                if (tu.Length > 0)
                {
                    cau[vitri++]= tu;
                    tu = "";
                }                     
            } 
            else
            {
                tu += a;
            }    
        } 
        if (tu.Length > 0)
        {
            cau[vitri++]= tu;
        } 
        //tạo lại mảng khác có độ dài chính xác
        string[] result = new string[vitri];
        for (int i =0; i < vitri; i++)
        {
            result[i] = cau[i];
        } 
            
        return result;
    }
    public static int LinearSearch(string[] sentence, string tim)
    {
        for (int i = 0; i < sentence.Length; ++i)
        {
            if (sentence[i] == tim)
                return i;
        }
        return -1;
    }
}


