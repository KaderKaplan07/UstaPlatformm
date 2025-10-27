�lk a�amada projeyi Beyin (UstaPlatform.Domain), Eklentiler (UstaPlatform.Rules) ve Ana Program (UstaPlatform.App) olarak ��e ay�rd�m. 
1-Beyin (UstaPlatform.Domain): Bu projeye Usta, IsEmri gibi temel s�n�flar� ve en �nemlisi, t�m fiyat kurallar�n�n uymak zorunda oldu�u IPricingRule ad�nda bir aray�z (bir nevi �ablon) koydum. Bu proje en temelde duruyor ve kimseye ba��ml� de�il.
2- Eklentiler (UstaPlatform.Rules): Bunlar Rules.Haftasonu gibi k���k projeler. Hepsi Domain'deki IPricingRule �ablonunu al�p i�ini dolduruyor .Her biri ayr� bir .dll dosyas� �retiyor.
3-UstaPlatform.App (Ana Program): Buras� konsol uygulamas�. ��ine PricingEngine (Fiyat Motoru) ad�nda bir s�n�f yazd�m. Bu motor program a��l�rken plugins diye bir klas�re bak�yor, i�indeki t�m .dll'leri bulup okuyor ve IPricingRule �ablonuna uyan kurallar� haf�zaya at�yor. Fiyat hesaplarken de bu listedeki t�m kurallar� s�rayla �al��t�r�yor.

-- Nas�l �al��t�r�l�r? --
1- �ncelikle t�m projeleri derleyin.
2- UstaPlatform.App projesinin �al��t�r�labilir dosyas�n�n (UstaPlatform.App\bin\Debug\net6.0\) i�indeki "plugins" klas�r�ne gidin.
3- Eklentiler (UstaPlatform.Rules) projesinin derlenmi� .dll dosyalar�n� (�rne�in Rules.Haftasonu.dll) bu "plugins" klas�r�ne kopyalay�n.
4- �imdi UstaPlatform.App projesini �al��t�rabilirsiniz. Program, "plugins" klas�r�ndeki t�m kurallar� otomatik olarak y�kleyecek ve fiyat hesaplamalar�nda kullanacakt�r.
-- Nas�l Yeni Kural Eklenir? --
1- UstaPlatform.Rules projesine yeni bir s�n�f ekleyin (�rne�in Rules.OzelIndirim).
2- Bu s�n�f�n IPricingRule aray�z�n� implemente etti�inden emin olun ve gerekli metotlar� doldurun.
3- Projeyi derleyin. Yeni .dll dosyas�n� "plugins" klas�r�ne kopyalay�n.
4- UstaPlatform.App projesini yeniden ba�lat�n. Yeni kural otomatik olarak y�klenecektir.
-- Notlar --
- Her kural�n do�ru �al��t���ndan emin olmak i�in birim testleri yazmay� unutmay�n.
- Fiyat hesaplama s�ras�n� de�i�tirmek isterseniz, PricingEngine s�n�f�nda kurallar� y�kleme s�ras�n� d�zenleyebilirsiniz.
- Gelecekte yeni kurallar eklemek olduk�a kolay olacak �ekilde tasarland�, bu y�zden ihtiya� duyduk�a yeni eklentiler olu�turabilirsiniz.
- Herhangi bir sorunla kar��la��rsan�z, l�tfen proje dok�mantasyonuna veya kaynak koduna bak�n.
- �yi �al��malar ve ba�ar�lar dilerim!