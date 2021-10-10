using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_11_12__3_
{
    public class PegawaiKomisi
    {
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string NomorKTP { get; set; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public PegawaiKomisi(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomoisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomoisi;
        }

        public decimal PenjualanKotor
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(PenjualanKotor)} must be > 0 and < 1");
                }
                penjualanKotor = value;
            }
        }

        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, "{typeof(tingkatKomisi)} must be > 0 and < 1");
                }
                tingkatKomisi = value;
            }
        }

        public decimal Laba()
        {
            decimal a = tingkatKomisi * penjualanKotor;
            return a;
        }

        public override string ToString()
        {
            return String.Format("\nPegawai Komisi : {0} {1} \nnomor KTP : {2} \npenjualan kotor : {3:C} \ntingkat komisi : {4:F2}", NamaDepan, NamaBelakang, NomorKTP, penjualanKotor, tingkatKomisi);
        }
    }

    public class PegawaiDasardanKomisi : PegawaiKomisi
    {
        private decimal gajiPokok;

        public PegawaiDasardanKomisi(string namaDepan, string namaBelakang, string nomorKTP,
            decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
            : base(namaDepan, namaBelakang, nomorKTP, penjualanKotor, tingkatKomisi)
        {
            GajiPokok = gajiPokok;
        }

        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(GajiPokok)} must be >= 0");
                }

                gajiPokok = value;
            }
        }

        public virtual decimal Laba()
        {
            return GajiPokok + base.Laba();
        }

        public override string ToString()
        {
            return String.Format("gaji pokok {0} \ngaji pokok : {0:C}", base.ToString(), GajiPokok);
        }
    }
    class TesPolimorfisme
    {
        static void Main()
        {
            var pegawaiKomisi = new PegawaiKomisi("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
            var pegawaiDasardanKomisi = new PegawaiDasardanKomisi("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Panggil metode ToString dan Laba pegawaiKomisi" +
                "\ndengan referensi kelas dasar ke objek kelas dasar\n");
            Console.WriteLine(pegawaiKomisi.ToString());
            Console.WriteLine("laba : {0:C} \n", pegawaiKomisi.Laba());

            Console.WriteLine("===================================================\n");

            Console.WriteLine("Panggil metode ToString dan Laba pegawaiDasardanKomisi" +
                "\ndengan referensi kelas turunan ke objek kelas turunan\n");
            Console.WriteLine(pegawaiDasardanKomisi.ToString());
            Console.WriteLine("laba {0:C} \n", pegawaiDasardanKomisi.Laba());
            Console.WriteLine("===================================================\n");

            PegawaiKomisi pegawaiKomisi2 = pegawaiDasardanKomisi;

            Console.WriteLine("Panggil metode ToString dan Laba PegawaiDasardanKomisi dengan" +
                "\nreferensi kelas dasar ke objek kelas turunan\n");
            Console.WriteLine(pegawaiKomisi2.ToString());
            Console.WriteLine("laba {0:C} \n", pegawaiDasardanKomisi.Laba());

            Console.ReadLine();
        }
    }
}
