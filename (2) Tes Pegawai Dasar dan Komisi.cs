using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_11_12__2_
{
    public class PegawaiDasardanKomisi
    {
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string NomorKTP { get; set; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;
        private decimal gajiPokok;

        public PegawaiDasardanKomisi(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
            GajiPokok = gajiPokok;
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
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(PenjualanKotor)} must be >= 0");
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
                        value, @"{nameof(TingkatKomisi)} must be > 0 and <1");
                }

                tingkatKomisi = value;
            }
        }

        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(GajiPokok)} must be >=0");
                }

                gajiPokok = value;
            }
        }

        public decimal Laba()
        {
            return gajiPokok + (tingkatKomisi * penjualanKotor);
        }

        public override string ToString()
        {
            return string.Format("pegawai komisi gaji pokok : {0} {1} \nnomor KTP : {2} \npenjualan kotor : {3:C} \ntingkat komisi : {4:F2} \ngaji pokok : {5:C}", NamaDepan, NamaBelakang, NomorKTP, penjualanKotor, tingkatKomisi, gajiPokok);
        }
    }
    class TesPegawaiDasardanKomisi
    {
        static void Main()
        {
            var pegawai = new PegawaiDasardanKomisi("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Nama depan {0}", pegawai.NamaDepan);
            Console.WriteLine("Nama belakang {0}", pegawai.NamaBelakang);
            Console.WriteLine("Nomor KTP {0}", pegawai.NomorKTP);
            Console.WriteLine("Penjualan kotor {0:C}", pegawai.PenjualanKotor);
            Console.WriteLine("Tingkat komisis {0:F2}", pegawai.TingkatKomisi);
            Console.WriteLine("Laba {0:C}", pegawai.Laba());
            Console.WriteLine("Gaji pokok {0:C}", pegawai.GajiPokok);

            pegawai.GajiPokok = 1000.00M;

            Console.WriteLine("\nInformasi pegawai yang telah diperbarui :\n");
            Console.WriteLine(pegawai);
            Console.WriteLine("laba : {0:C}", pegawai.Laba());
            Console.ReadLine();
        }
    }
}
