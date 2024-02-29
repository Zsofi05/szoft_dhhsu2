// A v�letlensz�mokhoz sz�ks�g van egy gener�torra (RNG = Random Number Generator)
// AZ al�bbi sor csak ezt hozza l�tre, t�nyleges v�letlen sz�mot m�g nem gener�l
// A konstruktoron k�v�l �rdemes p�ld�nyos�tani, mert ebb�l csak 1-et akarunk l�trehozni 
// (Bonyolultabb probl�m�k eset�n van �rtelme t�bbet l�trehozni, de ahhoz nagyon �rteni kell a m�k�d�s�ket, egyszer�bb k�vetni azt a szab�lyt, hogy ebb�l MINDIG csak 1 legyen)
Random rng = new Random();

public Form1()
{
    InitializeComponent();

    // Ciklus, ami l�trehozza majd a gombokat
    for (int i = 0; i < 1000; i++)
    {
        // A t�nyleges randomsz�m gener�l�shoz a random gener�tor Next met�dus�t kell haszn�lnunk
        // Ennek k�t bemen� param�tere van, melyek megadj�k, hogy mely k�t �rt�k k�z�tt legyen a v�letlensz�m
        // Vigy�zat a fels� korl�t exkluz�v, teh�t ezt az �rt�ket m�r nem veheti fel a v�letlensz�m
        // Pl.: rng.Next(1, 10) eset�n 1-t�l 9-ig b�rmelyik sz�mot kaphatjuk eredm�nyk�nt, de a 10-et m�r nem
        // Az els� param�ter elhagyhat�, ekkor a minimum 0 lesz �s csak a maximumot kell megadni
        // Ha t�rt sz�mra van sz�ks�g, akkor a NextDouble() met�dus visszaad egy 0 �s 1 k�zti tizedes t�rtet
        // Ezt felszorozva b�rmilyen k�t �rt�k k�zti racion�lis sz�mot el� lehet �ll�tani

        // Az �tl�that�s�g �rdek�ben l�trehozunk v�ltoz�kat a v�letlen sz�mok t�rol�s�ra
        // Ezeknek a v�ltoz�knak l�trehoz�sa kihagyhat�, az �rt�kad�suk egyszer�en be�rhat� oda, ahol k�s�bb hivatkozunk r�juk

        // Aktu�lis gomb m�rete
        // Ebben a p�ld�ban a gomb sz�less�ge �s magass�ga v�letlen szer�en 20 �s 50 k�z�tt van               
        int width = rng.Next(20, 51);
        int height = rng.Next(20, 51);

        // Aktu�lis gomb poz�ci�ja
        // A poz�ci�k minimuma nulla, ez�rt haszn�lhat� a Next azon v�ltozata, ahol csak a maximum �rt�ket kell megadni
        // A sz�less�g maximum �rt�ke a Form sz�less�ge, de ebb�l le kell vonni az aktu�lis gomb sz�less�g�t, k�l�nben el�fordulhatna, hogy a gomb kil�g a Form-r�l
        // A ClientSize.Width a Form bels� m�ret�t adja m�g a sima Width a k�ls� keretet is sz�mba veszi ez�rt pontatlanabb
        int left = rng.Next(this.ClientSize.Width - width);
        int top = rng.Next(this.ClientSize.Height - height);

        // Aktu�lis gomb sz�ne
        // A sz�n meghat�roz�s�hoz az RGB k�dra van sz�ks�g�nk
        // Ez h�rom darab 0-255 k�zti sz�mb�l �ll
        int r = rng.Next(256);
        int g = rng.Next(256);
        int b = rng.Next(256);

        // A v�letlen sz�mok legener�l�sa ut�n egyszer�en l�trehozhat� a gomb
        Button gomb = new Button();
        gomb.Width = width;
        gomb.Height = height;
        gomb.Left = left;
        gomb.Top = top;
        gomb.BackColor = Color.FromArgb(r, g, b);
        this.Controls.Add(gomb);
    }
}