using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_11_12__4_
{
    public abstract class Pegawai
    {
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string NomorKTP { get; set; }

        public Pegawai(string namaDepan, string namaBelakang, string nomorKTP)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\n nomorKTP : {2}\n", NamaDepan, NamaBelakang, NomorKTP);
        }

        public abstract decimal Laba();
    }

    public class PenggajianPegawai : Pegawai
    {
        private decimal gajiPerminggu;

        public PenggajianPegawai(string namaDepan, string namaBelakang, string nomorKTP,
            decimal gajiPerminggu) : base(namaDepan, namaBelakang, nomorKTP)
        {
            GajiPerminggu = gajiPerminggu;
        }

        public decimal GajiPerminggu
        {
            get
            {
                return gajiPerminggu;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(GajiPerminggu)} must be >= 0");
                }

                gajiPerminggu = value;
            }
        }

        public override decimal Laba()
        {
            return GajiPerminggu;
        }

        public override string ToString()
        {
            return string.Format(@"Penggajian Karyawan: {0} Gaji Perminggu: {1}", base.ToString(), GajiPerminggu);
        }
    }

    public class JamPegawai : Pegawai
    {
        private decimal upah;
        private decimal jam;

        public JamPegawai(string namaDepan, string namaBelakang, string nomorKTP, decimal upahPerJam,
            decimal jamKerja) : base(namaDepan, namaBelakang, nomorKTP)
        {
            Upah = upahPerJam;
            Jam = jamKerja;
        }

        public decimal Upah
        {
            get
            {
                return upah;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(Upah)} must be >= 0");
                }

                upah = value;
            }
        }

        public decimal Jam
        {
            get
            {
                return jam;
            }
            set
            {
                if (value < 0 || value > 168)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(Jam)} must be >= 0 and <= 168");
                }

                jam = value;
            }
        }

        public override decimal Laba()
        {
            if (Jam <= 40)
            {
                return Upah * Jam;
            }
            else
            {
                return (40 * Upah) + ((Jam - 40) * Upah * 1.5M);
            }
        }

        public override string ToString()
        {
            return string.Format("Pegawai per jam: {0} Upah per jam: {1:C}\n Jam kerja: {2:F2}", base.ToString(), Upah, Jam);
        }
    }

    public class PegawaiKomisi : Pegawai
    {
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public PegawaiKomisi(string namaDepan, string namaBelakang, string nomorKTP,
            decimal penjualanKotor, decimal tingkatKomisi) : base(namaDepan, namaBelakang, nomorKTP)
        {
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
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
                        value, @"{nameof(TingkatKomisi)} must be > 0 and < 1");
                }

                tingkatKomisi = value;
            }
        }

        public override decimal Laba()
        {
            return TingkatKomisi * PenjualanKotor;
        }

        public override string ToString()
        {
            return string.Format("pegawai komisi : {0} \npenjualan kotor : {1:C} \ntingkat komisi : {2:F2}", base.ToString(), PenjualanKotor, TingkatKomisi);
        }
    }

    public class PegawaiDasardanKomisi : PegawaiKomisi
    {
        private decimal gajiPokok;

        public PegawaiDasardanKomisi(string namaDepan, string namaBelakang, string nomorKTP,
            decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok) : base(namaDepan,
            namaBelakang, nomorKTP, penjualanKotor, tingkatKomisi)
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(GajiPokok)} must be >= 0");
                }

                gajiPokok = value;
            }
        }

        public override decimal Laba()
        {
            return GajiPokok + base.Laba();
        }

        public override string ToString()
        {
            return string.Format(@"gaji pokok {0} \ngaji pokok : {1:C}", base.ToString(), GajiPokok);
        }
    }
    class Program
    {
        static void Main()
        {
            var penggajianPegawai = new PenggajianPegawai("John", "Smith", "111-11-1111", 800.00M);
            var jamPegawai = new JamPegawai("Karen", "Price", "222-22-2222", 16.75M, 40.0M);
            var pegawaiKomisi = new PegawaiKomisi("Sue", "Jones", "333-33-3333", 10000.00M, .06M);
            var pegawaiDasardanKomisi = new PegawaiDasardanKomisi("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Proses secara individu pegawai : \n");
            Console.WriteLine("{0} \n diperoleh : {1:C}\n", penggajianPegawai, penggajianPegawai.Laba());
            Console.WriteLine("{0} \n diperoleh : {1:C}\n", jamPegawai, jamPegawai.Laba());
            Console.WriteLine("{0} \n diperoleh : {1:C}\n", pegawaiKomisi, pegawaiKomisi.Laba());
            Console.WriteLine("{0} \n diperoleh : {1:C}\n", pegawaiDasardanKomisi, pegawaiDasardanKomisi.Laba());

            var banyakPegawai = new List<Pegawai>() { penggajianPegawai, jamPegawai, pegawaiKomisi, pegawaiDasardanKomisi };

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            Console.WriteLine("Proses secara polimorfisme pegawai : \n");

            foreach (var pekerjaSekarang in banyakPegawai)
            {
                Console.WriteLine(pekerjaSekarang);

                if (pekerjaSekarang is PegawaiDasardanKomisi)
                {
                    var pegawai = (PegawaiDasardanKomisi)pekerjaSekarang;

                    pegawai.GajiPokok = 1.10M;
                    Console.WriteLine("gaji pokok setelah dinaikkan 10% : {0:C}", pegawai.GajiPokok);
                }

                Console.WriteLine("diperoleh: {0:C}\n", pekerjaSekarang.Laba());
            }

            Console.WriteLine();
            Console.WriteLine("==========================================================================");
            Console.WriteLine();

            for (int j = 0; j < banyakPegawai.Count; j++)
            {
                Console.WriteLine("Pegawai {0} itu {1}", j, banyakPegawai[j].GetType());
            }
            Console.ReadLine();
        }
    }
}
