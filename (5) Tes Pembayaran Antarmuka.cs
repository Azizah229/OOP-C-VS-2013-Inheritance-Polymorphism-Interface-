using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter_11_12__5_
{
    public interface HarusDibayar
    {
        decimal JumlahPembayaran();
    }

    public class Tagihan : HarusDibayar
    {
        public string NomorBagian { get; set; }
        public string DeskripsiBagian { get; set; }
        private int kuantitas;
        private decimal hargaPerBuah;

        public Tagihan(string nomorBagian, string deskripsiBagian, int kuantitas, decimal hargaPerBuah)
        {
            NomorBagian = nomorBagian;
            DeskripsiBagian = deskripsiBagian;
            Kuantitas = kuantitas;
            HargaPerBuah = hargaPerBuah;
        }

        public int Kuantitas
        {
            get
            {
                return kuantitas;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(Kuantitas)} must be >= 0");
                }

                kuantitas = value;
            }
        }

        public decimal HargaPerBuah
        {
            get
            {
                return hargaPerBuah;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(typeof(ValueType).Name,
                        value, @"{nameof(HargaPerBuah)} must be >= 0");
                }

                hargaPerBuah = value;
            }
        }

        public override string ToString()
        {
            return string.Format("tagihan :\nnomor bagian : {0} ({1})\n kuantitas : {2}\nharga per buah : {3:C}", NomorBagian, DeskripsiBagian, Kuantitas, HargaPerBuah);
        }

        public decimal JumlahPembayaran()
        {
            return Kuantitas * HargaPerBuah;
        }
    }

    public abstract class Pegawai : HarusDibayar
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
            return string.Format("{0} {1}\n nomor KTP : {2}", NamaDepan, NamaBelakang, NomorKTP);
        }

        public abstract decimal Laba();

        public decimal JumlahPembayaran()
        {
            return Laba();
        }
    }

    public class PenggajianPegawai : Pegawai
    {
        private decimal gajiPerminggu;

        public PenggajianPegawai(string namaDepan, string namaBelakang, string nomorKTP,
            decimal gajiPerminggu)
            : base(namaDepan, namaBelakang, nomorKTP)
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
            return string.Format("Penggajian Karyawan: {0} \nGaji Perminggu: {1}", base.ToString(), GajiPerminggu);
        }
    }

    class TesPembayaran
    {
        static void Main()
        {
            var objekHutang = new List<HarusDibayar>(){
                new Tagihan("01234", "seat", 2, 357.00M),
                new Tagihan("56789", "tire", 4, 79.95M),
                new PenggajianPegawai("John", "Smith", "111-11-1111", 800.00M),
                new PenggajianPegawai("Lisa", "Barnes", "222-22-2222", 1200.00M)};

            Console.WriteLine("Tagihan dan pegawai diproses secara polimorfisme :\n");

            foreach (var hutang in objekHutang)
            {
                Console.WriteLine("{0}", hutang);
                Console.WriteLine("tanggal jatuh tempo : {0:C}\n", hutang.JumlahPembayaran());
            }
            Console.ReadLine();
        }
    }
}
