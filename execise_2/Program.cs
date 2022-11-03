using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assg3
{
    class Program
    {
        private static int[] hilmy = new int[72];
        private static int n;

        public void masuk() //metod untuk input data
        {
            while (true)// Perulangan data yang diinginkan
            {
                Console.Write("Masukkan banyaknya array : ");
                string masuk = Console.ReadLine();
                n = Int32.Parse(masuk);
                if (n <= 72)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nMaksimal array 72 Elemen\n");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("--------------------------");
            Console.WriteLine(" Masukkan elemen array ");
            Console.WriteLine("---------------------------");

            for (int i = 0; i < n; i++)
            {
                Console.Write("{" + (i + 1) + "}. ");
                string masukArr = Console.ReadLine();
                hilmy[i] = Int32.Parse(masukArr);
            }
        }

        public void Insertion()// Method dari insertion sort
        {
            int temp, min_index;
            for (int my = 0; my < n - 1; my++)
            {
                min_index = my;
                for (int j = my + 1; j < n; j++)
                {
                    if (hilmy[j] < hilmy[min_index])
                    {
                        min_index = j;
                    }
                }
                temp = hilmy[min_index];
                hilmy[min_index] = hilmy[my];
                hilmy[my] = temp;
            }
        }
        public void Merge(int[] fajri, int low, int high)// Method dari merge sort
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                Merge(hilmy, low, mid);
                Merge(hilmy, mid + 1, high);

                mergerArr(hilmy, low, mid, high);

            }
        }
        public void mergerArr(int[] hilmy, int low, int mid, int high)
        {
            int x = mid - low + 1;
            int y = high - mid;
            int[] H = new int[x];
            int[] I = new int[y];

            int i, my;

            for (int a = 0; a < x; a++)
            {
                H[a] = hilmy[low + a];
            }

            for (int b = 0; b < y; b++)
            {
                I[b] = hilmy[mid + 1 + b];
            }

            int k;
            i = 0;
            my = 0;
            k = low;

            while (i < x && my < y)
            {
                if (H[i] <= I[my])
                {
                    hilmy[k] = H[i];
                    i++;
                }
                else
                {
                    hilmy[k] = I[my];
                    my++;
                }
                k++;
            }

            while (i < x)
            {
                hilmy[k] = H[i];
                i++;
                k++;
            }

            while (my < y)
            {
                hilmy[k] = I[my];
                my++;
                k++;
            }
        }
        public void tampil()//Method untuk menampilkan hasil
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            Console.WriteLine(" Elemen array yang tersusun ");
            Console.WriteLine("----------------------------");
            for (int my = 0; my < n; my++)
            {
                Console.WriteLine(hilmy[my]);
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {

            //deklarasi variabel untuk ekspresi switch
            int pilih;
            //instance untuk kelas program
            Program p = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Pilih Jenis Sort Yang Tersedia= ");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("1. Insertion Sort");
                    Console.WriteLine("2. Merge Sort");
                    Console.WriteLine("3. Keluar");
                    Console.Write("Jenis Sort Pilihan Anda= ");
                    pilih = Convert.ToInt32(Console.ReadLine());
                    switch (pilih)
                    {
                        case 1:
                            p.masuk();
                            p.Insertion();
                            p.tampil();
                            break;
                        case 2:
                            p.masuk();
                            p.Merge(hilmy, 0, n - 1);
                            p.tampil();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Maaf Input Salah");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Harap isi dengan benar");
                }
            }
        }
    }
}