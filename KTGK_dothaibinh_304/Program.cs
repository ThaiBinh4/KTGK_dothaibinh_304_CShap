using System;

class Program
{
    public class nguoi
    {
        public string soCMND { get; set; }
        public string hoten { get; set; }
        public int tuoi { get; set; }
        public string nghe { get; set; }
        public string idHo { get; set; }
        public nguoi(string soCMND, string hoten, int tuoi, string nghe, string idho)
        {
            this.soCMND = soCMND;
            this.hoten = hoten;
            this.tuoi = tuoi;
            this.nghe = nghe;
            this.idHo = idho;
        }
        public nguoi() { }
    }
    public class HoGiaDinh
    {
        public string IdHo { get; set; }
        public int tv { get; set; }
        public int trai { get; set; }
        public int gai { get; set; }
        public int soNha { get; set; }
        public string idkhu { get; set; }
        public HoGiaDinh(string idHo, int tv, int trai, int gai, int soNha, string idkhu)
        {
            IdHo = idHo;
            this.tv = tv;
            this.trai = trai;
            this.gai = gai;
            this.soNha = soNha;
            this.idkhu = idkhu;
        }
        public HoGiaDinh() { }
    }
    public class khu
    {
        public string idkhu { get; set; }
        public string tenkhu { get; set; }
        public khu(string idkhu, string tenkhu)
        {
            this.idkhu = idkhu;
            this.tenkhu = tenkhu;
        }
    }
    static void Main()
    {
        int n;
        var listho = new List<HoGiaDinh>();
        var listnguoi = new List<nguoi>();
        Console.Write("nhap n ho dan:");
        n = Convert.ToInt32(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("nhap ho dan thu:" + i);
            var ho = new HoGiaDinh();
            Console.Write("id ho:");
            ho.IdHo = Convert.ToString(Console.ReadLine());
            Console.Write("tv :");
            ho.tv = Convert.ToInt32(Console.ReadLine());
            Console.Write("trai:");
            ho.trai = Convert.ToInt32(Console.ReadLine());
            Console.Write("gai:");
            ho.gai = Convert.ToInt32(Console.ReadLine());
            Console.Write("so nha:");
            ho.soNha = Convert.ToInt32(Console.ReadLine());
            Console.Write("id khu:");
            ho.idkhu = Convert.ToString(Console.ReadLine());
            listho.Add(ho);
            for (int j = 1; j <= ho.tv; j++)
            {
                Console.WriteLine("nhap thanh vien thu " + j);
                var k = new nguoi();

                k.idHo = ho.IdHo;
                Console.Write("CMND:");
                k.soCMND = Convert.ToString(Console.ReadLine());
                Console.Write("ho ten:");
                k.hoten = Convert.ToString(Console.ReadLine());
                Console.Write("tuoi:");
                k.tuoi = Convert.ToInt32(Console.ReadLine());
                Console.Write("nghe nghiep:");
                k.nghe = Convert.ToString(Console.ReadLine());
                listnguoi.Add(k);
            }
        }
        Console.WriteLine(" thong tin cac ho:");
        foreach (var i in listho)
        {
            Console.WriteLine($"id ho:{i.IdHo}, thanh vien: {i.tv}, trai:{i.trai}, gai:{i.gai}, so nha:{i.soNha}, idKhu:{i.idkhu}");
            foreach (var j in listnguoi)
            {
                if (j.idHo.Equals(i.IdHo))
                    Console.WriteLine($"so CMND:{j.soCMND}, ten:{j.hoten}, tuoi:{j.tuoi}, nghe nghiep:{j.nghe}\n\n");
            }
        }
        Console.WriteLine("danh sach ho co so con trai>=2 la:");
        var list2trai = listho.Where(d => d.trai >= 2).ToList();
        foreach (var i in list2trai)
            Console.WriteLine($"id ho:{i.IdHo}, thanh vien: {i.tv}, trai:{i.trai}, gai:{i.gai}, so nha:{i.soNha}");
        Console.WriteLine("danh sach ho co so thanh vien tu 5 den 10 la:");
        var list510 = listho.Where(d => d.tv >= 5 && d.tv <= 10).ToList();
        foreach (var i in list510)
            Console.WriteLine($"id ho:{i.IdHo}, thanh vien: {i.tv}, trai:{i.trai}, gai{i.gai}, so nha:{i.soNha}");
        Console.WriteLine("nhap khu:");
        string khu = Convert.ToString(Console.ReadLine());
        int tong = 0;
        foreach (var i in listho)
            if (i.idkhu.Equals(khu))
                tong = tong + i.tv;
        Console.WriteLine(" tong so nguoi cua khu la:" + tong);
        
        Console.WriteLine("ho gia dinh co nguoi ten \"Hung\" la:");
        foreach (var k in listho)
        {
            foreach(var i in listnguoi)
                if (i.idHo.Equals(k.IdHo) && i.hoten.Contains("hung"))
                {
                    Console.WriteLine($"id ho:{k.IdHo}, so nha:{k.soNha},khu:{k.idkhu}");
                    break;
                }
                    
        }

        int sonam = 0, sonu = 0;
        foreach (var i in listho)
            if (i.idkhu.Equals(khu))
            {
                sonam = sonam + i.trai;
                sonu = sonu + i.gai;
            }
        Console.WriteLine("so nam trong khu la:" + sonam + ", so nu trong khu la:" + sonu);
        Console.ReadLine();
    }
}