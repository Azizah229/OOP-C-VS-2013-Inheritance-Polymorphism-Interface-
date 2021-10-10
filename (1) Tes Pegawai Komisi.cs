using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_11_12__1_
{
    class PegawaiKomisi : Object
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
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name , 
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
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name ,
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
            return String.Format("Pegawai Komisi : {0} {1} + \nnomor KTP : {2} \npenjualan kotor : {3:C} \ntingkat komisi : {4:F2}", NamaDepan, NamaBelakang, NomorKTP, penjualanKotor, tingkatKomisi);
        }
    }
    class TesPegawaiKomisi
    {
        static void Main()
        {
            var pegawai = new PegawaiKomisi("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

            Console.WriteLine("\n Informasi karyawan diperoleh dengan properti dan metode : \n");
            Console.WriteLine(@"Nama depan {0}", pegawai.NamaDepan);
            Console.WriteLine(@"Nama belakang {0}", pegawai.NamaBelakang);
            Console.WriteLine(@"Nomor KTP {0}", pegawai.NomorKTP);
            Console.WriteLine(@"Penjualan kotor {0:C}", pegawai.PenjualanKotor);
            Console.WriteLine(@"Tingkat komisi {0:F2} ", pegawai.TingkatKomisi);
            Console.WriteLine(@"Laba {0:C}", pegawai.Laba());

            pegawai.PenjualanKotor = 5000.00M;
            pegawai.TingkatKomisi = .1M;

            Console.WriteLine("\n Informasi karyawan setelah diperbarui \n");
            Console.WriteLine(pegawai);
            Console.WriteLine(@"Laba : {0:C}", pegawai.Laba());
            Console.ReadLine();
        }
    }
}
